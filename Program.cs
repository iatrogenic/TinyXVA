using CsvHandler;
using TinyXVA.RandomNumbers;

namespace TinyXVA
{
	class Program
	{
		static void Main(string[] args)
		{ 
			// const string filepath = @"/Users/lack/Code/TestingMaterials/testWrite.csv";	
			double[] timeVals = new double[100];
			for (int i =0; i < 100; i++)
				timeVals[i] =  0.1 * i;
			
			GeometricBrownianMotionGenerator gbmGenerator = new GeometricBrownianMotionGenerator(0.1, 0.2, timeVals, 10);
			Dictionary<double, double> gbmRealization = gbmGenerator.Simulate();
			Console.WriteLine(String.Join(";", gbmRealization.Values));
		}
	}	
}

