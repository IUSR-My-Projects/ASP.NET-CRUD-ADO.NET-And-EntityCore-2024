using Microsoft.Data.SqlClient;

namespace MuhmadOmarHajHamdo.Models.Repositories;

public class EmployeeRepository
{
    public static List<Employee> Employees = new List<Employee>();

    public bool CheckUniquePhoneNumber(string phoneNumber)
    {
        SqlCommand sqlCommand = new SqlCommand("SELECT count(*) FROM Employees WHERE PhoneNumber = @PhoneNumber");
        sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
        GlobalVariables.SqlConnection.Open();
        Int32 count = (Int32)sqlCommand.ExecuteScalar();
        GlobalVariables.SqlConnection.Close();

        if (count == 1)
        {
            return false;
        }

        return true;
    }

    /**
     * Get All Employees from database
     */
    public List<Employee> GetAllEmployees()
    {
        try
        {
            using SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees", GlobalVariables.SqlConnection);
            GlobalVariables.SqlConnection.Open();
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Employees.Add(_ConvertDataReaderToEmployee(sqlDataReader));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error from GetAllEmployees", ex);
        }
        finally
        {
            GlobalVariables.SqlConnection.Close();
        }

        return Employees;
    }

    /**
     * Get Employee by Id
     */
    public Employee? GetEmployeeById(int id)
    {
        return Employees.Find(e => e.Id == id);
    }


    private Employee _ConvertDataReaderToEmployee(SqlDataReader sqlDataReader)
    {
        return new Employee((int)sqlDataReader["Id"], (string)sqlDataReader["Name"],
            (DateTime)sqlDataReader["BirthYear"],
            (string)sqlDataReader["PhoneNumber"]);
    }
}