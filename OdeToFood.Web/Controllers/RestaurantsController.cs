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
            //if (string.IsNullOrEmpty(restaurant.Name))
            //    ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            else
                return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model != null)
                return View(model);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                db.Delete(restaurant);
                return View("Index");
            }
            return View("NotFound");
        }
    }
}