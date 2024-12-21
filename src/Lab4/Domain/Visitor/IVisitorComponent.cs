namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;

public interface IVisitorComponent
{
    void Accept(IVisitor visitor);
}