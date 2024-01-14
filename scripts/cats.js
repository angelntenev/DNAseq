import Organism from './Organism.js';
import Chromosome from './Chromosome.js';
import Gene from './Gene.js';

let pairs = [];
let offspring = null;
export function createCat() 
{
    pairs = [];
    offspring = null;
    const cat = new Organism("Cat");

    const furColor = new Chromosome("Fur Color");
    const furColor1 = new Gene('A', 'a', "black/orange");
    furColor.addGene(furColor1);
    cat.addChromosome(furColor);

    const eyeColor = new Chromosome("Eye Color");
    const eyeColor1 = new Gene('A', 'a', "green/blue");
    eyeColor.addGene(eyeColor1);
    cat.addChromosome(eyeColor);

    const earPointiness = new Chromosome("Ear Pointiness");
    const earPointiness1 = new Gene('A', 'a', "pointy/round");
    earPointiness.addGene(earPointiness1);
    cat.addChromosome(earPointiness);

    const tailFluffiness = new Chromosome("Tail Fluffiness");
    const tailFluffiness1 = new Gene('A', 'a', "fluffy/not fluffy");
    tailFluffiness.addGene(tailFluffiness1);
    cat.addChromosome(tailFluffiness);


    const cat2 = cat;

    offspring = cat.mate(cat2);
    const chains = offspring.getAllChains();

    pairs = [];
    for (let i = 0; i < chains.length; i += 2) {
        const pair = chains[i] + chains[i + 1];
        pairs.push(pair);
    }
}


export function getCatImage() {
    return new Promise((resolve, reject) => 
    {
        const canvas = document.createElement('canvas');
        const ctx = canvas.getContext('2d');

        const furColorImage = new Image();
        furColorImage.src = getCatFurColor();
        furColorImage.onload = function() 
        {
            canvas.width = furColorImage.width;
            canvas.height = furColorImage.height;

            ctx.drawImage(furColorImage, 0, 0);

            const eyeColorImage = new Image();
            eyeColorImage.src = getCatEyeColor();
            eyeColorImage.onload = function() 
            {
                const eyeX = 80;
                const eyeY = 265;

                ctx.drawImage(eyeColorImage, eyeX, eyeY);

                const resultingImage = canvas.toDataURL();
                resolve(resultingImage);
            };
            eyeColorImage.onerror = reject;
        };
        furColorImage.onerror = reject;
    });
}

export function getCatFurColor() 
{
    const furColorChromosome = offspring.getChromosome("Fur Color");
    const genes = furColorChromosome.getGenes();

    for (let i = 0; i < genes.length; i++) {
        const gene = genes[i];
        if (gene.getAllele1() === gene.getAllele1().toUpperCase()) {
            console.log(gene.getAllele1());
            return "res/images/catbody-black.png";
        } else {
            console.log(gene.getAllele1());
            return "res/images/catbody-orange1.png";
        }
    }
}

export function getCatEyeColor()
{
    const eyeColorChromosome = offspring.getChromosome("Eye Color");
    const genes = eyeColorChromosome.getGenes();

    for (let i = 0; i < genes.length; i++) {
        const gene = genes[i];
        if (gene.getAllele1() === gene.getAllele1().toUpperCase()) {
            console.log(gene.getAllele1());
            return "res/images/cateyes-green.png";
        } else {
            console.log(gene.getAllele1());
            return "res/images/cateyes-blue.png";
        }
    }
}

export function getCatEarPointiness()
{
    const earPointinessChromosome = offspring.getChromosome("Ear Pointiness");
    const genes = earPointinessChromosome.getGenes();

    for (let i = 0; i < genes.length; i++) {
        const gene = genes[i];
        if (gene.getAllele1() === gene.getAllele1().toUpperCase()) {
            console.log(gene.getAllele1());
            return "res/images/cathead-pointy.png";
        } else {
            console.log(gene.getAllele1());
            return "res/images/cathead-round.png";
        }
    }
}

export function getCatTailFluffiness()
{
    const tailFluffinessChromosome = offspring.getChromosome("Tail Fluffiness");
    const genes = tailFluffinessChromosome.getGenes();

    for (let i = 0; i < genes.length; i++) {
        const gene = genes[i];
        if (gene.getAllele1() === gene.getAllele1().toUpperCase()) {
            console.log(gene.getAllele1());
            return "res/images/cattail-fluffy.png";
        } else {
            console.log(gene.getAllele1());
            return "res/images/cattail-notfluffy.png";
        }
    }
}


export function getCatImageFuture() {
    return new Promise((resolve, reject) => 
    {
        const canvas = document.createElement('canvas');
        const ctx = canvas.getContext('2d');

        const furColorImage = new Image();
        furColorImage.src = getCatFurColor();
        furColorImage.onload = function() 
        {
            canvas.width = furColorImage.width;
            canvas.height = furColorImage.height;

            ctx.drawImage(furColorImage, 0, 0);

            const eyeColorImage = new Image();
            eyeColorImage.src = getCatEyeColor();
            eyeColorImage.onload = function() 
            {
                const eyeX = 80;
                const eyeY = 265;

                ctx.drawImage(eyeColorImage, eyeX, eyeY);

                const earPointinessImage = new Image();
                earPointinessImage.src = getCatEarPointiness();
                earPointinessImage.onload = function() 
                {
                    const earX = 150;
                    const earY = 100;

                    ctx.drawImage(earPointinessImage, earX, earY);

                    const tailFluffinessImage = new Image();
                    tailFluffinessImage.src = getCatTailFluffiness();
                    tailFluffinessImage.onload = function() 
                    {
                        const tailX = 200;
                        const tailY = 300;

                        ctx.drawImage(tailFluffinessImage, tailX, tailY);

                        const resultingImage = canvas.toDataURL();
                        resolve(resultingImage);
                    };
                    tailFluffinessImage.onerror = reject;
                };
                earPointinessImage.onerror = reject;
            };
            eyeColorImage.onerror = reject;
        };
        furColorImage.onerror = reject;
    });
}