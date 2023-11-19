
namespace DotRestaurant.Service.Abstract {
    public interface ICookie {
        void createCookie(HttpContext context,String cookieName, String cookieValue);
        void deleteContext(HttpContext context, String cookieName, String cookieValue);
        CookieOptions getCookieOptions();
    }
}
