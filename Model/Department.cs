using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Department
    {
        //кафедра
        public int Id { get; set; }
        public string Name { get; set; }            //Название кафедры
        public string Specialization { get; set; }  //Специальность кафедры
        public virtual List<Employee> Employees { get; set; }//Лист сотрудников
    }
}
