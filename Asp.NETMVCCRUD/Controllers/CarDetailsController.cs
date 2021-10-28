using Asp.NETMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.NETMVCCRUD.Controllers
{
    public class CarDetailsController : Controller
    {
        // GET: CarDetails
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<CarDetail> carList = db.CarDetails.ToList<CarDetail>();
                return Json(new { data = carList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CarDetail());
            else
            {
                DBModel db = new DBModel();
                return View(db.CarDetails.Where(x => x.Id == id).FirstOrDefault<CarDetail>());

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(CarDetail carDetail)
        {
            using (DBModel db = new DBModel())
            {
                if (carDetail.Id == 0)
                {
                    db.CarDetails.Add(carDetail);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(carDetail).State = EntityState.Modified;
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
                CarDetail car = db.CarDetails.Where(x => x.Id == id).FirstOrDefault<CarDetail>();
                db.CarDetails.Remove(car);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
