using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Passport
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }     //Id сотрудника
        public virtual Employee Employee { get; set; }
        public string FirstName { get; set; }   //Имя
        public string MidleName { get; set; }   //Фамилия
        public string LastName { get; set; }    //Отчество
        public int NumberAndSeries { get; set; }//Номер и серия паспорта
    }
}
