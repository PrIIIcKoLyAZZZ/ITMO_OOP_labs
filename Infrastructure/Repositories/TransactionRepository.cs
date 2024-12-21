using Application.Abstractions;
using Application.ResultTypes;
using Application.ValueObjects;
using Npgsql;

namespace Infrastructure.Repositories;

public class TransactionRepository : ITransactionsRepository
{
    private readonly string _connectionString;

    public TransactionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public GetTransactionResult GetById(int id)
    {
        string query = "SELECT * FROM transactions WHERE account_id = @id";
        var command = new NpgsqlCommand(query);

        command.Parameters.AddWithValue("@id", id);

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var results = new List<IList<string>>();

        command.Connection = connection;
        NpgsqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            results.Add(new List<string>() { reader.GetString(2), reader.GetDouble(3).ToString() }.AsReadOnly());
        }

        return new GetTransactionResult.Success(results.AsReadOnly());
    }

    public void AddTransaction(Id accountId, string operationType, Money amount)
    {
        string query = @"INSERT INTO transactions (account_id, operation_type, amount) VALUES (@accountId, @operationType, @amount)";
        var command = new NpgsqlCommand(query);

        command.Parameters.AddWithValue("@accountId", accountId.Value);
        command.Parameters.AddWithValue("@operationType", operationType);
        command.Parameters.AddWithValue("@amount", amount.Value);

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        command.Connection = connection;
        command.ExecuteNonQuery();
    }
}