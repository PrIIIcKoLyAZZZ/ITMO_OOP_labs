using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Abstractions;

public interface ITransactionsRepository : IRepository<GetTransactionResult>
{
    public void AddTransaction(Id accountId, string operationType, Money amount);
}