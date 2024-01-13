import Organism from './Organism.js';
import Chromosome from './Chromosome.js';
import Gene from './Gene.js';

let pairs = [];
export function createCat() 
{
    pairs = [];
    const cat = new Organism("Cat");

    const furColor = new Chromosome("Fur Color");
    const furColor1 = new Gene('A', 'a', "black/orange");
    furColor.addGene(furColor1);
    cat.addChromosome(furColor);

    const eyeColor = new Chromosome("Eye Color");
    const eyeColor1 = new Gene('A', 'a', "green/blue");
    eyeColor.addGene(eyeColor1);
    cat.addChromosome(eyeColor);


    const cat2 = cat;

    const offspring = cat.mate(cat2);
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
                console.log(resultingImage);
                resolve(resultingImage);
            };
            eyeColorImage.onerror = reject;
        };
        furColorImage.onerror = reject;
    });
}

export function getCatFurColor() 
{
    if (pairs[0][0] === pairs[0][0].toUpperCase()) {
        console.log(pairs[0][0]);
        return "res/images/catbody-black.png";
    } else {
        console.log(pairs[0][0]);
        return "res/images/catbody-orange1.png";
    }
}

export function getCatEyeColor()
{
    if (pairs[1][0] === pairs[1][0].toUpperCase()) {
        console.log(pairs[1][0]);
        return "res/images/cateyes-green.png";
    } else {
        console.log(pairs[1][0]);
        return "res/images/cateyes-blue.png";
    }
}

