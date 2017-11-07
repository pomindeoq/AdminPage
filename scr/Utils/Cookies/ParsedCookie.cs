using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AdminPage.Utils.Cookies
{
    public class ParsedCookie
    {
        public CookieOptions CookieOptions { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public ParsedCookie(CookieOptions cookieOptions, string name, string value)
        {
            CookieOptions = cookieOptions;
            Name = name;
            Value = value;
        }
    }
}
