using HRApplicationUsingAJAX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRApplicationUsingAJAX.Controllers
{
    public class EmployeeQualificationController : Controller
    {
        HRContext db = new HRContext(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListEmployees()
        {
            List<EmployeeQualification> employeeQualifications = db.EmployeeQualifications
                .OrderBy(e => e.Employee.CompanyJob.JobArrangement).ToList();
            
            return PartialView("ListEmployeeQualification", employeeQualifications);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            ViewData["Employees"] = new SelectList(db.Employees.ToList(), "ID", "Name");
            ViewData["Qualifications"] = new SelectList(db.Qualifications.ToList(), "ID", "Name");
            return PartialView("AddOrUpdate", new EmployeeQualification());
        }

        public ActionResult Save(EmployeeQualification employeeQualification)
        {
            if(employeeQualification.ID == 0)
            {
                db.EmployeeQualifications.Add(employeeQualification);
                db.SaveChanges();
            }
            else
            {
                var emp = db.EmployeeQualifications.Where(e => e.ID == employeeQualification.ID).FirstOrDefault();
                if(emp != null)
                {
                    emp.EmployeeId = employeeQualification.EmployeeId;
                    emp.QualificationId = employeeQualification.QualificationId;
                    db.EmployeeQualifications.Attach(emp);
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
           List<EmployeeQualification> employeeQualifications =  db.EmployeeQualifications.ToList();
            return PartialView("ListEmployeeQualification", employeeQualifications);
        }

        public ActionResult Edit(int id = 0)
        {
            ViewData["Employees"] = new SelectList(db.Employees.ToList(), "ID", "Name");
            ViewData["Qualifications"] = new SelectList(db.Qualifications.ToList(), "ID", "Name");
            var emp = db.EmployeeQualifications.Where(e => e.ID == id).FirstOrDefault();
            return PartialView("AddOrUpdate", emp);
        }

        public ActionResult Delete(int id = 0)
        {
           EmployeeQualification employeeQualification = db.EmployeeQualifications.Where(e => e.ID == id).FirstOrDefault();
            if(employeeQualification != null)
            {
                db.EmployeeQualifications.Remove(employeeQualification);
                db.SaveChanges();
            }
            List<EmployeeQualification> employeeQualifications = db.EmployeeQualifications.ToList();
            return PartialView("ListEmployeeQualification",employeeQualifications);
        }
    }
}