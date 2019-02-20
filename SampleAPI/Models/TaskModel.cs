using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class TaskModel
    {
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
       // public long AssignedTo { get; set; }
        public long UserID { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}