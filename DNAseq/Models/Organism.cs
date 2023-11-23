using DNAseq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAseq.Models
{
    public class Organism
    {
        List<Chromosome> chromosomes;
        string name;

        public Organism(string name)
        {
            this.name = name;
            chromosomes = new List<Chromosome>();
        }

        public List<Chromosome> getAllChromosomes()
        {
            return chromosomes;
        }
        public string getName()
        {
            return name;
        }
        public Chromosome getChromosome(string chainName)
        {
            for (int i = 0; i < chromosomes.Count; i++)
            {
                if (chromosomes[i].getChainName().Equals(chainName))
                {
                    return chromosomes[i];
                }
            }
            return null;
        }
        
        public void addChromosome(Chromosome chromosome)
        {
            chromosomes.Add(chromosome);
        }

        public string getAllChains()
        {
            string finalChain = "";

            foreach (Chromosome chromosome in chromosomes)
            {
                foreach (Gene gene in chromosome.getGenes())
                {
                    finalChain += gene.getAlleles();
                }
                finalChain += '\n';
            }

            return finalChain;
        }

        public Chromosome GetChromosomeByName(string name)
        {
            foreach (Chromosome chromosome in chromosomes)
            {
                if (chromosome.getChainName().Equals(name))
                {
                    return chromosome;
                }
            }
            return null;
        }

        public Chromosome GetChromosomeByIdentifier(int identifier)
        {
            return chromosomes[identifier];
        }

        public Organism Mate(Organism mate)
        {
            Organism offspring = new Organism(this.name);

            for (int i = 0; i < chromosomes.Count; i++)
            {
                List<Gene> genes = chromosomes[i].getGenes();
                List<Gene> targetGenes = mate.GetChromosomeByIdentifier(i).getGenes();
                Chromosome chromosome = new Chromosome(chromosomes[i].getChainName());
                offspring.addChromosome(chromosome);
                for (int j = 0; j < genes.Count; j++)
                {
                    Gene newGene = Crossingover.Crossover(genes[j], targetGenes[j]);
                    offspring.GetChromosomeByIdentifier(i).getGenes().Add(newGene);
                }
            }
            return offspring;
        }
    }
}
