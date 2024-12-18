using CsvHandler;

namespace TinyXVA
{
	class Program
	{
		static void Main(string[] args)
		{ 
			// const string filepath = @"/Users/lack/Code/TestingMaterials/testWrite.csv";	
			string[] randomNumbers = StandardGaussianNumberGenerator.DrawSamples(43).Select(a => a.ToString()).ToArray();
			Console.WriteLine(String.Join(",", randomNumbers));
		}
	}	
}

