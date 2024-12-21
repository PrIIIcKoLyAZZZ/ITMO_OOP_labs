namespace Application.Builder;

public interface IBuilder<out T>
{
    public T Build();
}