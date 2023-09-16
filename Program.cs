// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.Common;
using MySql;
using MySqlBuilder;
using MySqlConnector;

var connectionStringBuilder = new MySqlConnectionStringBuilder()
{
    Database = "andreyc253",
    Server = "db4free.net",
    Port = 3306,
    UserID = "andreyc253",
    Password = "faeeb003",
};

var connectionString = connectionStringBuilder.ConnectionString;

using (var mySqlConnection = new MySqlConnection(connectionString))
{
    mySqlConnection.Open();
    var command = mySqlConnection.CreateCommand();
    command.CommandType = CommandType.Text;
    command.CommandText = @"SELECT *
                            FROM `Workers`";
    var result = command.ExecuteReader();
    
    foreach (var column in result.GetColumnSchema())
    {
        Console.Write("---");
        Console.Write(column.ColumnName);
        Console.Write("---");
    }
    Console.WriteLine();

    var isNextDataAvailable = result.HasRows;
    result.Read();

    while (isNextDataAvailable)
    {
        for (var counter = 0; counter < result.FieldCount; counter++)
        {
            Console.Write("---");
            Console.Write(result.GetValue(counter));
            Console.Write("---");  
        }
        Console.WriteLine();
        isNextDataAvailable = result.Read();
    }
}


Console.WriteLine("Hello, World!");

