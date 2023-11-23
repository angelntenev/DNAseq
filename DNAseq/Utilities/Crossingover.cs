using DNAseq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DNAseq.Utilities
{
    public static class Crossingover
    {
        private static Random rnd = new Random();
        public static Gene Crossover(Gene parent1, Gene parent2)
        {
            List<Gene> offspringGenes = getPotentialOffspringGenes(parent1, parent2);

            int randomIndex = rnd.Next(offspringGenes.Count);

            return offspringGenes[randomIndex];
        }

        public static List<Gene> getPotentialOffspringGenes(Gene parent1, Gene parent2)
        {
            List<Gene> offspring = new List<Gene>();
            Gene tempoffspring = new Gene(parent1.getAllele1(), parent2.getAllele1(), parent1.getTrait());
            offspring.Add(tempoffspring);
            tempoffspring = new Gene(parent1.getAllele1(), parent2.getAllele2(), parent1.getTrait());
            offspring.Add(tempoffspring);
            tempoffspring = new Gene(parent1.getAllele2(), parent2.getAllele1(), parent1.getTrait());
            offspring.Add(tempoffspring);
            tempoffspring = new Gene(parent1.getAllele2(), parent2.getAllele2(), parent1.getTrait());
            offspring.Add(tempoffspring);

            return offspring;

        }
    }
}
