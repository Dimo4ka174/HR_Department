using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class WorkBook
    {
        public int Id { get; set; }                 //Id трудовой книги
        public int EmployeeId { get; set; }         //Id сотрудника
        public virtual Employee Employee { get; set; }
        public int NumberWorkBook { get; set; }     //Номер трудовой книги
        public DateTime DateIssue { get; set; }     //Дата выдачи трудовой книги
        public int WorkExperience { get; set; }     //Трудовой стаж
        public int NumberTaxpayer { get; set; }     //Номер налогоплательщик
        public int PensionNumber { get; set; }      //Пенсионный номер
        public virtual List<Decree> Decrees { get; set; }   //Лист приказов
    }
}
