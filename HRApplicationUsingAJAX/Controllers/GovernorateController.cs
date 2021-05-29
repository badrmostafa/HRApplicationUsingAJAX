using HRApplicationUsingAJAX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplicationUsingAJAX.Controllers
{
    public class GovernorateController : Controller
    {
        HRContext db = new HRContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GovernoratesList()
        {
            List<Governorate> governorates = db.Governorates.ToList();
            return PartialView("ListGovernorate", governorates);
        }

        public ActionResult AddOrEdit(int id = 0)
        {

            return PartialView("AddOrUpdate", new Governorate());
        }

       

        public ActionResult Save(Governorate governorate)
        {
            if (governorate.ID == 0)
            {
                db.Governorates.Add(governorate);
                db.SaveChanges();

            }
            else
            {
                var g = db.Governorates.Find(governorate.ID);
                if (g != null)
                {
                    g.Name = governorate.Name;
                    db.Governorates.Attach(g);
                    db.Entry(g).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
           List<Governorate> governorates = db.Governorates.ToList();
            return PartialView("ListGovernorate", governorates);
        }

        public ActionResult Edit(int id)
        {
            var governorate = db.Governorates.Find(id);
            return PartialView("AddOrUpdate", governorate);
        }

        public ActionResult Delete(int id = 0)
        {
            Governorate governorate = db.Governorates.Where(g => g.ID == id).FirstOrDefault();
            if(governorate != null)
            {
                db.Governorates.Remove(governorate);
                db.SaveChanges();
            }
            List<Governorate> governorates = db.Governorates.ToList();
            return PartialView("ListGovernorate", governorates);
        }



    }
}