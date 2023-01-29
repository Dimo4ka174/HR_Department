using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Passport
    {
        //TODO: Настроить свять между таблицами паспорт и сотрудник (так де как и в классе EmployeeContext)
        //Паспорт
        [Key]                       //показывает, то это первичный ключ
        [ForeignKey("Employee")]    //так как книга подчиненная указываем, что это свойство внешний ключ
        public long Id { get; set; }            //id
        public string FirstName { get; set; }   //Имя
        public string MidleName { get; set; }   //Отчество
        public string LastName { get; set; }    //Фамилия
        public int NumberAndSeries { get; set; }//Номер и серия паспорта
        public DateTime DateOfIssue { get; set; }//Дата выдачи
        public virtual Employee Employee { get; set; }//связь 1 к 1
    }
}
