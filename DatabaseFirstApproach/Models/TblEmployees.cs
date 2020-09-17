using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApproach.Models
{
    public partial class TblEmployees
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress, RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        public string Email { get; set; }
        [Display(Name ="Gender")]
        [Required]
        public int? GenderId { get; set; }
        [Display(Name = "Department")]
        [Required]
        public int? DepartmentId { get; set; }
        [Required]
        public decimal? Salary { get; set; }

        public virtual TblDepartment Department { get; set; }
        public virtual TblGender Gender { get; set; }
    }
}
