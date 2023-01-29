using HR_Department.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model.WorkWithData
{
    public class EditData
    {
        /// <summary>
        /// Изменение кафедры
        /// </summary>
        /// <param name="oldDepartment">Кафедра которую нужно изменить</param>
        /// <param name="newName">Новое название кафедры</param>
        /// <param name="newSpecialization">Новая специализация</param>
        /// <returns></returns>
        public static string EditDepartment(Department oldDepartment, string newName, string newSpecialization)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //TODO: Нужно ли (params Employee[] newEmployees)? Если не здесь, но нужен метод по удалению/добавлению сотрудников на кафедру
                //Находим кафедру, которая уже записана в БД
                Department department = db.Departments.FirstOrDefault(d => d.Id == oldDepartment.Id);
                department.Name = newName;                          //меняем ей название
                department.Specialization = newSpecialization;      //меняем ей специализацию
                db.SaveChanges();
                return $"Отдел {department.Name} изменен!";
            }
        }
        /// <summary>
        /// Метод изменяет данные паспорта
        /// </summary>
        /// <param name="oldPassport">Старый паспорт</param>
        /// <param name="newFirstName">Имя</param>
        /// <param name="newMidleName">Отчество</param>
        /// <param name="newLastName">Фамилия</param>
        /// <param name="newNumberAndSeries">Номер и серия</param>
        /// <returns></returns>
        public static string EditPassport(Passport oldPassport, string newFirstName, string newMidleName, string newLastName, int newNumberAndSeries)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Находим пспорт, который уже записана в БД
                Passport passport = db.Passports.FirstOrDefault(d => d.Id == oldPassport.Id);
                passport.FirstName = newFirstName;              //меняем имя
                passport.LastName = newLastName;                //меняем фамиилю
                passport.MidleName = newMidleName;              //меняем отчесвто
                passport.NumberAndSeries = newNumberAndSeries;  //меняем серию и номер
                db.SaveChanges();
                return $"Паспорт изменен!";
            }
        }
        /// <summary>
        /// Метод изменяет данные трудовой книги
        /// </summary>
        /// <param name="oldWorkBook">Старая трудовая книга</param>
        /// <param name="newNumberWorkBook">Номер трудовой книги</param>
        /// <param name="newDateIssue">Дата выдачи трудовой книги</param>
        /// <param name="newWorkExperience">Трудовой стаж</param>
        /// <param name="newNumberTaxpayer">Номер налогоплательщик (ИНН)</param>
        /// <param name="newPensionNumber">Пенсионный номер</param>
        /// <returns></returns>
        public static string EditWorkBook(WorkBook oldWorkBook, int newNumberWorkBook, DateTime newDateIssue, int newWorkExperience, int newNumberTaxpayer, int newPensionNumber)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //TODO: Нужно ли (params Decree[] decrees)? Если не здесь, но нужен метод по удалению/добавлению приказов в трудовую
                //Находим трудовую, которая уже записана в БД
                WorkBook workBook = db.WorkBooks.FirstOrDefault(d => d.Id == oldWorkBook.Id);
                workBook.NumberWorkBook = newNumberWorkBook;    //меняем Номер
                workBook.DateIssue = newDateIssue;              //меняем Дату выдачи 
                workBook.WorkExperience = newWorkExperience;    //меняем Трудовой стаж
                workBook.NumberTaxpayer = newNumberTaxpayer;    //меняем ИНН
                workBook.PensionNumber = newPensionNumber;      //меняем Пенсионный номер
                db.SaveChanges();
                return $"Трудовая книга изменена!";
            }
        }
        /// <summary>
        /// Метод изменяет приказ
        /// </summary>
        /// <param name="oldDecree">Старый приказ</param>
        /// <param name="newNumberDecree">Новый номер приказа</param>
        /// <param name="newDateBegin">Новая дата приказа</param>
        /// <param name="newAction">Новое содержание (действие)</param>
        /// <returns></returns>
        public static string EditDecree(Decree oldDecree, int newNumberDecree, DateTime newDateBegin, string newAction)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Находим сотрудника, который уже записана в БД
                Decree decree = db.Decrees.FirstOrDefault(d => d.Id == oldDecree.Id);
                decree.NumberDecree = newNumberDecree;  //меняем номер приказа
                decree.DateBegin = newDateBegin;        //меняем дата приказа
                decree.Action = newAction;              //меняем содержание (действие)
                db.SaveChanges();
                return $"Приказ изменен!";
            }
        }
        /// <summary>
        /// Метод изменяет данные сотрудника
        /// </summary>
        /// <param name="oldEmployee">Старые данные сотрудника</param>
        /// <param name="newPosition">Новая должность</param>
        /// <param name="newRank">Новая степень/звание</param>
        /// <param name="newSubject">Новый предмет</param>
        /// <param name="newDepartment">Новая кафедра</param>
        /// <returns></returns>
        public static string EditEmployee(Employee oldEmployee, string newPosition, string newRank, string newSubject, Department newDepartment)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //TODO: Не уверен в изменении кафедры у сотрудника                
                //Находим сотрудника, который уже записана в БД
                Employee employee = db.Employees.FirstOrDefault(d => d.Id == oldEmployee.Id);
                employee.Position = newPosition;            //меняем должность
                employee.Rank = newRank;                    //меняем степень/звание
                employee.Subject = newSubject;              //меняем предмет
                employee.DepartmentId = newDepartment.Id;   //Не уверен, может (employee.Department = newDepartment;)?
                db.SaveChanges();
                return $"Данные сотрудника изменены!";
            }
        }        
    }
}
