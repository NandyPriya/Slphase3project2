using ClassLibrary1;
using ClassLibrary3;
using sl_phase3project2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sl_phase3project2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Helper helper = null;
        public StudentController()
        {
            helper = new Helper();
        }
        public ActionResult Index()
        {
            var emplist = helper.ShowStudentList();
            List<StudentClass> modelsList = new List<StudentClass>();
            foreach (var item in emplist)
            {
                modelsList.Add(new StudentClass {Studentid = item.Studentid,Studname=item.Studname,Class=item.Class,Email=item.Email,Address = item.Address  });
            }

            return View(modelsList);

        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var emp = helper.SearchEmployee(id);
            StudentClass model = new StudentClass();
            model.Studentid = id;
            model.Studname = emp.Studname;
            model.Class = emp.Class;
            model.Address = emp.Address;
            model.Email = emp.Email;
            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                BAL bal = new BAL();
                bal.Studentid = Convert.ToInt32(Request["studentid"]);
                bal.Studname = Request["studname"].ToString();
                bal.Class = Request["class"].ToString();
                bal.Email = Request["email"].ToString();
                bal.Address = Request["address"].ToString();
                // TODO: Add insert logic here
                bool ans = helper.addstudent(bal);
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = helper.SearchEmployee(id);
            StudentClass model = new StudentClass();
            model.Studentid = id;
            model.Studname = emp.Studname;
            model.Class = emp.Class;
            model.Address = emp.Address;
            model.Email = emp.Email;
            //only date
           

            //date and time
            /*model.BirthDate=emp.BirthDate.ToUniversalTime();*/



           

            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var emp = helper.SearchEmployee(id);
                emp.Studentid = Convert.ToInt32(Request["studentid"]);
                emp.Studname = Request["studname"].ToString();
                emp.Class = Request["class"].ToString();
                emp.Email = Request["email"].ToString();
                emp.Address = Request["address"].ToString();
                bool ans = helper.editstudent(emp);


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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = helper.SearchEmployee(id);
            StudentClass model = new StudentClass();
            model.Studentid = id;
            model.Studname = emp.Studname;
            model.Class = emp.Class;
            model.Address = emp.Address;
            model.Email = emp.Email;
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dataFound = helper.SearchEmployee(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveEmployee(id);
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
