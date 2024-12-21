using Application.Contexts;

namespace Presentation.Scenarios;

public class ExitScenario : IScenario
{
    public string Name => "Exit";

    public IScenario Run(Context context)
    {
        return this;
    }
}