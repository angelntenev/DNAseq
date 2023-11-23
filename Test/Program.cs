using DNAseq.Models;
using DNAseq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gene parent1 = new Gene('A', 'a');
            Gene parent2 = new Gene('A', 'a');

            List<Gene> offspring = Crossingover.getPotentialOffspring(parent1, parent2);
            foreach (Gene allele in offspring)
            {
                    Console.WriteLine(allele.getAlleles());
            }

            Gene tempoffspring;
            for (int i = 0; i < 100; i++)
            {
                tempoffspring = Crossingover.Crossover(parent1, parent2);
                Console.WriteLine(tempoffspring.getAlleles());
            }

            Console.ReadKey();
        }
    }
}
