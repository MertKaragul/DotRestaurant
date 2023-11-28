﻿using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Service.Concrete;
using DotRestaurant.Utils;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Collections;

namespace DotRestaurant.Controllers {
    public class CartController : Controller {

        [Route("~/addToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(string? FoodID) {
            try
            {

                // Check user sign in 
                var cookieService = new CookieService();
                String? getUserCookie;
                try
                {
                    getUserCookie = cookieService.getCookie(HttpContext, Constants.UserCookieName);
                }
                catch(Exception ex)
                {
                    getUserCookie = null;
                }

                if(getUserCookie == null || getUserCookie == "") return Unauthorized(new { message = "Giriş yapmadan ürün eklenemez" });


                // Verify food
                if(FoodID == null) return BadRequest(new { message = "Ürün eklerken bir hata meydana geldi" });
                var foodManager = new FoodManager(new EFFood());

                var findFood = await foodManager.TgetById(int.Parse(FoodID));
                if(findFood == null) return BadRequest(new { message = "Ürün bulunamadı" });
                if(!findFood.FoodStatus) return BadRequest(new { message = "Geçici olarak bir süre bu ürünün hizmetini sağlayamıyoruz." });

                var jsonService = new JsonService<UserModel>();
                var parseJsonCookie = jsonService.fromJson(getUserCookie);
                if(parseJsonCookie == null)
                {
                    return Unauthorized(new { message = "Giriş yapılmadan sepete ürün eklenemez" });
                }

                var cartManager = new CartManager(new EFCart());
                var userCart = await cartManager.findByUserUUID(parseJsonCookie.UUID);
                 
                if(userCart == null)
                {
                    // if the user first time add product to cart
                    ArrayList newList = new ArrayList();
                    cartManager.TAdd(new CartModel(parseJsonCookie.UUID, newList.Cast<String>().ToList()));
                }
                else
                {
                    // if the user has already added items to the cart
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
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }

        [Route("~/removeCart")]
        [HttpPost]
        public async Task<IActionResult> RemoveCart(int? foodID)
        {
            try {
                if(foodID != null)
                {
                    // if user sign in 
                    var cookieService = new CookieService();
                    String? getUserCookie;

                    try
                    {
                        getUserCookie = cookieService.getCookie(HttpContext, Constants.UserCookieName);
                    }
                    catch(Exception ex)
                    {
                        getUserCookie = null;

                    }

                    if(getUserCookie == null || getUserCookie == "") return Unauthorized(new { message = "Giriş yapmadan ürün silemezsiniz" });

                    // Verify food 
                    var foodManager = new FoodManager(new EFFood());
                    var findFood = await foodManager.TgetById(foodID.Value);
                    if(findFood == null) return BadRequest(new { message = "Ürün bulunamadı" });
                    if(!findFood.FoodStatus) return BadRequest(new { message = "Ürün bulunamadı" });


                    var jsonService = new JsonService<UserModel>();
                    var parseJsonCookie = jsonService.fromJson(getUserCookie);
                    if(parseJsonCookie == null)
                    {
                        return Unauthorized(new { message = "Kayıt olmadan ürün silinemez" });
                    }

                    var cartManager = new CartManager(new EFCart());
                    var getUserCart = await cartManager.findByUserUUID(parseJsonCookie.UUID);
                    if(getUserCart == null) return Ok(new { message = "Sepet boş" });

                    var findFoodInCart = getUserCart.FoodList.First(x => x == foodID.ToString());
                    getUserCart.FoodList.Remove(findFoodInCart);
                    cartManager.TUpdate(getUserCart);
                    return Ok(new { message = "Ürün başarıyla silindi" });
                    }
                else
                {
                  return BadRequest(new { message = "Ürün Bulunamadı" });
                } 
            }
            catch(Exception ex) {
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }

        [Route("~/cart")]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var cookieService = new CookieService();
                String? getUserCookie;
                try
                {
                    getUserCookie = cookieService.getCookie(HttpContext, Constants.UserCookieName);
                }catch(Exception ex)
                {
                    getUserCookie=null;
                }

                if(getUserCookie == null)
                {
                    ViewData["userNotFound"] = "Lütfen hesabınıza giriş yapın";
                }
                var jsonService = new JsonService<UserModel>();
                var parseJsonCookie = jsonService.fromJson(getUserCookie);
                if(parseJsonCookie == null) ViewData["userNotFound"] = "Lütfen hesabınıza giriş yapın";


                ArrayList userCartList = new ArrayList();
                var cartManager = new CartManager(new EFCart());
                var userCart = await cartManager.findByUserUUID(parseJsonCookie.UUID);
                var foodManager = new FoodManager(new EFFood());
                foreach(var item in userCart.FoodList)
                {
                    userCartList.Add(await foodManager.TgetById(int.Parse(item)));
                }

                return View(userCartList.Cast<FoodModel>().ToList());
            }
            catch(Exception ex)
            {
                return View(null);
            }
            
        }
    }
}
