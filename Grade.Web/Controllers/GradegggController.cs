using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grade.Web.Models;

namespace Grade.Web.Controllers
{
    public class GradegggController : Controller
    {
        protected List<GradeModel> gradeLists = new List<GradeModel>
        {
            new GradeModel
            {
                GradeName = "A",
                Min = 90,
                Max = 100,                
            },
            //new GradeModel
            //{
            //    GradeName = "B+",
            //    Min = 79,
            //    Max = 89,
            //},
            //new GradeModel
            //{
            //    GradeName = "B",
            //    Min = 71,
            //    Max = 80,
            //},
        };

        // GET: Grade
        public ActionResult Index()
        {
            return View(gradeLists);
        }        

        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            if (ModelState.IsValid)
            {
                var grades = ConvertToGradeMode(forms);

                // validate data 

                return View(grades);
            }
            return View();
        }

        #region internal control
        protected List<GradeModel> ConvertToGradeMode(FormCollection forms)
        {
            List<GradeModel> results = new List<GradeModel>();

            foreach (string key in forms.Keys)
            {
                var values = forms.GetValues(key);
                for (int i = 0; i < values.Length; i++)
                {
                    if (key == "GradeName")
                    {
                        var g = new GradeModel();
                        g.GradeName = values[i];
                        results.Add(g);
                    }
                    else if (key == "Min")
                    {
                        var g = results[i];
                        g.Min = int.Parse(values[i]);
                    }
                    else if (key == "Max")
                    {
                        var g = results[i];
                        g.Max = int.Parse(values[i]);
                    }
                }
            }

            return results;
        }
        #endregion
    }
}