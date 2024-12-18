
using System;

namespace CsvHandler
{
	public class CsvWriter
	{
		public static bool WriteCsv(string filepath, Dictionary<string, double[]> values)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(filepath))
				{
					foreach (string key in values.Keys)
						sw.WriteLine($"{key},{String.Join(",", values[key])}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Failed to write csv: {e.Message}");	
				return false;
			}

			return true;
		}
	}

	public class CsvReader
	{
		// this method assumes the values can be converted to doubles
		public static bool ReadCsv(string filepath, out Dictionary<string, double[]> values)
		{

			values = new Dictionary<string, double[]>();

			if (!File.Exists(filepath))	
			{
				Console.WriteLine("File doesn't exist.");
				return false;
			}	
			
			try
			{
				using (StreamReader sr = new StreamReader(filepath))
				{

					while (!sr.EndOfStream)
					{
						string[] rawValues = sr.ReadLine().Split(',');
						string key = rawValues[0];
						
						values.Add(key, rawValues.Skip(1).Select(a => Double.Parse(a)).ToArray());

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine($"Failed to read file: {e.Message}."); 
				return false;
			}

			return true;
		}
	}
}
