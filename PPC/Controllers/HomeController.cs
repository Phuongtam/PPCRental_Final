using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC.Models;

namespace PPC.Controllers
{
    public class HomeController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();
     // List<SelectListItem> type, district;
        public ActionResult Index()
        {

            var model = db.PROPERTY.OrderBy(x=>x.ID).Where(x=>x.Status_ID==3).ToList();
            ViewBag.property_type = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.district = db.DISTRICT.OrderByDescending(x => x.ID ).ToList();
            ViewBag.ward = db.WARD.OrderByDescending(x => x.ID).ToList();
            ViewBag.street = db.STREET.OrderByDescending(x => x.ID).ToList();
            
           
            return View(model);
         
        }
        public JsonResult GetStreet(int District_id)
        {
            return Json(
            db.STREET.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.StreetName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
        //
        //
       
        [HttpGet]
        public ActionResult Search(string txtSearch,int? PropertyType_ID,int? District_ID)
        {
            //var project = db.PROPERTY.Where(x => x.Status_ID == 3).AsQueryable().ToList();
            //if (!(String.IsNullOrEmpty(txtSearch)) || !(String.IsNullOrWhiteSpace(txtSearch)))
            //{
            //    project = project.Where(x => x.PropertyName.Contains(txtSearch)).ToList();
            //}
            //if (PropertyType_ID != null)
            //    project = project.Where(x => x.PropertyType_ID == PropertyType_ID).ToList();
            //if (District_ID != null)
            //    project = project.Where(x => x.District_ID == District_ID).ToList();
            var project = db.PROPERTY.ToList().Where(x => (x.PropertyName.Contains(txtSearch)
                 || x.Content.Contains(txtSearch) || x.Price.ToString().Contains(txtSearch)) && (x.District_ID == District_ID) || (x.PropertyType_ID == PropertyType_ID));

            return View(project);
        }
        //public ActionResult Search_Test(string searchTerm)
        //{
        //    var terms = searchTerm?.Split(' ') ?? new string[0];
        //    var predicate = terms.Aggregate(
        //        PredicateBuilder.New<Book>(string.IsNullOrEmpty(searchTerm)),
        //        (acc, term) => acc.Or(b => b.Title.Contains(term))
        //                          .Or(b => b.Author.Contains(term)));

        //    var books = db.Books.AsExpandable()
        //                        .Where(predicate)
        //                        .OrderBy(b => b.Title)
        //                        .ToArray();

        //    return View("List", books);
        //}



        public ActionResult About()
        {
            var ab = db.INTRODUCTION.ToList();

            return View(ab);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}