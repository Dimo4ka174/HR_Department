using HR_Department.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model.WorkWithData
{
    public class CreateData
    {
        /// <summary>
        /// Cоздание кафедры
        /// </summary>
        /// <param name="name">Наименование кафедры</param>
        /// <param name="specialization">Специализация кафедры</param>
        /// <param name="employees">Список сотрудников кафедры (массив)</param>
        /// <returns></returns>
        public static string CreateDepartment(string name, string specialization, params Employee[] employees)
        {
            string result = "Кафедра уже существует";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //TODO: ?возможно нужно добавлять сотрудников в лист сотрудников? [Ниже в коде не уверен]
                //Проверка на существование кафедры
                bool checkIsExist = db.Departments.Any(el => el.Name == name); //Проверяем существоует ли уже кафедра с таким названием (true = да, существует)
                if (!checkIsExist)
                {
                    //Создаем кафедру
                    Department newDepartment = new Department
                    {
                        Name = name,
                        Specialization = specialization,
                        Employees = new List<Employee>(employees)   //Не уверен
                    };
                    db.Departments.Add(newDepartment);
                    db.SaveChanges();
                    result = $"Новая кафедра создана!";
                }
            }
            return result;
        }
        /// <summary>
        /// Создание паспорта
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="numberAndSeriesPass">Номер паспорта</param>
        /// <param name="firstName">Имя</param>
        /// <param name="midleName">Отчество</param>
        /// <param name="lastName">Фамилия</param>
        /// <returns></returns>
        public static string CreatePassport(Employee employee, int numberAndSeriesPass, string firstName, string midleName, string lastName)
        {
            string result = "Паспорт уже существует";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Проверка на существование паспорта
                bool checkIsExist = db.Passports.Any(el => el.NumberAndSeries == numberAndSeriesPass);
                if (!checkIsExist)
                {
                    //TODO: возможно нужно (Employee = employee,)
                    //Создаем паспорт сотрудника 
                    Passport newPassport = new Passport
                    {
                        EmployeeId = employee.Id,
                        FirstName = firstName,
                        MidleName = midleName,
                        LastName = lastName,
                        NumberAndSeries = numberAndSeriesPass
                    };
                    db.Passports.Add(newPassport);
                    db.SaveChanges();
                    result = $"Новый паспорт создан!";
                }
            }
            return result;
        }
        /// <summary>
        /// Создание трудовой книги
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="numberWorkBook">Номер трудовой книги</param>
        /// <param name="dateIssue">Дата выдачи трудовой книги</param>
        /// <param name="workExperience">Трудовой стаж</param>
        /// <param name="numberTaxpayer">ИНН</param>
        /// <param name="pensionNumber">Пенсионный счет</param>
        /// <param name="decrees">Список(массив) приказов</param>
        /// <returns></returns>
        public static string CreateWorkBook(Employee employee, int numberWorkBook, DateTime dateIssue, int workExperience, 
                                            int numberTaxpayer, int pensionNumber, params Decree[] decrees)
        {
            string result = "Трудовая книга уже существует";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Проверка на существование трудовой книги
                bool checkIsExist = db.WorkBooks.Any(el => el.NumberWorkBook == numberWorkBook);
                if (!checkIsExist)
                {
                    //TODO: возможно нужно (Employee = employee,)
                    //Создаем трудовой книги сотрудника 
                    WorkBook newWorkBook = new WorkBook
                    {
                        EmployeeId = employee.Id,
                        NumberWorkBook = numberWorkBook,
                        DateIssue = dateIssue,
                        WorkExperience = workExperience,
                        NumberTaxpayer = numberTaxpayer,
                        PensionNumber = pensionNumber,
                        Decrees = new List<Decree>(decrees) //Не уверен
                    };
                    db.WorkBooks.Add(newWorkBook);
                    db.SaveChanges();
                    result = $"Новая трудовая книга создана!";
                }
            }
            return result;
        }
        /// <summary>
        /// Создание нового приказа
        /// </summary>
        /// <param name="numberDecree">Номер пирказа кафедры</param>
        /// <param name="dateBegin">Дата приказа</param>
        /// <param name="actionText">Текст приказа</param>
        /// <returns></returns>
        public static string CreateDecree(int numberDecree, DateTime dateBegin, string actionText)
        {
            string result = "Приказ уже существует";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Проверка на существование кафедры
                bool checkIsExist = db.Decrees.Any(el => el.NumberDecree == numberDecree);
                if (!checkIsExist)
                {
                    Decree newDecree = new Decree
                    {
                        NumberDecree = numberDecree,
                        DateBegin = dateBegin,
                        Action = actionText
                    };
                    db.Decrees.Add(newDecree);
                    db.SaveChanges();
                    result = "Новый приказ создан!";
                }
            }
            return result;
        }
        /// <summary>
        /// Создание сотрудника
        /// </summary>        
        /// <param name="position">Должность</param>
        /// <param name="rank">Степень(Звание)</param>
        /// <param name="subject">Основной предмет</param>
        /// <param name="passport">Паспорт сотрудника</param>
        /// <param name="workBook">Трудовая книга сотрудника</param>
        /// <param name="department">Кафедра</param>
        /// <param name="hr_Department">Кадры</param>
        /// <param name="accounting">Бухгалтерия</param>
        /// <returns></returns>
        public static string CreateEmployee(string position, string rank, string subject, 
                                            Passport passport, WorkBook workBook, Department department, 
                                            HR_Department hr_Department, Accounting accounting )
        {
            string result = "Сотрудник уже создан!";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Проверка на существование сотрудника через его паспорт
                bool checkIsExist = db.Passports.Any(el => el.NumberAndSeries == passport.NumberAndSeries);
                if (!checkIsExist)
                {
                    //Создаем сотрудника
                    Employee newEmployee = new Employee
                    {
                        DepartmentId = department.Id,
                        HR_DepartmentId = hr_Department.Id,
                        AccountingId = accounting.Id,
                        WorkBookId = workBook.Id,
                        PassportId = passport.Id,
                        Position = position,
                        Rank = rank,
                        Subject = subject,
                    };
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                    result = $"Новый сотрудник создан!";
                }
            }
            return result;
        }        
    }
}
