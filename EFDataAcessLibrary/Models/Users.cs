using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDataAcessLibrary.Models
{
   public class Users
    {
        public int Id { get; set; }

    
        [MaxLength(100)]
        public string UserName { get; set; }
        
        [MaxLength(100)]
        public string Password { get; set; }
     
        [MaxLength(100)]
        public string FirstName { get; set; }
    
        [MaxLength(100)]
        public string LastName { get; set; }
    
        [MaxLength(100)]
        public string Email { get; set; }
        public int IsAdmin { get; set; }

        public List<Orders> Order { get; set; } = new List<Orders>();

    }
}
