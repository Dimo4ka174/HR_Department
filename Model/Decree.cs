using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model
{
    public class Decree
    {
        public int Id { get; set; }
        public int NumberDecree { get; set; }       //Номер приказа
        public DateTime DateBegin { get; set; }     //Дата приказа
        public string Action { get; set; }          //Содержание (действие)
        public virtual WorkBook WorkBook { get; set; }
    }
}
