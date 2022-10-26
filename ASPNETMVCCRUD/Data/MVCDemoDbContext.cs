using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MVCDemoDbContext:DbContext
    {
        public MVCDemoDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee> Empoloyees { get; set; }
    }
}