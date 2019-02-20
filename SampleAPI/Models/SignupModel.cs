﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.Models
{
    public class SignupModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}