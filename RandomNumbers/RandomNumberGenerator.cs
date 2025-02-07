namespace TinyXVA.RandomNumbers
{
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

                double val1 = random.Next((int)Math.Floor(maxValue)) / maxValue;
                double val2 = random.Next( (int)Math.Floor(maxValue)) / maxValue;

                double element1 = Math.Sqrt(-2 * Math.Log(val1)) * Math.Cos(2 * Math.PI * val2);
                double element2 = Math.Sqrt(-2 * Math.Log(val1)) * Math.Sin(2 * Math.PI * val2); 
         
                values.Add(element1); 
                values.Add(element2);
            }
     
            return values.Slice(0, sampleSize).ToArray();
        }
    }

    public class GeometricBrownianMotionGenerator(double drift, 
        double diffusion,
        double[] timeValues,
        double startingValue) : IStochasticProcess
    {
        public double Drift { get; } = drift;
        public double Diffusion { get; } = diffusion;
        public double[] TimeValues { get; } = timeValues;

        private readonly double _startingValue = startingValue;

        public Dictionary<double, double> Simulate()
        {
            double[] gaussianNumbers = StandardGaussianNumberGenerator.DrawSamples(TimeValues.Length-1);
            double[] realization = new double[TimeValues.Length];
            
            realization[0] = _startingValue;
            
            for (int i = 1; i < TimeValues.Length; i++)
            {
                double timeIncrement = TimeValues[i] - TimeValues[i - 1];
                double brownianIncrement = Diffusion * Math.Sqrt(timeIncrement) * gaussianNumbers[i-1];

                realization[i] = realization[i - 1] * Math.Exp( (Drift - Math.Pow(Diffusion,2)/2.0)*timeIncrement + brownianIncrement);
            }

            return TimeValues.Zip(realization).ToDictionary(a => a.First, a => a.Second);
        }
    }

    public class VasicekModelGenerator (double meanReversionSpeed,
        double longTermMean,
        double instantaneousVolatility,
        double startingValue,
        double[] timeValues) : IStochasticProcess
    {
        public double[] TimeValues { get; } = timeValues;

        private double _meanReversionSpeed = meanReversionSpeed;
        private readonly double _startingValue = startingValue;
        private double _longTermMean = longTermMean;
        private double _instantaneousVolatility = instantaneousVolatility;
        
        public Dictionary<double, double> Simulate()
        {
           double[] gaussianNumbers = StandardGaussianNumberGenerator.DrawSamples(TimeValues.Length-1);
           double[] realization = new double[TimeValues.Length];
           
           realization[0] = _startingValue;

           for (int i = 1; i < TimeValues.Length; i++)
           {
               double timeIncrement = TimeValues[i] - TimeValues[i - 1];
               double brownianIncrement = _instantaneousVolatility * Math.Sqrt(timeIncrement) * gaussianNumbers[i - 1];
               
               realization[i] = _meanReversionSpeed * (_longTermMean - realization[i-1])*timeIncrement + brownianIncrement;
           }
           
           return TimeValues.Zip(realization).ToDictionary(a => a.First, a => a.Second);
        }
    }
}