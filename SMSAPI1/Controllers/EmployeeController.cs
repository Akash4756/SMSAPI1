using BussinessAccessLayer.BLEmployee;
using BussinessAccessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSAPI1.DBAccess;
using SMSAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        //BLEmployee employeeDb = new BLEmployee();

        ApiResponse response = new ApiResponse();
        IEmployee employeeDb;
        public EmployeeController(IEmployee _employeedb)
        {
            employeeDb = _employeedb;
        }

        [Route("GetEmployees")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var emps = await employeeDb.GetEmployees();
                response.Ok = true;
                response.Message = $"Total {emps.Count} Record fetch Successfully.";
                response.Data = emps;
            }
            catch (Exception ex)
            {
                //WriteLog
                response.Ok = false;
                response.Message = ex.Message;
            }
            
            return Ok(response);
        }
        [Route("PostEmployee")]
        [HttpPost]
        public async Task<IActionResult> PostEmployee(Employee data)
        {
            try
            {
                var res = await employeeDb.CreateEmployees(data);
                if(res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee created Successfully.";
                }
                else if(res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Employee email already exist. ";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }
                
            }
            catch (Exception ex)
            {
                //WriteLog
                response.Ok = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        [Route("DeleteEmployee")]
        [HttpGet]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            try
            {
                var res = await employeeDb.DeleteEmployees(id);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee deleted Successfully.";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Something went wrong. ";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }

            }
            catch (Exception ex)
            {
                //WriteLog
                response.Ok = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        [Route("UpdateEmployee")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
                var res = await employeeDb.UpdateEmployee(employee);
                if (res == "ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee updated Successfully.";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }

            }
            catch (Exception ex)
            {
                //WriteLog
                response.Ok = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
