import Gene from './Gene.js';
import Chromosome from './Chromosome.js';
import { Crossingover } from './Crossingover.js';


export default class Organism {
    constructor(name) {
        this.name = name;
        this.chromosomes = [];
    }

    getAllChromosomes() {
        return this.chromosomes;
    }

    getName() {
        return this.name;
    }

    getChromosome(chainName) {
        return this.chromosomes.find(chromosome => chromosome.getChainName() === chainName) || null;
    }

    addChromosome(chromosome) {
        this.chromosomes.push(chromosome);
    }

    getAllChains() {
        let finalChain = "";
        this.chromosomes.forEach(chromosome => {
            chromosome.getGenes().forEach(gene => {
                finalChain += gene.getAlleles();
            });
            //finalChain += '\n';
        });
        return finalChain;
    }

    getChromosomeByIdentifier(identifier) {
        return this.chromosomes[identifier];
    }

    mate(mate) {
        let offspring = new Organism(this.name);

        this.chromosomes.forEach((chromosome, i) => {
            let genes = chromosome.getGenes();
            let targetGenes = mate.getChromosomeByIdentifier(i).getGenes();
            let newChromosome = new Chromosome(chromosome.getChainName());
            offspring.addChromosome(newChromosome);

            genes.forEach((gene, j) => {
                let newGene = Crossingover.crossover(gene, targetGenes[j]);
                offspring.getChromosomeByIdentifier(i).getGenes().push(newGene);
            });
        });

        return offspring;
    }
}
