using SampleAPI.Models;
using SampleAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SampleAPI.BL
{
    public class TaskBL
    {
        private SampleAssignmentEntities db = new SampleAssignmentEntities();
        TaskModel taskModel = new TaskModel();
        public Array GetAllTask()
        {
            var model = (from tasks in db.Tasks
                         select new TaskViewModel
                         {
                             Date = tasks.Date,
                             TaskName=tasks.TaskName,
                             Description=tasks.Description,
                             AssignedTo = tasks.RegisterUser.FirstName,
                             //UserID=(long)tasks.UserID,
                             Priority =tasks.Priority,
                             Status=tasks.Status
                         }).ToArray();
            return model;
        }

        public Array GetTaskById(long id)
        {
            var model = (from tasks in db.Tasks
                         where tasks.RegisterUser.UserID==id
                         select new TaskViewModel
                         {
                             Date = tasks.Date,
                             TaskName = tasks.TaskName,
                             Description = tasks.Description,
                             AssignedTo = tasks.RegisterUser.FirstName,
                             //UserID=(long)tasks.UserID,
                             Priority = tasks.Priority,
                             Status = tasks.Status
                         }).ToArray();
            return model;
        }



        public bool CreateTask(TaskModel taskModel)
        {
            var data = new Task()
            {
                UserID = taskModel.UserID,
                Description = taskModel.Description,
               // AssignedTo = taskModel.AssignedTo,
                Date = taskModel.Date,
                TaskName = taskModel.TaskName,
                Priority=taskModel.Priority,
                Status=taskModel.Status
            };

            db.Tasks.Add(data);
            db.SaveChanges();
            return true;

        }

    }
}