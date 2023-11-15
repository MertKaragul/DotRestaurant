using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotRestaurant.Controllers {
    public class HomeController : Controller {





        [Route("~/")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["IndexPageOrNot"] = true;
            return View();
        }



        [Route("~/Menu")]
        [HttpGet]
        public IActionResult Menu()
        {
            var foodManager = new FoodManager(new EFFood());
            var categoryManager = new CategoryManager(new EFCategory());
            var values = new MenuViewModel(categoryManager.TGetAll(), foodManager.TGetAll());

            ViewData["IndexPageOrNot"] = false;
            return View(values) ;
        }

        [Route("~/About")]
        [HttpGet]
        public IActionResult About()
        {
            ViewData["IndexPageOrNot"] = false;
            return View();
        }

        [Route("~/Book")]
        [HttpGet]
        public IActionResult Book()
        {
            ViewData["IndexPageOrNot"] = false;
            return View();
        }


    }
}
