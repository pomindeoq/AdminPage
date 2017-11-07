using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AdminPage.Utils.Cookies;
using Microsoft.AspNetCore.Http;

namespace AdminPage.Api
{
    public static class ApiClient
    {
        private static readonly HttpClientHandler Handler = new HttpClientHandler
        {
            UseCookies = false
        };
        private static readonly HttpClient HttpClient = new HttpClient(Handler)
        {
            DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") }}
        };
        private static readonly string ApiUri = "http://localhost:54443/api";


        public static async Task<HttpResponseMessage> PostAsync(string apiUrl,string jsonString)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(ApiUri + apiUrl),
                Method = HttpMethod.Post,
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            string cookieString = CookiesToString(GetCookies());
            if (cookieString != null)
            {
                httpRequestMessage.Headers.Add("Cookie", cookieString);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            List<string> cookies = GetCookiesFromHeader(httpResponseMessage.Headers);
            if (cookies != null)
            {
                SetRecievedCookies(cookies);
            }

            return httpResponseMessage;
        }

        public static async Task<HttpResponseMessage> GetAsync(string apiUrl)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(ApiUri + apiUrl),
                Method = HttpMethod.Get,
            };
            string cookieString = CookiesToString(GetCookies());
            if (cookieString != null)
            {
                httpRequestMessage.Headers.Add("Cookie", cookieString);
            }

            HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage);

            List<string> cookies = GetCookiesFromHeader(httpResponseMessage.Headers);
            if (cookies != null)
            {
                SetRecievedCookies(cookies);
            }

            return httpResponseMessage;
        }

        private static string CookiesToString(IRequestCookieCollection cookiesToSend)
        {
            string cookieString = null;
            foreach (var cookie in cookiesToSend)
            {
                cookieString = cookieString + $"{cookie.Key}={cookie.Value};";
            }
            return cookieString;
        }

        private static IRequestCookieCollection GetCookies()
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            IRequestCookieCollection cookieValue = httpContextAccessor.HttpContext.Request.Cookies;
            return cookieValue;
        }

        private static void SetRecievedCookies(List<string> cookiesList)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            foreach (string cookie in cookiesList)
            {
                ParsedCookie parsedCookie = CookieParser.Parse(cookie);
                httpContextAccessor.HttpContext.Response.Cookies.Append(parsedCookie.Name, parsedCookie.Value, parsedCookie.CookieOptions);
            }
        }

        private static List<string> GetCookiesFromHeader(HttpResponseHeaders httpResponseHeaders)
        {
            foreach (var header in httpResponseHeaders)
            {
                if (header.Key == "Set-Cookie")
                {
                    return header.Value.ToList();
                }
            }
            return null;
        }

    }
}
