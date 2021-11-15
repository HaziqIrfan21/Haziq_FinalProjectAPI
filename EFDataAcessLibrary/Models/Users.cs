using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAcessLibrary.Models
{
   public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IsAdmin { get; set; }

        public List<Orders> Order { get; set; } = new List<Orders>();

    }
}
