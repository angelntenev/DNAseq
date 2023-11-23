using Microsoft.VisualStudio.TestTools.UnitTesting;
using DNAseq.Utilities;
using DNAseq.Models;
using System.Collections.Generic;

namespace crossoverTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Gene parent1 = new Gene('A', 'a');
                Gene parent2 = new Gene('A', 'a');
                var distribution = new Dictionary<string, int>
            {
                { "AA", 0 },
                { "Aa", 0 },
                { "aA", 0 },
                { "aa", 0 }
            };

                int numSimulations = 10000;

                // Act
                for (int i = 0; i < numSimulations; i++)
                {
                    Gene result = Crossingover.Crossover(parent1, parent2);
                    string alleleCombo = result.getAlleles();
                    distribution[alleleCombo]++;
                }

                // Assert
                foreach (var pair in distribution)
                {
                    // Allowing a margin for randomness, expecting around 25% distribution
                    int lowerBound = (int)(numSimulations * 0.24); // 20% lower bound
                    int upperBound = (int)(numSimulations * 0.26); // 30% upper bound
                    Assert.IsTrue(pair.Value > lowerBound && pair.Value < upperBound, $"Distribution for {pair.Key} is {pair.Value}, which is outside the expected range.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.ToString());
                throw;
            }
        }
    }
}
