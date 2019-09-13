using System;
using System.Collections.Generic;
using System.Text;

namespace Lamazon.WebModels.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
    }
}
