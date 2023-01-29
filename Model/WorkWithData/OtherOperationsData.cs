using HR_Department.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department.Model.WorkWithData
{
    public class OtherOperationsData
    {
        //Получаем все кафедры
        public static List<Department> GetAllDepartments()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var result = db.Departments.ToList();
                return result;
            }
        }
        //Получаем всех сотрудников
        public static List<Employee> GetAllEmployees()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var result = db.Employees.ToList();
                return result;
            }
        }
    }
}
