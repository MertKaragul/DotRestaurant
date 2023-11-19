using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DotRestaurant.Controllers {
    public class CartController : Controller {
        [HttpPost]
        public IActionResult AddFoodToCart(int? foodId, int? userID) {
            var getFoodId = foodId;
            var getUserId = userID;
            if(getFoodId == null || getUserId == null) return Json(new { error = "FoodID cannot be null" });
            FoodManager foodManager = new FoodManager(new EFFood());
            CartManager cartManager = new CartManager(new EFCart());

            if(foodManager.TgetById(getFoodId ?? 9999) == null)
            {
                cartManager.TAdd(new CartModel());
            }

            return Json(new { error = "FoodId cannot be null" });
        }
    }
}
