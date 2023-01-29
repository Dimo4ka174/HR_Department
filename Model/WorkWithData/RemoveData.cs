using HR_Department.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model.WorkWithData
{
    public class RemoveData
    {
        /// <summary>
        /// Удаление кафедры
        /// </summary>
        /// <param name="department">Кафедра</param>
        /// <returns></returns>
        public static string DeleteDepartment(Department department)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Departments.Remove(department);
                db.SaveChanges();
                return "Кафедра удалена!";
            }            
        }
        /// <summary>
        /// Удаление сотрудника со всеми документами
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <param name="workBook">Трудовая книга</param>
        /// <param name="passport">Пасспорт</param>
        /// <returns></returns>
        public static string DeleteEmployee(Employee employee, WorkBook workBook, Passport passport)
        {
            string result = "Такого сотрудника не существует";
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                //Решаем проблему с тем, что я могу указать чужой паспорт/трудовую
                bool checkPassport = employee.PassportId == passport.Id;
                bool checkWorkBook = employee.WorkBookId == workBook.Id;
                //Проверка на существование
                bool checkIsExist = db.Passports.Any(el => el.NumberAndSeries == passport.NumberAndSeries);
                if (checkPassport && checkWorkBook && checkIsExist)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    db.WorkBooks.Remove(workBook);
                    db.SaveChanges();
                    db.Passports.Remove(passport);
                    db.SaveChanges();
                    result = "Сотрудник удален, вместе со всеми данными";
                }
            }
            return result;
        }
        /// <summary>
        /// Удаление приказа
        /// </summary>
        /// <param name="decree">Приказ</param>
        /// <returns></returns>
        public static string DeleteDecree(Decree decree)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                db.Decrees.Remove(decree);
                db.SaveChanges();
                return "Приказ удален!";
            }            
        }
    }
}
