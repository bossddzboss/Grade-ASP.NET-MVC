using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grade.Web.Models;
using System.Web.Mvc;

namespace Grade.Web.Controllers
{
    public class GradeJsonController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: GradeJson
        public JsonResult Index()
        {
            return Json(_dbContext.Grades, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult Sample()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Sample(GradeModel grade)
        {
            try
            {
                // TODO: Add insert logic here
                //if (ModelState.IsValid)
                // {
                //_grades.Add(grade);

                var dbObj = _dbContext.Grades.FirstOrDefault(g => g.GradeName.Equals(grade.GradeName, StringComparison.CurrentCultureIgnoreCase));
                if (dbObj == null)
                {
                    _dbContext.Grades.Add(grade);
                    _dbContext.SaveChanges();
                }

                return View();
                //}
            }
            catch
            {
                return Json(grade);
            }

        }
        //TODO: GET var
        //https://www.c-sharpcorner.com/UploadFile/2ed7ae/jsonresult-type-in-mvc/?
    }
}