using Npgsql;

namespace Infrastructure.Migrations;

public class MigrationWorker
{
    public static void SqlUP(string connectionString)
    {
        var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();
            string createTableQuery = """
                    CREATE TABLE IF NOT EXISTS accounts (
                    id SERIAL PRIMARY KEY,
                    pin_code INTEGER NOT NULL,
                    balance DOUBLE PRECISION NOT NULL
                );
                
                CREATE TABLE IF NOT EXISTS transactions (
                    id SERIAL PRIMARY KEY,
                    account_id INTEGER REFERENCES accounts(id) NOT NULL,
                    operation_type VARCHAR(12) NOT NULL,
                    amount DOUBLE PRECISION NOT NULL
                );
                """;

            var command = new NpgsqlCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public static void SqlDown(string connectionString)
    {
        var connection = new NpgsqlConnection(connectionString);

        try
        {
            connection.Open();

            string dropTableQuery = """
            DROP TABLE IF EXISTS transactions;
            DROP TABLE IF EXISTS accounts;
        """;

            var command = new NpgsqlCommand(dropTableQuery, connection);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        finally
        {
            connection.Close();
        }
    }
}