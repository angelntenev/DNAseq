export default class Gene {
    constructor(A, a, trait) {
        // Check the number of arguments to determine the constructor behavior
        if (arguments.length === 2) {
            // Assuming the first argument is a string of alleles and the second is the trait
            this.allele1 = A.charAt(0);
            this.allele2 = A.charAt(1);
            this.trait = a;
        } else {
            // Handling individual alleles and trait
            this.allele1 = A;
            this.allele2 = a;
            this.trait = trait;

            if (!this.isDominant(this.allele1) && this.isDominant(this.allele2)) {
                [this.allele1, this.allele2] = [this.allele2, this.allele1];
            }

            this.resultingTrait = this.isDominant(this.allele1);
        }
    }

    isDominant(char) {
        return char === char.toUpperCase();
    }

    getAlleles() {
        return this.allele1 + this.allele2;
    }

    getAllele1() {
        return this.allele1;
    }

    getAllele2() {
        return this.allele2;
    }

    getResultingTrait() {
        return this.resultingTrait;
    }

    getTrait() {
        return this.trait;
    }

    setAlleles(gene) {
        this.allele1 = gene.getAllele1();
        this.allele2 = gene.getAllele2();
    }

}
