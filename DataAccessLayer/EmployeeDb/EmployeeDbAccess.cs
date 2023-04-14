using SMSAPI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SMSAPI1.DBAccess
{
    public class EmployeeDbAccess
    {
        public ConnectDb db = new ConnectDb();
        public List<Employee> GetEmployees()
        {
            SqlCommand cmd = new SqlCommand("sp_get_employee", db.connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (db.connection.State == System.Data.ConnectionState.Closed)
                db.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Employee> lstEmployees = new List<Employee>();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.Id = (int)dr["Id"];
                emp.Name = dr["Name"].ToString();
                emp.Email = dr["Email"].ToString();
                emp.Gender = dr["Gender"].ToString();
                emp.Mobile = dr["Mobile"].ToString();
                emp.Address = dr["Address"].ToString();
                emp.EmpCode = dr["Emp_Code"].ToString();
                emp.Salary = Convert.ToDecimal(dr["Salary"]);
                lstEmployees.Add(emp);

            }
            db.connection.Close();
            return lstEmployees;
        }
        public string CreateEmployees(Employee emp)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert_employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);

                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return message;
        }
        public string DeleteEmployees(int id)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_delete_Employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@id", id);

                int i = (int)cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return message;

        }
        public string UpdateEmployee(Employee emp)
        {
            string message = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("sp_update_employees", db.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (db.connection.State == System.Data.ConnectionState.Closed)
                    db.connection.Open();

                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);

                int i = (int)cmd.ExecuteScalar();
                if (i == 1)
                {
                    message = "ok";
                }
                else
                {
                    message = "fail";
                }
                db.connection.Close();
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return message;
        }
    }
}