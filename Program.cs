using CsvHandler;
using TinyXVA.RandomNumbers;

namespace TinyXVA
{
	class Program
	{
		static void Main(string[] args)
		{ 
			// const string filepath = @"/Users/lack/Code/TestingMaterials/testWrite.csv";	
			const int numOfPoints = 750;
			double[] timeVals = new double[numOfPoints];
			for (int i =0; i < timeVals.Length; i++)
				timeVals[i] =  1.0/numOfPoints * i;
			
			var hestonModel = new HestonModelGenerator(0.5, 0.16, 0.2, timeVals, 0.4);
			var monteCarloTest = new MonteCarloSimulation(hestonModel);
			monteCarloTest.GenerateTrajectories(10);
			var testing = monteCarloTest.SimulatedTrajectories;
			Console.WriteLine("Testing.");
			// Dictionary<double, double> gbmRealization = hestonModel.Simulate();
			// Console.WriteLine(String.Join(";", gbmRealization.Values));
		}
	}	
}

