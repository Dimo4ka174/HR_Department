using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class HR_Department
    {
        //отдел кадров
        public int Id { get; set; }
        public virtual List<Employee> Employees { get; set; }   //Список сотрудников
        public DateTime VacationDates { get; set; }             //Даты отпуска
        public DateTime DateStartContract { get; set; }         //Дата начала контракта
        public DateTime DateEndContract { get; set; }           //Дата окончания контракта
        public DateTime DateStartWorkUniversity { get; set; }   //Дата начала работы в универе
    }
}
