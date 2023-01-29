using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    internal class EmployeeContext : DbContext
    {
        //В классе контекста определяются свойства для взаимодействия с талицами в бд:
        //Используется длясвязи 1 к 1
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkBook> WorkBooks { get; set; }
    }
}
