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

            Chromosome direction = new Chromosome("Direction");
            Gene direction1 = new Gene('A', 'a', "right/left");
            direction.addGene(direction1);
            grass.addChromosome(direction);

            Chromosome orientation = new Chromosome("Orientation");
            Gene orientation1 = new Gene('A', 'a', "standing/bending");
            orientation.addGene(orientation1);
            grass.addChromosome(orientation);

            Organism grass2 = grass;

            for (int i = 0; i < 10; i++)
            {
                Organism offspring = grass.Mate(grass2);
                Console.WriteLine(offspring.getAllChains());
            }
            
            


            Console.ReadKey();
        }
    }
}
