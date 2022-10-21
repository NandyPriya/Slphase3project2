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
    public class ClassesController : Controller
    {
        // GET: Classes
        Helper helper = null;
        public ClassesController()
        {
          helper = new Helper();
        }
        public ActionResult Index()
        {
            var emplist = helper.ShowClassesList();
            List<ClassesModel> modelsList = new List<ClassesModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new ClassesModel { Classname = item.Classname, Noofstudents = item.Noofstudents });
            }

            return View(modelsList);
            
        }

        // GET: Classes/Details/5
        public ActionResult Details(string id)
        {
            var emp = helper.SearchClasses(id);
            ClassesModel model = new ClassesModel();
            model.Classname = id;
            
            model.Noofstudents = emp.Noofstudents;

            return View(model);
            
        }

        // GET: Classes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                BAL bal = new BAL();
                bal.Classname = Request["classname"].ToString();
                bal.Noofstudents = Convert.ToInt32(Request["noofstudents"]);
               

                // TODO: Add insert logic here
                bool ans = helper.addclasses(bal);
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

        // GET: Classes/Edit/5
        public ActionResult Edit(string id)
        {
            var emp = helper.SearchClasses(id);
            ClassesModel model = new ClassesModel();
            model.Classname = id;

            model.Noofstudents = emp.Noofstudents;

            return View(model);

           
        }

        // POST: Classes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                var emp = helper.SearchClasses(id);
                emp.Classname = Request["classname"].ToString();
                emp.Noofstudents = Convert.ToInt32(Request["noofstudents"]);
                

                bool ans = helper.editclasses(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

               
            }
            catch
            {
                return View();
            }
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(string id)
        {
            var emp = helper.SearchClasses(id);
            ClassesModel model = new ClassesModel();
            model.Classname = id;

            model.Noofstudents = emp.Noofstudents;

            return View(model);

            
        }

        // POST: Classes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                var dataFound = helper.SearchClasses(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveClasses(id);
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
