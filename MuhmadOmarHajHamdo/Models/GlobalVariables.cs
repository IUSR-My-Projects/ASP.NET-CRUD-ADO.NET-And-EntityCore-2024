using Microsoft.Data.SqlClient;

namespace MuhmadOmarHajHamdo.Models;

public class GlobalVariables
{
    private static readonly string ConnectionString =
        "Server=localhost;Database=MuhmadOmar;Trusted_Connection=True;TrustServerCertificate=True;";

    public static SqlConnection SqlConnection = new SqlConnection(ConnectionString);
}