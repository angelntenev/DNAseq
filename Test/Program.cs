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
            Organism grass = new Organism("Grass");


            Chromosome size = new Chromosome("Size");
            Gene size1 = new Gene('A', 'a', "50/25");
            Gene size2 = new Gene('A', 'a', "50/25");
            size.addGene(size1);
            size.addGene(size2);
            grass.addChromosome(size);
            foreach (var genes in size.getGenes())
            {
                //  Console.WriteLine(genes.getResultingTrait());
            }

            Chromosome direction = new Chromosome("Direction");
            Gene direction1 = new Gene('A', 'a', "right/left");
            direction.addGene(direction1);
            grass.addChromosome(direction);

            Chromosome orientation = new Chromosome("Orientation");
            Gene orientation1 = new Gene('A', 'a', "standing/bending");
            orientation.addGene(orientation1);
            grass.addChromosome(orientation);

            Organism grass2 = grass;

            List<Organism> offsprings = new List<Organism>();

            for (int i = 0; i < 10; i++)
            {
                Organism offspring = grass.Mate(grass2);
                offsprings.Add(offspring);
            }

            Console.WriteLine(grass.getAllChains());
            foreach (var offspring in offsprings)
            {
                Console.Write("Next Offspring -> "); Console.WriteLine(offspring.getAllChains());
                foreach (var chromosome in offspring.getAllChromosomes())
                {
                    Console.WriteLine("Next Chromosome: ");
                    foreach (var gene in chromosome.getGenes())
                    {
                        Console.Write("Allele1: ");
                        Console.WriteLine(gene.getAllele1());
                        Console.Write("Allele2: ");
                        Console.WriteLine(gene.getAllele2());
                        Console.WriteLine(gene.getResultingTrait());
                        Console.WriteLine("__________");
                    }
                }
            }


            Console.ReadKey();
        }
    }
}