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
    }
}