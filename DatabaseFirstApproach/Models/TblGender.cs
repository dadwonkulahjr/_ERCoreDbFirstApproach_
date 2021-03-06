﻿using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach.Models
{
    public partial class TblGender
    {
        public TblGender()
        {
            TblEmployees = new HashSet<TblEmployees>();
        }

        public int Id { get; set; }
        public string Sex { get; set; }

        public virtual ICollection<TblEmployees> TblEmployees { get; set; }
    }
}
