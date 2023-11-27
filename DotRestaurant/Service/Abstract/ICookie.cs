
using EntityLayer.Concrete;

namespace DotRestaurant.Service.Abstract {
    public interface ICookie {
        void createCookie(HttpContext context,String cookieName, String cookieValue);
        void deleteCookie(HttpContext context, String cookieName);
        String? getCookie(HttpContext context,String cookieName);
        CookieOptions getCookieOptions();
    }
}
