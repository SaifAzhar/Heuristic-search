using System;
using System.Collections.Generic;
using System.Linq;

namespace ADS_Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create lorries with bricks
            List<Lorry> lorries = new List<Lorry>
            {
                new Lorry(1),
                new Lorry(2),
                new Lorry(3),
            };

            // Dataset of brick weights
            double[] brickWeights = { 3.287, 37.856, 14.348, 12.265, 54.674, 7.858, 82.594, 20.718, 37.189, 72.407,
                40.745, 48.012, 32.788, 12.917, 32.394, 89.51, 43.721, 4.681, 75.317, 41.391,
                53.623, 56.557, 95.49, 50.968, 18.41, 52.727, 80.214, 54.678, 92.533, 70.1 };

            // Randomly assign bricks to lorries
            Random random = new Random();
            foreach (var weight in brickWeights.OrderBy(x => random.NextDouble()))
            {
                int randomLorryIndex = random.Next(lorries.Count);
                lorries[randomLorryIndex].AddBrick(new Brick { Weight = weight });
            }

            // Create swapper and add lorries
            Swapper swapper = new Swapper(lorries);

            // Swap bricks until equal weight
            swapper.SwapBricksUntilEqualWeight();
        }
    }
}