using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Accounting
    {
        //бухгалтерия
        public int Id { get; set; }
        public decimal Salary { get; set; }     //Зарплата
        public int Workload { get; set; }       //рабочая нагрузка        
        public virtual List<Employee> Employees { get; set; } //Лист сотрудников

    }
}
