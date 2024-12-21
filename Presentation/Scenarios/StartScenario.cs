using Application.Contexts;

namespace Presentation.Scenarios;

public class StartScenario : IScenario
{
    public string Name => "start";

    public IScenario Run(Context context)
    {
        return this;
    }
}