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
        public IEnumerable<Employee> GetAllEmployees
        {
            get
            {
                List<Employee> employees = new List<Employee>();
                string cs = ConfigurationManager.ConnectionStrings["DBMS"].ConnectionString;

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

                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }
    }
}
