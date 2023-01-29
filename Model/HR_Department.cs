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
        public long Id { get; set; }
        public DateTime VacationBeginDate { get; set; }        //Дата начала отпуска
        public DateTime VacationEndDate { get; set; }           //Дата окончания отпуска
        public DateTime ContractBeginDate { get; set; }         //Дата начала контракта
        public DateTime ContractEndDate { get; set; }           //Дата окончания контракта
        public DateTime WorkUniversityBeginDate { get; set; }   //Дата начала работы в универе
        public virtual List<Employee> Employees { get; set; }   //Список сотрудников связь 1 к М
    }
}
