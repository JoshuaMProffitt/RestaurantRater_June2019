﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterMVC.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Food Type")]
        public string FoodType { get; set; }
        public decimal Rating { get; set; }
    }

    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}