using OdeToFood.Data.Models;
using OdeToFood.Data.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Models
{
    public class RestaurantViewModel 
    {
        IRestaurantData db;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public RestaurantViewModel()
        {
            db = new InMemoryRestaurantData();
            Restaurants = db.GetAll();
        }

    }
}