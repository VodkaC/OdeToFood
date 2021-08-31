﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Service
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant() {Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Indian },
                new Restaurant() {Id = 2, Name = "Tersiguels", Cuisine = CuisineType.Italian },
                new Restaurant() {Id = 3, Name = "Mango-Grove", Cuisine = CuisineType.French }
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(x => x.Id + 1);
            restaurants.Add(restaurant);          
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }             
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Delete(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
