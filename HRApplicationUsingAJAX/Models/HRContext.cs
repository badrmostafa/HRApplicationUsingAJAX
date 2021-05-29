using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRApplicationUsingAJAX.Models
{
    public class HRContext:DbContext
    {
        public HRContext():base("HRConnection")
        {

        }

        public DbSet<CareerField> CareerFields { get; set; }
        public DbSet<CompanyJob> CompanyJobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
    }
}