using System;
using System.Collections.Generic;
using System.Text;
using EFDataAcessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAcessLibrary.DataAccess
{
    public class RestaurantContext : DbContext
    {
    

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<Users> User { get; set; }

        public DbSet<Orders> Order { get; set; }

    }
}
