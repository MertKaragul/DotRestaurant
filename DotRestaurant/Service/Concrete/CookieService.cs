using DotRestaurant.Service.Abstract;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace DotRestaurant.Service.Concrete
{
    public class CookieService : ICookie {

        private const int cookieTime = 9999;

        public void createCookie(HttpContext context, string cookieName, String cookieValue)
        {
            if(cookieName == null || cookieValue == null) return;
            context.Response.Cookies.Append(cookieName, cookieValue, getCookieOptions());
        }

        public void deleteContext(HttpContext context, string cookieName, string cookieValue)
        {
            context.Response.Cookies.Delete(cookieName);
        }

        public String? getCookie(HttpContext context,string cookieName)
        {
            var getCookieValue = context.Request.Cookies[cookieName];

            if(getCookieValue == null) return null;


            return getCookieValue;
        }

        public CookieOptions getCookieOptions()
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Expires = DateTimeOffset.UtcNow.AddDays(cookieTime),
                Path = "/",
                
            };
        }
    }
}
