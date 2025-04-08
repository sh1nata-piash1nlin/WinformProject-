using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaWFProject
{
    internal class EMPLOYEE
    {
        MY_DB mydb = new MY_DB();

        // ADD EMPLOYEE
        public bool AddEmployee(string fullName, string phone, string address)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Employees (FullName, Phone, Address) VALUES (@name, @phone, @address)", mydb.getConnection);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // UPDATE EMPLOYEE
        public bool UpdateEmployee(int id, string fullName, string phone, string address)
        {
            SqlCommand command = new SqlCommand("UPDATE Employees SET FullName=@name, Phone=@phone, Address=@address WHERE EmployeeID=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = fullName;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // DELETE EMPLOYEE
        public bool DeleteEmployee(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // GET EMPLOYEE BY ID
        public DataTable GetEmployeeByID(int id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        // GET ALL EMPLOYEES
        public DataTable GetAllEmployees()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Employees", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
