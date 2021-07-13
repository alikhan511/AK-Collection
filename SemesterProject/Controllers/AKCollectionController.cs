using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SemesterProject.Models;

namespace SemesterProject.Controllers
{

    public class AKCollectionController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        // GET: AKCollection
        public ActionResult Index()
        {
            var r = dc.Shoppings.Select(bn => bn).Distinct();
            ViewBag.data = r;
            return View();

        }
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(dc.Shoppings.First(bn => bn.Id == id));
        }

        public ActionResult EditDone(int id)
        {
            var sp = dc.Shoppings.First(bn => bn.Id == id);

            sp.brandName = Request["brandName"];
            sp.code = Request["productCode"];
            sp.size = Request["size"];
            sp.color = Request["color"];
            sp.description = Request["description"];
            sp.price = Request["price"];

            dc.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            Shopping sp = new Shopping();

            sp.brandName = Request["brandName"];
            sp.code = Request["productCode"];
            sp.size = Request["size"];
            sp.color = Request["color"];
            sp.description = Request["description"];
            sp.price = Request["price"];

            dc.Shoppings.InsertOnSubmit(sp);
            dc.SubmitChanges();
            return RedirectToAction("AddItem");
        }

        public ActionResult viewRecords()
        {
            var b = dc.Shoppings.Select(bn => bn.brandName).Distinct();
            return View(b.ToList());
        }
        public ActionResult editRecords()
        {
            var r = dc.Shoppings.Select(bn => bn);
            return View(r.ToList());
        }
        public ActionResult Delete(int id)
        {
            var r = dc.Shoppings.First(bn => bn.Id == id);
            dc.Shoppings.DeleteOnSubmit(r);
            dc.SubmitChanges();

            return RedirectToAction("Index");
        }

    }
}