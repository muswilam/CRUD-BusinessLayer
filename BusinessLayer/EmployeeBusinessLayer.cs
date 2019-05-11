using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;
        public IEnumerable<Employee> GetAllEmployees
        {
            get
            {
                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = (Int32)rdr["Id"];
                        employee.Name = (string)rdr["Name"];
                        employee.Gender = (string)rdr["Gender"];
                        employee.City = (string)rdr["City"];
                        employee.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                        employee.Email =rdr["Email"].ToString();
                        employee.Password =rdr["Password"].ToString();

                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlParameter parName = new SqlParameter();
                parName.ParameterName = "@Name";
                parName.Value = employee.Name;
                cmd.Parameters.Add(parName);

                SqlParameter parGender = new SqlParameter();
                parGender.ParameterName = "@Gender";
                parGender.Value = employee.Gender;
                cmd.Parameters.Add(parGender);

                SqlParameter parCity = new SqlParameter();
                parCity.ParameterName = "@City";
                parCity.Value = employee.City;
                cmd.Parameters.Add(parCity);

                SqlParameter parDateOfBirth = new SqlParameter();
                parDateOfBirth.ParameterName = "@DateOfBirth";
                parDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(parDateOfBirth);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@Email";
                parEmail.Value = employee.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@Password";
                parPassword.Value = employee.Password;
                cmd.Parameters.Add(parPassword);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@Id";
                parId.Value = id;
                cmd.Parameters.Add(parId);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@id";
                parId.Value = employee.Id;
                cmd.Parameters.Add(parId);

                SqlParameter parName = new SqlParameter();
                parName.ParameterName = "@Name";
                parName.Value = employee.Name;
                cmd.Parameters.Add(parName);

                SqlParameter parGender = new SqlParameter();
                parGender.ParameterName = "@Gender";
                parGender.Value = employee.Gender;
                cmd.Parameters.Add(parGender);

                SqlParameter parCity = new SqlParameter();
                parCity.ParameterName = "@City";
                parCity.Value = employee.City;
                cmd.Parameters.Add(parCity);

                SqlParameter parDateOfBirth = new SqlParameter();
                parDateOfBirth.ParameterName = "@DateOfBirth";
                parDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(parDateOfBirth);

                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@Email";
                parEmail.Value = employee.Email;
                cmd.Parameters.Add(parEmail);

                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@Password";
                parPassword.Value = employee.Password;
                cmd.Parameters.Add(parPassword);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EmployeeDetails(int id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                List<Employee> employees = new List<Employee>();
                SqlCommand cmd = new SqlCommand("spEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //continue details functionality 
                while(rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = id;
                    employee.Name = (string)rdr["Name"];
                    employee.Gender =(string)rdr["Gender"];
                    employee.City = (string)rdr["City"];
                    employee.DateOfBirth = (DateTime)rdr["DateOfBirth"];
                    employee.Email = (string)rdr["Email"];
                    employee.Password = (string)rdr["Password"];

                    employees.Add(employee);
                }
            }

        }

    }
}
