using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using DotRestaurant.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace DotRestaurant.Controllers {
    public class HomeController : Controller {

        readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        [Route("~/Book")]
        [HttpPost]
        public IActionResult Book(BookTableModel bookTableModel)
        {
            var bookManager = new BookTableManager(new EFBookTable()) ;
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
                ViewData["bookTableStatus"] = "Rezervasyon yapýlýrken bir hata meydana geldi";

            }

            ViewData["IndexPageOrNot"] = false;
            return View();
        }


    }
}
