using Application.Contexts;
using Presentation.Scenarios;
using Spectre.Console;

namespace Presentation;

public class ScenarioRunner
{
    private readonly IScenario _startScenario;
    private readonly Context _context;

    private IScenario _previosScenario;
    private IScenario _actualScenario;

    public ScenarioRunner(IScenario startScenario)
    {
        _startScenario = startScenario;
        _actualScenario = _startScenario;
        _previosScenario = _startScenario;
        _context = new Context();
    }

    public void Run()
    {
        while (true)
        {
            AnsiConsole.Clear();

            _previosScenario = _actualScenario;
            _actualScenario = _actualScenario.Run(_context);

            if (_actualScenario is ExitScenario)
            {
                break;
            }

            if (_actualScenario is BackStepScenario)
            {
                _actualScenario = _previosScenario;
            }

            if (_actualScenario is StartScenario)
            {
                _actualScenario = _startScenario;
            }
        }
    }
}