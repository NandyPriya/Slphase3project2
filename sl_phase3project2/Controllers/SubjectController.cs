using ClassLibrary1;
using ClassLibrary3;
using sl_phase3project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sl_phase3project2.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        Helper helper = null;
        public SubjectController()
        {
            helper = new Helper();
        }
        public ActionResult Index()
        {
            var emplist = helper.ShowSubjectList();
            List<SubjectModel> modelsList = new List<SubjectModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new SubjectModel { Subjectid= item.Subjectid, Subname = item.Subname, Class1 = item.Class1 });
            }

            return View(modelsList);
            
        }

        // GET: Subject/Details/5
        public ActionResult Details(int id)
        {
            var emp = helper.SearchSubject(id);
            SubjectModel model = new SubjectModel();
            model.Subjectid = id;
            model.Subname = emp.Subname;
            model.Class1 = emp.Class1;

            return View(model);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                BAL bal = new BAL();
                bal.Subjectid = Convert.ToInt32(Request["subjectid"]);
                bal.Subname = Request["subname"].ToString();
                bal.Class1 = Request["class1"].ToString();
                
                // TODO: Add insert logic here
                bool ans = helper.addsubject(bal);
                if (ans)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    return View();
                }

               
            }
            catch(Exception ex)
            {
                ViewBag.exMsg = ex.Message;
                return View();
            }
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = helper.SearchSubject(id);
            SubjectModel model = new SubjectModel();
            model.Subjectid = id;
            model.Subname = emp.Subname;
            model.Class1 = emp.Class1;

            return View(model);
            
        }

      
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var emp = helper.SearchSubject(id);
                emp.Subjectid = Convert.ToInt32(Request["subjectid"]);
                emp.Subname = Request["subname"].ToString();
                emp.Class1 = Request["class1"].ToString();
               
                bool ans = helper.editsubject(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                
            }
            catch(Exception ex)
            {
                ViewBag.exMsg = ex.Message;
                return View();
            }
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = helper.SearchSubject(id);
            SubjectModel model = new SubjectModel();
            model.Subjectid = id;
            model.Subname = emp.Subname;
            model.Class1 = emp.Class1;
           
            return View(model);
            
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.SearchEmployee(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveSubject(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }
    }
}
