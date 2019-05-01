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
    }
}