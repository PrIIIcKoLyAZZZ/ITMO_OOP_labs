namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;

public interface IVisitor
{
    void Visit(IVisitorComponent component);
}