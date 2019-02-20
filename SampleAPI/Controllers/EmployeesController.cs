using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SampleAPI.BL;
using SampleAPI.Models;
using SampleAPI.Models.Request;
using SampleAPI.Models.Response;

namespace SampleAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private SampleAssignmentEntities db = new SampleAssignmentEntities();
        AccountBL accountBL = new AccountBL();
        TaskBL taskBL = new TaskBL();

        // GET: api/Employees

        [Route("api/GetAllTasks")]
        public Array GetAllTasks()
        {
            TaskResponseModel taskresponseModel = new TaskResponseModel();
            var data= taskBL.GetAllTask();


           // taskresponseModel.TaskListData = taskBL.GetAllTask();
            return data;
           // return db.Employees;
        }

        [Route("api/GetAllResource")]
        public Array GetAllResource()
        {
            var data = (from res in db.RegisterUsers
                        select new ResourceResponse()
                        {
                            UserName = res.FirstName,
                            UserId = res.UserID
                        }).ToArray();
            return data;
            // return db.Employees;
        }

        // GET: api/Employees/5
        [Route("api/GetTaskByID")]
        public IHttpActionResult GetTaskByID(long id)
        {
            var taskData = taskBL.GetTaskById(id);

            if (taskData == null)
            {
                return NotFound();
            }

            return Ok(taskData);
        }

        //// PUT: api/Employees/5
        //[ResponseType(typeof(void))]
        //[Route("api/PutEmployee")]
        //public IHttpActionResult PutEmployee(long id, Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != employee.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Employees

        [Route("api/AddTask")]
        public IHttpActionResult AddTask(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = taskBL.CreateTask(taskModel);
            if (data==true)
            {
                return Ok(taskModel);
            }
            return BadRequest();
           
        }

        //// DELETE: api/Employees/5
        //[ResponseType(typeof(Employee))]
        //[Route("api/DeleteEmployee")]
        //public IHttpActionResult DeleteEmployee(long id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Employees.Remove(employee);
        //    db.SaveChanges();

        //    return Ok();
        //}


        // POST: api/Signup

        [Route("api/Signup")]
        public IHttpActionResult Signup(SignUpRequest signUpRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var signupData = accountBL.SignUpUser(signUpRequest);

            if (signupData == true)
            {
                return Ok(signUpRequest);
            }
            return BadRequest();
            
        }

        [Route("api/Login")]
        public IHttpActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var loginresponse = accountBL.Login(loginModel);
            if (loginresponse==true)
            {
                return Ok();
                //Username and password is correct
            }

            return BadRequest();
        }


        // POST: api/Employees
       
        [Route("api/CreateTask")]
        public IHttpActionResult CreateTask(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var taskData = taskBL.CreateTask(taskModel);
           

            return Ok();
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool EmployeeExists(long id)
        //{
        //    return db.Employees.Count(e => e.ID == id) > 0;
        //}
    }
}