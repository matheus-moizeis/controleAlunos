using Dapper;
using Microsoft.Data.SqlClient;

namespace ControleAlunosMVC.Data;

public static class Database
{
    public static void CreateDatabase(string connectionDatabase, string nameDatabase)
    {
        using var myConnection = new SqlConnection(connectionDatabase);

        var parameters = new DynamicParameters();
        parameters.Add("name", nameDatabase);

        var registers = myConnection.Query("SELECT NAME FROM SYS.DATABASES WHERE NAME LIKE @name", parameters);

        if (!registers.Any())
        {
            myConnection.Execute($"CREATE DATABASE {nameDatabase}");
        }
    }
}
