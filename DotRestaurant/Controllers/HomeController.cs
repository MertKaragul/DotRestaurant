using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Models;
using DotRestaurant.Service.Concrete;
using DotRestaurant.Utils;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

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
            // Food and category manager
            var foodManager = new FoodManager(new EFFood());
            var categoryManager = new CategoryManager(new EFCategory());
            var values = new MenuViewModel(categoryManager.TGetAll(), foodManager.TGetAll());
            return View(values);
        }

        [Route("~/About")]
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [Route("~/Book")]
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [Route("~/Book")]
        [HttpPost]
        public IActionResult Book(BookTableModel bookTableModel)
        {
            var bookManager = new BookTableManager(new EFBookTable());
            try
            {
                if(bookManager.findByEmail(bookTableModel.Email) != null)
                {
                    ViewData["bookTableStatus"] = bookTableModel.Email + "'e ait bir rezevasyon bulunuyor.";
                }
                else
                {
                    new BookTableManager(new EFBookTable()).TAdd(bookTableModel);
                    ViewData["bookTableStatus"] = "Rezervasyon baþarýyla yapýldý";
                }
            }
            catch(Exception ex)
            {
                ViewData["bookTableStatus"] = "Rezervasyon yapýlýrken bir hata meydana geldi, " + ex.Message;
            }

            ViewData["IndexPageOrNot"] = false;
            return View();
        }


    }
}
