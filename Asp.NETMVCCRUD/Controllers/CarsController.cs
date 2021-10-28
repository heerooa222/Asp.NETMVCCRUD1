using Asp.NETMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class CarsController : Controller
    {
        DBModel db;

        public CarsController()
        {
             db = new DBModel();
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<Car> carList = db.Cars.ToList();
            return Json(new { data = carList }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Car());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Cars.Where(x => x.Id == id).FirstOrDefault<Car>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Car car)
        {
            using (DBModel db = new DBModel())
            {
                if (car.Id == 0)
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(car).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Car car = db.Cars.Where(x => x.Id == id).FirstOrDefault<Car>();
                db.Cars.Remove(car);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
