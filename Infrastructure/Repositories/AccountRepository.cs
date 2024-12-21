using Application.Abstractions;
using Application.Accounts;
using Application.ResultTypes;
using Application.ValueObjects;
using Npgsql;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString;

    public AccountRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public GetAccountResult GetById(int id)
    {
        string query = @"SELECT * FROM accounts WHERE id = @id";
        var command = new NpgsqlCommand(query);

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        command.Parameters.AddWithValue("@id", id);
        command.Connection = connection;

        try
        {
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            return new GetAccountResult.Success(new BankAccount(new Id(reader.GetInt32(0)), new PinCode(reader.GetInt32(1)), new Money(reader.GetDouble(2))));
        }
        catch (Exception e)
        {
            return new GetAccountResult.AccountNotFound(e);
        }
    }

    public void UpdateMoney(int id, double money)
    {
        string query = @"UPDATE accounts SET balance = @money WHERE id = @id";
        var command = new NpgsqlCommand(query);

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        command.Parameters.AddWithValue("@money", money);
        command.Parameters.AddWithValue("@id", id);

        command.Connection = connection;

        command.ExecuteNonQuery();
    }

    public int Create(PinCode pinCode)
    {
        string query = @"INSERT INTO accounts (pin_code, balance) VALUES (@pin_code, @balance) RETURNING id";
        var command = new NpgsqlCommand(query);

        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        command.Parameters.AddWithValue("@pin_code", pinCode.Value);
        command.Parameters.AddWithValue("@balance", 0);

        command.Connection = connection;

        object? result = command.ExecuteScalar();

        if (result == DBNull.Value)
            return 0;

        int id = Convert.ToInt32(result);

        return id;
    }
}