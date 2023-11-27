using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Service.Concrete;
using DotRestaurant.Utils;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotRestaurant.Controllers {
    public class UserController : Controller {

        private CookieService cookieService = new CookieService();
        private JsonService<UserModel> jsonService = new JsonService<UserModel>();

        [Route("~/User")]
        [HttpGet]
        public IActionResult Index() {
            try
            {
                var checkUser = cookieService.getCookie(HttpContext, Constants.UserCookieName);
                var user = jsonService.fromJson(checkUser);
                return View(user);
            }
            catch (Exception ex)
            {
                return View(null);
            }
            
        }


        [Route("~/User/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                if(userModel == null)
                {
                    return BadRequest(new { message = "Kayıt bilgileri boş olamaz" });
                }

                var userDatabase = new UserManager(new EFUser());

                if(await userDatabase.findByEmail(userModel.Email) != null)
                {
                    return BadRequest(new {message = userModel.Email + "'a kayıtlı bir E-mail hesabı mevcut"});
                }


                var generateUUID = Guid.NewGuid().ToString() ?? "";
                if(generateUUID == "")
                {
                    return StatusCode(500, new { message = "Sunucu hatası" });
                }

                userModel.UUID = generateUUID;
                userDatabase.TAdd(userModel);
                setUserCookie(userModel);
                return Ok(new { message = "Kayıt başarılı" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }

        [Route("~/User/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserModel? userModel)
        {
            try
            {
                if(userModel == null) return StatusCode(500, new { message = "Doğrulama yapılırken hata meydana geldi" });
                var userDatabase = new UserManager(new EFUser());
                var findUser = await userDatabase.findByEmail(userModel.Email);
                if(findUser == null) return Unauthorized(new { message = userModel.Email+ "'a ait bir hesap bulunamadı" });
                var cookieService = new CookieService();
                var jsonService = new JsonService<UserModel>();
                cookieService.createCookie(HttpContext, Constants.UserCookieName, jsonService.toJson(findUser));
                return Ok(new { message = "Doğrulama başarılı" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }



        [Route("~/User/Logout")]
        [HttpPost]
        public IActionResult Logout()
        {
            try
            {
                var cookieService = new CookieService();
                cookieService.deleteCookie(HttpContext, Constants.UserCookieName);
                return Ok(new { message = "Başarıyla çıkış yapıldı" });
            }catch (Exception ex)
            {
                return StatusCode(500, new { message = "Sunucu hatası" });
            }
        }

        private void setUserCookie(UserModel userModel)
        {
            var json = jsonService.toJson(userModel);
            cookieService.createCookie(HttpContext, Constants.UserCookieName, json);
        }
    }
}
