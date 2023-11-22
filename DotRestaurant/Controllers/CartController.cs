using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Service.Concrete;
using DotRestaurant.Utils;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DotRestaurant.Controllers {
    public class CartController : Controller {

        [Route("~/addToCart")]
        [HttpPost]
        public async Task<IActionResult> addToCart(string? FoodID) {
            try
            {
                if(FoodID == null) return BadRequest(new { message = "Ürün eklerken bir hata meydana geldi" });
                var foodManager = new FoodManager(new EFFood());
                if(foodManager.TgetById(int.Parse(FoodID)) == null) return BadRequest(new { message = "Ürün eklerken bir hata meydana geldi" });


                var cookieService = new CookieService();
                var getUserCookie = cookieService.getCookie(HttpContext, Constants.UserCookieName);
                var jsonService = new JsonService<UserModel>();
                var parseJsonCookie = jsonService.fromJson(getUserCookie);
                if(parseJsonCookie == null)
                {
                    return Unauthorized(new { message = "Kayıt olmadan sepete ürün eklenemez" });
                }

                var cartManager = new CartManager(new EFCart());
                var userCart = await cartManager.findByUserUUID(parseJsonCookie.UUID);
                 
                if(userCart == null)
                {
                    // User cart empty, create new list and add food to cart
                    ArrayList newList = new ArrayList();
                    cartManager.TAdd(new CartModel(parseJsonCookie.UUID, newList.Cast<String>().ToList()));
                }
                else
                {
                    // if user before add cart food cannot create new list
                    if(userCart.FoodList.Find(x => x == FoodID) == null) 
                    {
                        userCart.FoodList.Add(FoodID);
                        cartManager.TUpdate(userCart);
                    }
                    else
                    {
                        return Ok(new { message = "Ürün sepetinizde zaten mevcut" });
                    }
                    
                }

                return Ok(new { message = "Ürün sepete başarıyla eklendi" });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }
    }
}
