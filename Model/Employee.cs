using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Employee
    {
        //сотрудник
        public int Id { get; set; }                     //Id сотрудника
        public int DepartmentId { get; set; }           //Id его кафедры
        public int HR_DepartmentId { get; set; }        //Id кадров
        public int AccountingId { get; set; }           //Id Бухгалтерии
        public int WorkBookId { get; set; }             //Id трудовой книги
        public int PassportId { get; set; }             //Id паспорта
        public virtual Department Department { get; set; }      
        public virtual HR_Department HR_Department { get; set; }
        public virtual Accounting Accounting { get; set; }            
        public virtual WorkBook WorkBook { get; set; }
        public virtual Passport Passport { get; set; }
        public string Position { get; set; }    //Должность
        public string Rank { get; set; }        //Степень
        public string Subject { get; set; }     //Предмет 
    }
}
