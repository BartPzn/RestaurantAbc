using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using RestaurantA.Entities;

namespace RestaurantA
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                //Powinien byc wykrzyknic czyli zaprzeczenie ale inaczej wyskakuj blad. a finalnie i tak baza danych nie zapisuje sie (!_dbContext.Restaurants.Any())
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }




        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description =
                        "KFC (Short for Kentucky Fried Chicken) is a shit American fast food restaurant with junk food",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery =  true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Fried",
                            Price = 3.20M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "Mc Donalds",
                    Category = "Fast Food",
                    Description =
                        "Ehh better will without description",
                    ContactEmail = "contact@mcd.com",
                    HasDelivery =  true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Big Mac",
                            Price = 25.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Długa 5",
                        PostalCode = "00-001"
                    },
                }
            };

            return restaurants;
        }
    }
}

