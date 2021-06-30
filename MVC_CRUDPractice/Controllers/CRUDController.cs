using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUDPractice.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult create(Student model)
        {

            // To open a connection to the database
            using (var context = new CRUD_PracticeEntities())
            {
                // Add data to the particular table
                context.Students.Add(model);

                // save the changes
                context.SaveChanges();
            }
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View();
        }


        [HttpGet] // Set the attribute to Read
        public ActionResult Read()
        {
            using (var context = new CRUD_PracticeEntities())
            {


                var data = context.Students.ToList();
                return View(data);
            }
        }




        public ActionResult Update(int Studentid)
        {
            using (var context = new CRUD_PracticeEntities())
            {
                var data = context.Students.Where(x => x.StudentID == Studentid).SingleOrDefault();
                return View(data);
            }
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int Studentid, Student model)
        {
            using (var context = new CRUD_PracticeEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.Students.FirstOrDefault(x => x.StudentID == Studentid);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.Email = model.Email;
                    data.StudentAddress = model.StudentAddress;
                    context.SaveChanges();

                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Read");
                }
                else
                    return View();
            }



        }
    }
}