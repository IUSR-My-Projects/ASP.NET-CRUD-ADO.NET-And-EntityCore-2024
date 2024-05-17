using Microsoft.Data.SqlClient;

namespace MuhmadOmarHajHamdo.Models.Repositories;

public class EmployeeRepository
{
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
        List<Employee> employees = new List<Employee>();
        try
        {
            using SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees", GlobalVariables.SqlConnection);
            GlobalVariables.SqlConnection.Open();
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                employees.Add(_ConvertDataReaderToEmployee(sqlDataReader));
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

        return employees;
    }

    /**
     * Get Employee by Id
     */
    public Employee? GetEmployeeById(int id)
    {
        Employee employee = null;
        try
        {
            using SqlCommand sqlCommand =
                new SqlCommand("SELECT * FROM Employees WHERE Id = @Id", GlobalVariables.SqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            GlobalVariables.SqlConnection.Open();
            using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                employee = _ConvertDataReaderToEmployee(sqlDataReader);
            }

            return employee;
        }
        catch (Exception ex)
        {
            throw new Exception("Error from GetEmployeeById", ex);
        }
        finally
        {
            GlobalVariables.SqlConnection.Close();
        }
    }


    private Employee _ConvertDataReaderToEmployee(SqlDataReader sqlDataReader)
    {
        return new Employee((int)sqlDataReader["Id"], (string)sqlDataReader["Name"],
            (DateTime)sqlDataReader["BirthYear"],
            (string)sqlDataReader["PhoneNumber"]);
    }
}