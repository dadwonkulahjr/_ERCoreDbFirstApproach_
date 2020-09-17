using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApproach.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployees>();
        }

        public int Id { get; set; }
        [Display(Name ="Department Name")]
        [Required]
        public string DepartmentName { get; set; }

        public virtual ICollection<TblEmployees> TblEmployees { get; set; }
    }
}
