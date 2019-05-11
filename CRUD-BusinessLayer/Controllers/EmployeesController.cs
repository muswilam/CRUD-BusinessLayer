using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace CRUD_BusinessLayer.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeBusinessLayer db = new EmployeeBusinessLayer();

        public ActionResult List()
        {
            return View(db.GetAllEmployees.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.AddEmployee(employee);
                return RedirectToAction("List");
            }
            else
                return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
           Employee employee = db.GetAllEmployees.Single(emp => emp.Id == id);
           db.DeleteEmployee(employee.Id);
           return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            Employee employee = db.GetAllEmployees.Single(emp => emp.Id == id);
            employee.confirmPass = employee.Password;
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            UpdateModel(employee);
            if (ModelState.IsValid)
            {

                db.UpdateEmployee(employee);

                return RedirectToAction("List");
            }
            return View(employee);
        }
    }
}