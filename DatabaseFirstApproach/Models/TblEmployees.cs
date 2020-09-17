using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models
{
    public partial class TblEmployees
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? GenderId { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? Salary { get; set; }

        public virtual TblDepartment Department { get; set; }
        public virtual TblGender Gender { get; set; }
    }
}
