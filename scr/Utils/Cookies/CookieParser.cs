using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AdminPage.Utils.Cookies
{
    public static class CookieParser
    {
        public static ParsedCookie Parse(string cookieString)
        {
            int nameEndIndex = cookieString.IndexOf('=');
            int valueEndIndex = cookieString.IndexOf(';');
            string name = cookieString.Substring(0, nameEndIndex);
            string value = cookieString.Substring(nameEndIndex + 1, valueEndIndex - nameEndIndex - 1);
            string cookieStringAlt = cookieString.Replace(name + "=" + value + ";", "");
            string[] options = cookieStringAlt.Split(';');
            CookieOptions cookieOptions = new CookieOptions();

            foreach (var option in options.Select(c => c.Split(new[] { '=' }, 2)))
            {
                if (Regex.Replace(option[0], @"\s+", "").ToLower().Equals("httponly"))
                {
                    cookieOptions.HttpOnly = true;
                }
                else if (Regex.Replace(option[0], @"\s+", "").ToLower().Equals("expires"))
                {
                    cookieOptions.Expires = DateTimeOffset.Parse(option[1]);
                }
                else if (Regex.Replace(option[0], @"\s+", "").ToLower().Equals("path"))
                {
                    cookieOptions.Path = option[1];
                }
                else if (Regex.Replace(option[0], @"\s+", "").ToLower().Equals("samesite"))
                {
                    SameSiteMode? sameSiteMode = null;
                    if (option[1].ToLower().Equals("lax"))
                    {
                        sameSiteMode = SameSiteMode.Lax;
                    }
                    else if (option[1].ToLower().Equals("none"))
                    {
                        sameSiteMode = SameSiteMode.None;
                    }
                    else if (option[1].ToLower().Equals("strict"))
                    {
                        sameSiteMode = SameSiteMode.Strict;
                    }
                    if (sameSiteMode != null) cookieOptions.SameSite = (SameSiteMode)sameSiteMode;
                }
                else if (Regex.Replace(option[0], @"\s+", "").ToLower().Equals("domain"))
                {
                    cookieOptions.Domain = option[1];
                }
            }
            return new ParsedCookie(cookieOptions, name, value);
        }
    }
}
