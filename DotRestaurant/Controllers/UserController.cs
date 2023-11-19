using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Service.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotRestaurant.Controllers {
    public class UserController : Controller {


        [Route("~/User")]
        [HttpGet]
        public IActionResult Index() {


            return View();
        }


        [Route("~/User/Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            try
            {
                if(userModel == null)
                {
                    TempData["RegisterStatus"] = "Kayıt bilgileri boş olamaz";
                    return RedirectToAction("Index");
                }

                var userDatabase = new UserManager(new EFUser());

                if(await userDatabase.findByEmail(userModel.Email) != null)
                {
                    TempData["RegisterStatus"] = userModel.Email+" hesabına ait kayıt mevcut";
                    return RedirectToAction("Index");
                }


                var generateUUID = Guid.NewGuid().ToString() ?? "";
                if(generateUUID == "")
                {
                    TempData["RegisterStatus"] = "Bir şeyler yanlış gitti";
                    return RedirectToAction("Index");
                }

                userModel.UUID = generateUUID;
                userDatabase.TAdd(userModel);
                setUserCookie(userModel);
                TempData["RegisterStatus"] = "Kayıt başarılı";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["RegisterStatus"] = "Sunucu hatası, " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        private void setUserCookie(UserModel userModel)
        {
            var cookieService = new CookieService();
            cookieService.createCookie(HttpContext, "Username", userModel.Name);
            cookieService.createCookie(HttpContext, "Email", userModel.Email);
            cookieService.createCookie(HttpContext, "Password", userModel.Password);
            cookieService.createCookie(HttpContext, "UUID", userModel.UUID);
        }
    }
}
