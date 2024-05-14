using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAseq.Models
{
    public class Gene
    {
        char allele1;
        char allele2;
        //Trait is the defining Trait about the gene, such as COLOR, EYE COLOR, LENGTH(AS IN TALLNESS)
        string trait;
        //Resulting trait is TRUE if there is a dominant allele and FALSE if 2 recessive traits
        bool resultingTrait;
        string resultTrait;

        public Gene(char A, char a, string trait)
        {
            this.allele1 = A;
            this.allele2 = a;

            if ((!char.IsUpper(this.allele1)) && (char.IsUpper(this.allele2)))
            {
                char x = this.allele1;
                this.allele1 = this.allele2;
                this.allele2 = x;
            }

            if (char.IsUpper(this.allele1))
            {
                resultingTrait = true;
            }
            else
            {
                resultingTrait = false;
            }

            this.trait = trait;
            string[] words = trait.Split('/');
            if (resultingTrait)
            {
                resultTrait = words[0];
            }
            else resultTrait = words[1];
        }

        public Gene(string alleles, string trait)
        {
            this.allele1 = alleles[0];
            this.allele2 = alleles[1];
            this.trait = trait;
        }

        public string getAlleles()
        {
            return string.Concat(allele1, allele2);
        }

        public char getAllele1() 
        {
            return allele1;
        }

        public char getAllele2()
        {
            return allele2;
        }

        public string getResultingTrait()
        {
            return resultTrait;
        }

        public string getTrait()
        {
            return trait;
        }

        public void setAlleles(Gene gene)
        {
            this.allele1 = gene.getAllele1();
            this.allele2 = gene.getAllele2();
        }

    }
}
