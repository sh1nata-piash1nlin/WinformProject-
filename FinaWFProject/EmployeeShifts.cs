using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaWFProject
{
    internal class EmployeeShifts
    {
        MY_DB mydb = new MY_DB();

        // ASSIGN SHIFT TO EMPLOYEE
        public bool AssignShift(int employeeID, int shiftID, string role)
        {
            // Rule: Ensure that two managers are not in the same shift
            if (role == "Quản lý" && IsManagerAlreadyAssigned(shiftID))
            {
                return false; // Manager cannot be assigned
            }

            SqlCommand command = new SqlCommand("INSERT INTO EmployeeShifts (EmployeeID, ShiftID, Role, CheckIn, CheckOut) VALUES (@empID, @shiftID, @role, NULL, NULL)", mydb.getConnection);
            command.Parameters.Add("@empID", SqlDbType.Int).Value = employeeID;
            command.Parameters.Add("@shiftID", SqlDbType.Int).Value = shiftID;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // REMOVE EMPLOYEE FROM SHIFT
        public bool RemoveFromShift(int employeeID, int shiftID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM EmployeeShifts WHERE EmployeeID=@empID AND ShiftID=@shiftID", mydb.getConnection);
            command.Parameters.Add("@empID", SqlDbType.Int).Value = employeeID;
            command.Parameters.Add("@shiftID", SqlDbType.Int).Value = shiftID;

            mydb.openConnection();
            int result = command.ExecuteNonQuery();
            mydb.closeConnection();

            return result > 0;
        }

        // GET ALL SHIFTS FOR AN EMPLOYEE
        public DataTable GetShiftsForEmployee(int employeeID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM EmployeeShifts WHERE EmployeeID=@empID", mydb.getConnection);
            command.Parameters.Add("@empID", SqlDbType.Int).Value = employeeID;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        // CHECK IF A SHIFT ALREADY HAS A MANAGER
        private bool IsManagerAlreadyAssigned(int shiftID)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM EmployeeShifts WHERE ShiftID=@shiftID AND Role='Quản lý'", mydb.getConnection);
            command.Parameters.Add("@shiftID", SqlDbType.Int).Value = shiftID;

            mydb.openConnection();
            int count = (int)command.ExecuteScalar();
            mydb.closeConnection();

            return count > 0; // True if a manager is already assigned
        }
    }
}
