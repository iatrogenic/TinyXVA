using System;
using System.Numerics;

namespace TinyXVA;

public class StandardGaussianNumberGenerator
{
   public static double[] DrawSamples(int sampleSize)
   {
     var random = new Random();
     var values = new List<double>();
     
     int iterations = sampleSize % 2 == 0 ? sampleSize/2 : sampleSize/2 + 1;
     
     for (int i = 0; i < iterations; i++)
     {
         const double maxValue = 1000000;

         double val1 = random.Next((int)Math.Ceiling(maxValue)) / maxValue;
         double val2 = random.Next( (int)Math.Ceiling(maxValue)) / maxValue;

         double element1 = Math.Sqrt(-2 * Math.Log(val1)) * Math.Cos(2 * Math.PI * val2);
         double element2 = Math.Sqrt(-2 * Math.Log(val1)) * Math.Sin(2 * Math.PI * val2); 
         
         values.Add(element1); 
         values.Add(element2);
     }
     
     return values.Slice(0, sampleSize).ToArray();
   }
}