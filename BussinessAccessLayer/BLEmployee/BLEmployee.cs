using BussinessAccessLayer.Interface;
using SMSAPI1.DBAccess;
using SMSAPI1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.BLEmployee
{
    public class BLEmployee:IEmployee
    {
        EmployeeDbAccess employeeDb = new EmployeeDbAccess();
        public async Task<List<Employee>> GetEmployees()
        {
            return employeeDb.GetEmployees();
        }
        public async Task<string> CreateEmployees(Employee emp)
        {
            return employeeDb.CreateEmployees(emp);
        }
        public async Task<string> DeleteEmployees(int id)
        {
            return employeeDb.DeleteEmployees(id);
        }
        public async Task<string> UpdateEmployee(Employee emp)
        {
            return employeeDb.UpdateEmployee(emp);
        }
        }
}
