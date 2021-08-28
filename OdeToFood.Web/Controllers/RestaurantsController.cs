using OdeToFood.Data.Models;
using OdeToFood.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        // GET: Restaurants
        public IRestaurantData db { get; set; }
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
                return View("NotFound");
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            db.Add(restaurant);
            return View();
        }
    }
}