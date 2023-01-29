using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class WorkBook
    {
        //Трудовая книга
        [Key]                       //показывает, то это первичный ключ
        [ForeignKey("Employee")]    //так как книга подчиненная указываем, что это свойство внешний ключ
        public long Id { get; set; }                 //Id трудовой книги
        public int NumberWorkBook { get; set; }     //Номер трудовой книги
        public DateTime DateIssue { get; set; }     //Дата выдачи трудовой книги
        public int WorkExperience { get; set; }     //Трудовой стаж
        public int NumberTaxpayer { get; set; }     //Номер налогоплательщик
        public int PensionNumber { get; set; }      //Пенсионный номер
        public string Post { get; set; }            //Должность 
        public string Rank { get; set; }            //Степень/звание 
        public string GovernmentAwards { get; set; } //Правительственные награды
        public virtual List<Decree> Decrees { get; set; }   //Лист приказов связь 1 к М
        public virtual Employee Employee { get; set; }  //Связь 1 к 1 к работнику
    }
}
