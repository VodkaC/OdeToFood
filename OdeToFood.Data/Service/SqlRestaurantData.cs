using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Service
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            this.db.Restaurants.Add(restaurant);
            this.db.SaveChanges();
        }

        public void Delete(Restaurant restaurant)
        {
            //var restaurantDelete = this.Get(restaurant.Id);
            //if(restaurantDelete != null)
                //db.Restaurants.Remove(restaurantDelete);
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return this.db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
