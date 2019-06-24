﻿using RestaurantRater.Models;
using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }
        // Get : Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }
        // Post: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }
        // GET: Details {id}
        public ActionResult Details (int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Restaurant restaurant = _db.Restaurants.Find(id);

            if (restaurant == null)
                return HttpNotFound();

            return View(restaurant);
        }
        // GET: Restaurant Edit {id}
        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // Post: Restaurant Edit {id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if(restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        // POST: Restaurant/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
