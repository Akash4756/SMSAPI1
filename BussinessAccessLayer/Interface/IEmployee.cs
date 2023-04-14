using SMSAPI1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessAccessLayer.Interface
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();
        Task<string> CreateEmployees(Employee emp);
        Task<string> DeleteEmployees(int id);
        Task<string> UpdateEmployee(Employee emp);



    }
}
