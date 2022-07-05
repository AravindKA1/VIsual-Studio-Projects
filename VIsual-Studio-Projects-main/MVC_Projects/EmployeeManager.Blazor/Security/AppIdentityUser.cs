﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Blazor.Security
{
  public class AppIdentityUser : IdentityUser
  {
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
