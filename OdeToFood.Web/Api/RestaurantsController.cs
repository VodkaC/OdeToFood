﻿using OdeToFood.Data.Models;
using OdeToFood.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Restaurant> Get()
        {
            return db.GetAll();
        }
    }
}