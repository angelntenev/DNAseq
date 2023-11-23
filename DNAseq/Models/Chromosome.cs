using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAseq.Models
{
    public class Chromosome
    {
        List<Gene> geneList;
        //chainName is the defining name for the list of genes that have common traits
        //such as collection of Height genes, collection of Color genes and so on
        string chainName;

        public Chromosome(string chainName)
        {
            geneList = new List<Gene>();
            this.chainName = chainName;
        }

        public List<Gene> getGenes()
        {
            return new List<Gene>(geneList);
        }

        public void addGene(Gene gene)
        {
            this.geneList.Add(gene);
        }

        public string getChainName()
        {
            return chainName;
        }
    }

    

    
}
