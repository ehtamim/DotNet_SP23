using ZeroHunger.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class ZHContext:DbContext
    {
        public DbSet<NGO> NGOS { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<FoodRequest> FoodRequests { get; set; }
        public DbSet<AcceptedRequest> AcceptedRequests { get; set; }
    }
}