using System.Collections.ObjectModel;

namespace Application.ResultTypes;

public abstract record GetTransactionResult
{
    public sealed record Success(ReadOnlyCollection<IList<string>> TransactionList) : GetTransactionResult();

    public sealed record Fall() : GetTransactionResult();
}