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
        Employees.Clear();
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


    /**
     * Add Employee to database
     */
    public void CreateEmployee(IFormCollection collection)
    {
        Employee employee = _ConvertCollectionToEmployee(collection);
        try
        {
            using SqlCommand sqlCommand =
                new SqlCommand(
                    "INSERT INTO Employees ([Name], [BirthYear], [PhoneNumber]) VALUES (@Name, @BirthYear, @PhoneNumber)",
                    GlobalVariables.SqlConnection);
            sqlCommand.Parameters.AddWithValue("@Name", employee.Name);
            sqlCommand.Parameters.AddWithValue("@BirthYear", employee.BirthYear);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            GlobalVariables.SqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            Employees.Add(employee);
        }
        catch (Exception ex)
        {
            throw new Exception("Error from CreateEmployee", ex);
        }
        finally
        {
            GlobalVariables.SqlConnection.Close();
        }
    }


    private Employee _ConvertDataReaderToEmployee(SqlDataReader sqlDataReader)
    {
        return new Employee((int)sqlDataReader["Id"], (string)sqlDataReader["Name"],
            (string)sqlDataReader["BirthYear"],
            (string)sqlDataReader["PhoneNumber"]);
    }


    private Employee _ConvertCollectionToEmployee(IFormCollection collection)
    {
        string name = collection["Name"];
        string birthYear = collection["BirthYear"];
        string phoneNumber = collection["PhoneNumber"];

        return new Employee(id: 0, name: name, birthYear: birthYear, phoneNumber: phoneNumber);
    }
}