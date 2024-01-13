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
                Gene parent1 = new Gene('A', 'a', "Size");
                Gene parent2 = new Gene('A', 'a', "Size");
                var distribution = new Dictionary<string, int>
        {
            { "AA", 0 },
            { "Aa/aA", 0 }, // Combined category for Aa and aA
            { "aa", 0 }
        };

                int numSimulations = 10000;

                // Act
                for (int i = 0; i < numSimulations; i++)
                {
                    Gene result = Crossingover.Crossover(parent1, parent2);
                    string alleleCombo = result.getAlleles();
                    if (alleleCombo == "Aa" || alleleCombo == "aA")
                    {
                        distribution["Aa/aA"]++;
                    }
                    else
                    {
                        distribution[alleleCombo]++;
                    }
                }

                // Assert
                Assert.IsTrue(distribution["AA"] > (numSimulations * 0.20) && distribution["AA"] < (numSimulations * 0.30), $"Distribution for AA is {distribution["AA"]}");
                Assert.IsTrue(distribution["Aa/aA"] > (numSimulations * 0.45) && distribution["Aa/aA"] < (numSimulations * 0.55), $"Distribution for Aa/aA is {distribution["Aa/aA"]}");
                Assert.IsTrue(distribution["aa"] > (numSimulations * 0.20) && distribution["aa"] < (numSimulations * 0.30), $"Distribution for aa is {distribution["aa"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: " + ex.ToString());
                throw;
            }
        }

    }
}
