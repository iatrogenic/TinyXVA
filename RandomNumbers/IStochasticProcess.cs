namespace TinyXVA.RandomNumbers;

public interface IStochasticProcess
{
    public Dictionary<double, double> Simulate();
}