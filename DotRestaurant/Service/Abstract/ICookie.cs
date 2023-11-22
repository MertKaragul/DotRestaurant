
using EntityLayer.Concrete;

namespace DotRestaurant.Service.Abstract {
    public interface ICookie {
        void createCookie(HttpContext context,String cookieName, String cookieValue);
        void deleteContext(HttpContext context, String cookieName, String cookieValue);
        String? getCookie(HttpContext context,String cookieName);
        CookieOptions getCookieOptions();
    }
}
