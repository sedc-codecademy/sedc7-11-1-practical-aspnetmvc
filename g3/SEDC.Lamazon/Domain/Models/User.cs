using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        //realtions
        public List<Order> Orders { get; set; }
    }
}
