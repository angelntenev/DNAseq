import Gene from './Gene.js';

export default class Chromosome {
    constructor(chainName) {
        this.geneList = [];
        this.chainName = chainName;
    }

    getGenes() {
        return this.geneList;
    }

    addGene(gene) {
        this.geneList.push(gene);
    }

    getChainName() {
        return this.chainName;
    }
    
    
}
