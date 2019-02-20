using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models.ViewModel
{
    public class TaskViewModel
    {
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}