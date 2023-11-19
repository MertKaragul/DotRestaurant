using DotRestaurant.Service.Abstract;
using System.Net;
using System.Net.NetworkInformation;

namespace DotRestaurant.Service.Concrete
{
    public class CookieService : ICookie {
        public void createCookie(HttpContext context, string cookieName, string cookieValue)
        {
            context.Response.Cookies.Append(cookieName,cookieValue,getCookieOptions());
        }

        public void deleteContext(HttpContext context, string cookieName, string cookieValue)
        {
            context.Response.Cookies.Delete(cookieName);
        }

        public CookieOptions getCookieOptions()
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                Expires = DateTimeOffset.UtcNow.AddDays(99999),
                Path = "/",
            };
        }
    }
}
