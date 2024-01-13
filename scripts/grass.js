import Organism from './Organism.js';
import Chromosome from './Chromosome.js';
import Gene from './Gene.js';
// Import Crossingover if needed
// import Crossingover from './Crossingover.js';

const grass = new Organism("Grass");

const size = new Chromosome("Size");
const size1 = new Gene('A', 'a', "50/25");
const size2 = new Gene('A', 'a', "50/25");
size.addGene(size1);
size.addGene(size2);
grass.addChromosome(size);

const direction = new Chromosome("Direction");
const direction1 = new Gene('A', 'a', "right/left");
direction.addGene(direction1);
grass.addChromosome(direction);

const orientation = new Chromosome("Orientation");
const orientation1 = new Gene('A', 'a', "standing/bending");
orientation.addGene(orientation1);
grass.addChromosome(orientation);

const grass2 = grass;

for (let i = 0; i < 10; i++) {
    const offspring = grass.mate(grass2);
    console.log(offspring.getAllChains());
}

