using HRApplicationUsingAJAX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplicationUsingAJAX.Controllers
{
    public class NeighborhoodController : Controller
    {
        HRContext db = new HRContext(); 
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NeighborhoodList()
        {
            List<Neighborhood> neighborhoods = db.Neighborhoods.ToList();
            return PartialView("ListNeighborhood", neighborhoods);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ViewData["Governorates"] = new SelectList(db.Governorates.ToList(), "ID", "Name");
            return PartialView("AddOrUpdate", new Neighborhood());
        }

        public ActionResult Save(Neighborhood neighborhood)
        {
            if (neighborhood.ID == 0)
            {
                db.Neighborhoods.Add(neighborhood);
                db.SaveChanges();
            }
            else
            {
                var n = db.Neighborhoods.Where(h => h.ID == neighborhood.ID).FirstOrDefault();
                if (n != null)
                {
                    n.Name = neighborhood.Name;
                    n.GovernorateId = neighborhood.GovernorateId;
                    db.Neighborhoods.Attach(n);
                    db.Entry(n).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
           List<Neighborhood> neighborhoods = db.Neighborhoods.ToList();
            return PartialView("ListNeighborhood", neighborhoods);
        }

        public ActionResult Edit(int id= 0)
        {
            ViewData["Governorates"] = new SelectList(db.Governorates.ToList(), "ID", "Name");
            var neighborhood = db.Neighborhoods.Where(n => n.ID == id).FirstOrDefault();
            return PartialView("AddOrUpdate",neighborhood);
        }

        public ActionResult Delete(int id = 0)
        {
            Neighborhood neighborhood = db.Neighborhoods.Where(n => n.ID == id).FirstOrDefault();
            if(neighborhood != null)
            {
                db.Neighborhoods.Remove(neighborhood);
                db.SaveChanges();
            }
            List<Neighborhood> neighborhoods =  db.Neighborhoods.ToList();
            return PartialView("ListNeighborhood",neighborhoods);
        }

    }
}