using System.Data.SqlClient;

namespace ConnectionDb;

public class Provider
{
    private static readonly string connectionString = "Data Source =ANTONPC;Database=db_mcc81_versi2;Connect Timeout=30;Integrated Security=True";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public static SqlCommand GetCommand()
    {
        return new SqlCommand();
    }

    public static SqlParameter SetParameter(string name, object value)
    {
        return new SqlParameter(name, value);
    }
}