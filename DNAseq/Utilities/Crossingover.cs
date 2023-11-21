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
        public static Allele Crossover(Allele parent1, Allele parent2)
        {
            List<Allele> offspring = getPotentialOffspring(parent1, parent2);

            int randomIndex = rnd.Next(offspring.Count);

            return offspring[randomIndex];
        }

        public static List<Allele> getPotentialOffspring(Allele parent1, Allele parent2)
        {
            List<Allele> offspring = new List<Allele>();
            Allele tempoffspring = new Allele(parent1.getDominant(), parent2.getDominant());
            offspring.Add(tempoffspring);
            tempoffspring = new Allele(parent1.getDominant(), parent2.getRecessive());
            offspring.Add(tempoffspring);
            tempoffspring = new Allele(parent1.getRecessive(), parent2.getDominant());
            offspring.Add(tempoffspring);
            tempoffspring = new Allele(parent1.getRecessive(), parent2.getRecessive());
            offspring.Add(tempoffspring);

            return offspring;

        }
    }
}
