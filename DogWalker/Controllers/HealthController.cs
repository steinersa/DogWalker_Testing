using DogWalker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DogWalker.Controllers
{
    public class HealthController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dogs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dogs/Details/5
        public ActionResult Details()
        {
            var userResult = User.Identity.GetUserId();
            Owner currentUser = db.Owners.Where(x => userResult == x.ApplicationId).FirstOrDefault();
            //Dog currentDog = db.Dogs.Where(x => currentUser)
            //var healthOfDog = db.Health.Where(x => id == x.).FirstOrDefault();
            return View();
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            Health health = new Health();
            return View(health);
        }

        // POST: Dogs/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,HeartCondition,SeizureCondition,Allergies,Blind,Deaf,PhysicalLimitations,Comments")] Health health)
        {
            try
            {
                db.Health.Add(health);
                db.SaveChanges();
                return RedirectToAction("Create", "Demeanor");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rating,Name,Age,Breed,Size,SpayedNeutered,OwnerId,HealthId,DemeanorId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
