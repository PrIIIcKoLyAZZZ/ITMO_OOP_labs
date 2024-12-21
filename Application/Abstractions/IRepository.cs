namespace Application.Abstractions;

public interface IRepository<out T>
{
    public T GetById(int id);
}