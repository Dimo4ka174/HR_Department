using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Employee
    {
        //TODO: Разобраться нужны ли поля id для каждой связи?
        //сотрудник
        public long Id { get; set; }                     //Id сотрудника
        public long DepartmentId { get; set; }           //Id его кафедры
        public long HR_DepartmentId { get; set; }        //Id кадров
        public long AccountingId { get; set; }           //Id Бухгалтерии
        public long WorkBookId { get; set; }             //Id трудовой книги
        public long PassportId { get; set; }             //Id паспорта
        public virtual Department Department { get; set; }      
        public virtual HR_Department HR_Department { get; set; }
        public virtual Accounting Accounting { get; set; }            
        public virtual WorkBook WorkBook { get; set; }
        public virtual Passport Passport { get; set; }
        public string Subject { get; set; }             //Предмет 
    }
}
