using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Jai.Models
{
    public class Employee
    {
        [MaxLength(3)]
        public string EmpName { get; set; }
        public int EmpAge { get; set; }
        [Required]
        public Double EmpSalary { get; set; }
    }
}