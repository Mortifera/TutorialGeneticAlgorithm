using System;
using System.Collections.Generic;
using System.Linq;

namespace TutorialGeneticAlgorithm.Framework.GA
{
    class EliteSelectionPopulation<T, F> : IPopulation<T, F>
    {
        private static Random random = new Random();

        private readonly IMutator<T> mutator;
        private readonly IBreeder<T> breeder;
        private readonly IRandomiser<T> randomiser;
        private readonly double eliteSelectionPercentage;
        private readonly double crossoverSelectionPercentage;
        private readonly double mutationChance;
        private T[] chromosomes;

        public EliteSelectionPopulation(IMutator<T> mutator, IBreeder<T> breeder, IRandomiser<T> randomiser, int size, double eliteSelectionPercentage, double crossoverSelectionPercentage, double mutationChance) {
            chromosomes = new T[size];
            this.mutator = mutator;
            this.breeder = breeder;
            this.eliteSelectionPercentage = eliteSelectionPercentage;
            this.crossoverSelectionPercentage = crossoverSelectionPercentage;
            this.mutationChance = mutationChance;
            this.randomiser = randomiser;

            chromosomes = Enumerable.Range(0, size).Select(num => randomiser.Random()).ToArray();
        }

        public F AverageFitness { get; private set; }

        public F BestFitness { get; private set; }

        public T Fittest { get; private set; }

        public void Update(IFitnessFunction<T, F> fitnessFunction)
        {
            var fitness = chromosomes.Select(chromsome => fitnessFunction.Fitness(chromsome)).ToArray();

            BestFitness = fitness.Max();
            Fittest = chromosomes[Array.FindIndex(fitness, chromosomeFitness => chromosomeFitness.Equals(BestFitness))];
            
            chromosomes = chromosomes.OrderByDescending(x => fitnessFunction.Fitness(x)).ToArray();

            var crossOverChromosomes = chromosomes.Take((int)(crossoverSelectionPercentage * chromosomes.Length));
            
            var newChromosomes = GenerateNewChildPopulation(crossOverChromosomes);
            newChromosomes = newChromosomes.Union(chromosomes.Take((int)(eliteSelectionPercentage * chromosomes.Length)));

            int randomChromosomesNum = chromosomes.Length - newChromosomes.Count();
            
            var randomChromosomes = Enumerable.Range(0, randomChromosomesNum).Select(num => randomiser.Random());

            newChromosomes = newChromosomes.Union(randomChromosomes);

            chromosomes = newChromosomes.ToArray();

            fitness = chromosomes.Select(chromsome => fitnessFunction.Fitness(chromsome)).ToArray();

            BestFitness = fitness.Max();
            Fittest = chromosomes[Array.FindIndex(fitness, chromosomeFitness => chromosomeFitness.Equals(BestFitness))];
        }

        private T Mutate(T chromosome) {
            return mutator.Mutate(chromosome);
        }

        private IEnumerable<T> GenerateNewChildPopulation(IEnumerable<T> parents) {
            var randomisedParents = (IEnumerable<T>) parents.OrderBy(parent => random.Next());

            List<T> children = new List<T>();

            while(randomisedParents.Count() > 1 ) {
                var childParents = randomisedParents.Take(2).ToArray();
                randomisedParents = randomisedParents.Skip(2);

                children.Add(CreateChild(childParents[0], childParents[1]));
            }
            
            return children;
        }

        private T CreateChild(T parent1, T parent2) {
            return breeder.Breed(parent1, parent2);
        }
    }

}
