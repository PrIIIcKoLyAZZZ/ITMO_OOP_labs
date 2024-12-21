using Application.Contexts;

namespace Presentation.Scenarios;

public interface IScenario
{
    public string Name { get; }

    public IScenario Run(Context context);
}