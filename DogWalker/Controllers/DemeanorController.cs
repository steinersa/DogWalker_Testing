using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalker.Controllers
{
    public class DemeanorController : Controller
    {
        // GET: Demeanor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Demeanor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demeanor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demeanor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demeanor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Demeanor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demeanor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demeanor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
