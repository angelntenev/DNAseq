import Gene from './Gene.js';


export class Crossingover {
    static crossover(parent1, parent2) {
        let offspringGenes = this.getPotentialOffspringGenes(parent1, parent2);

        let randomIndex = Math.floor(Math.random() * offspringGenes.length);

        return offspringGenes[randomIndex];
    }

    static getPotentialOffspringGenes(parent1, parent2) {
        let offspring = [];
        let tempOffspring = new Gene(parent1.getAllele1(), parent2.getAllele1(), parent1.getTrait());
        offspring.push(tempOffspring);
        tempOffspring = new Gene(parent1.getAllele1(), parent2.getAllele2(), parent1.getTrait());
        offspring.push(tempOffspring);
        tempOffspring = new Gene(parent1.getAllele2(), parent2.getAllele1(), parent1.getTrait());
        offspring.push(tempOffspring);
        tempOffspring = new Gene(parent1.getAllele2(), parent2.getAllele2(), parent1.getTrait());
        offspring.push(tempOffspring);

        return offspring;
    }
}
