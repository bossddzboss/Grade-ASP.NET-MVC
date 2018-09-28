using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grade.Web.Models;
using System.Web.Mvc;

namespace Grade.Web.Controllers
{
    public class GradeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        private List<GradeModel> _grades = new List<GradeModel>
        {
            new GradeModel("A", 90, 100),
            new GradeModel("B+", 85, 89),
            new GradeModel("B", 80, 84),
            new GradeModel("C+", 75, 79),
            new GradeModel("C", 60, 64),
            new GradeModel("D+", 55, 59),
            new GradeModel("D", 50, 54),
            new GradeModel("F", 0, 49),
        };


        // GET: Grade
        public ActionResult Index()
        {
            var grades = _dbContext.Grades.OrderByDescending(g => g.Min).ThenBy(g => g.Max);

            return View(grades);
        }

      


        // GET: Grade/Details/5
        public ActionResult Details(int id)
        {
            var grade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);

            return View(grade);
        }
        [HttpPost]
        public ActionResult Details(int id, GradeModel grade)
        {
            try
            {
                var dbGrade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);
                return View(grade);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(grade);
            }
        }

            // GET: Grade/Create
            public ActionResult Create()
        {
            return View();
        }

        // POST: Grade/Create
        [HttpPost]
        public ActionResult Create(GradeModel grade)
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

                return RedirectToAction("Index");
                //}
            }
            catch
            {
                return View(grade);
            }

        }

        // GET: Grade/Edit/5
        public ActionResult Edit(int id)
        {
            var grade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);

            return View(grade);
        }

        // POST: Grade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GradeModel grade)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {

                    var dbGrade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);

                    dbGrade.GradeName = grade.GradeName;
                    dbGrade.Max = grade.Max;
                    dbGrade.Min = grade.Min;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(grade);
            }

            return View(grade);
        }

        // GET: Grade/Delete/5
        public ActionResult Delete(int id)
        {
            var grade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);

            return View(grade);
        }

        // POST: Grade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GradeModel grade)
        {
            try
            {
                var dbGrade = _dbContext.Grades.FirstOrDefault(g => g.Id == id);
                if (dbGrade != null)
                {
                    _dbContext.Grades.Remove(dbGrade);

                    _dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(grade);
        }
        
        }
        
    }
}
