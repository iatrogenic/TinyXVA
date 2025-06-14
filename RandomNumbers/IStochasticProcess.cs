namespace TinyXVA.RandomNumbers;

public interface IStochasticProcess
{
    public double[] TimeValues { get; }
    public Dictionary<double, double> Simulate();
}