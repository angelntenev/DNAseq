using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAseq.Models
{
    public class Allele
    {
        char dominant;
        char recessive;
        public Allele(char A, char a)
        {
            this.dominant = A;
            if (a.Equals(A))
            {
                this.recessive = A;
            }
            else
            {
                this.recessive = a;
            }
        }

        public Allele(string alleles)
        {
            this.dominant = alleles[0];
            this.recessive = alleles[1];
        }

        public string getAlleles()
        {
            return string.Concat(dominant, recessive);
        }

        public char getDominant() 
        {
            return dominant;
        }

        public char getRecessive()
        {
            return recessive;
        }
    }
}
