using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployees = new HashSet<TblEmployees>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<TblEmployees> TblEmployees { get; set; }
    }
}
