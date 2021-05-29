﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRApplicationUsingAJAX.Models
{
    public class CareerField
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        //navigation property
        public virtual List<Employee> Employees { get; set; }
    }
}