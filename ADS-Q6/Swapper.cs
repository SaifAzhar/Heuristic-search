using System;
using System.Collections.Generic;
using System.Linq;

namespace ADS_Q6
{
    public class Swapper
    {
        public List<Lorry> Lorries { get; set; }

        public Swapper(List<Lorry> lorries)
        {
            Lorries = lorries;
        }

        public void SwapBricksUntilEqualWeight()
        {
            int maxIterations = 50;
            double targetWeight = Lorries[0].GetTotalWeight();
            double tolerance = 0.0001;

            int i; // Declare i outside the loop

            for (i = 0; i < maxIterations; i++)
            {
                // Swap bricks between lorries
                for (int j = 0; j < Lorries.Count; j++)
                {
                    // Check if both lorries have at least one brick
                    if (Lorries[j].Bricks.Count > 0 && Lorries[(j + 1) % Lorries.Count].Bricks.Count > 0)
                    {
                        Random random = new Random();
                        int randomIndexJ = random.Next(Lorries[j].Bricks.Count);

                        // Choose a random brick from the source lorry that is not already selected for swapping
                        int randomIndexOther = random.Next(Lorries[(j + 1) % Lorries.Count].Bricks.Count);

                        Brick temp = Lorries[j].Bricks[randomIndexJ];
                        Lorries[j].Bricks[randomIndexJ] = Lorries[(j + 1) % Lorries.Count].Bricks[randomIndexOther];
                        Lorries[(j + 1) % Lorries.Count].Bricks[randomIndexOther] = temp;
                    }
                }

                // Check if the lorries have weights within the tolerance
                if (Lorries.All(lorry => Math.Abs(lorry.GetTotalWeight() - targetWeight) < tolerance))
                {
                    break;
                }

                // Print weights of lorries and iteration number
                Console.WriteLine($"Iteration {i + 1}: Lorry Weights - {string.Join(", ", Lorries.Select(lorry => lorry.GetTotalWeight()))}");
            }

            Console.WriteLine($"Successfully balanced the lorries after {i} iterations.");
        }
    }
}