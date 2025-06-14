namespace TinyXVA.RandomNumbers;

public class MonteCarloSimulation
{
    public double[] TimeValues { get; }
    public List<Dictionary<double,double>> SimulatedTrajectories { get; private set; }
    private IStochasticProcess _underlyingProcess;
    
    public MonteCarloSimulation(IStochasticProcess stochasticProcess)
    {
       _underlyingProcess = stochasticProcess;
       TimeValues = stochasticProcess.TimeValues;
    }

    public void GenerateTrajectories(int n)
    {
        var simulatedTrajectories = new List<Dictionary<double, double>>();
        Parallel.For(0, n, (i, state) =>
        { 
            var trajectory = _underlyingProcess.Simulate();
            simulatedTrajectories.Add(trajectory); 
        });

        SimulatedTrajectories = simulatedTrajectories;
    }

    public double AverageAtPoint(double timePoint)
    {
        double sum = 0;
        foreach(var trajectory in SimulatedTrajectories)
        {
            if (trajectory.TryGetValue(timePoint, out var value))
                sum += value;
            else
                throw new KeyNotFoundException();
        }
        return sum / SimulatedTrajectories.Count;
    }
}