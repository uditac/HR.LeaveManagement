﻿using HR.LeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string DefaultDays { get; set; }


}
