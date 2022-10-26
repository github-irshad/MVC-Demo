using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkcore;


namespace Data
{
    public class MVCDemoDbContext:DbContext
    {
        DbSet<Employee>Employees;
    }
}