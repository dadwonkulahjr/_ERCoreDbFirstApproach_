using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseFirstApproach.Models
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblEmployees = new HashSet<TblEmployees>();
        }

        public int Id { get; set; }
        [Display(Name ="Gender")]
        [Required]
        public string Sex { get; set; }

        public virtual ICollection<TblEmployees> TblEmployees { get; set; }
    }
}
