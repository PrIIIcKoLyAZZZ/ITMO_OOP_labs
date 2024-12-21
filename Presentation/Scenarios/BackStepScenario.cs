using Application.Contexts;

namespace Presentation.Scenarios;

public class BackStepScenario : IScenario
{
    public string Name => "back";

    public IScenario Run(Context context)
    {
        return this;
    }
}