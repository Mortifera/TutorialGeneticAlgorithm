using System;
using System.Text;
using TutorialGeneticAlgorithm.Framework;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.Solvers
{
    class EncryptionKeySolverGA<T, F> : ISolver<T, F> where F : IComparable
    {
        private static Random random = new Random();

        private readonly int generations;
        private IFitnessFunction<T, F> fitnessFunction;

        private IPopulation<T, F> population;

        public EncryptionKeySolverGA(IFitnessFunction<T, F> fitnessFunction, IPopulation<T, F> initialPopulation, int generations)
        {
            this.fitnessFunction = fitnessFunction;
            this.generations = generations;
            this.population = initialPopulation;
        }

        public F Solve(out T bestEncryptionKey)
        {
            var currentFitness = population.BestFitness;
            var bestFitness = currentFitness;

            int bestSolutionFoundAtGeneration = 0;

            for (int i = 0; i < generations; ++i)
            {
                population.Update(fitnessFunction);

                if (population.BestFitness.CompareTo(currentFitness) > 0)
                {
                    bestFitness = currentFitness;
                    bestEncryptionKey = population.Fittest;
                    bestSolutionFoundAtGeneration = i;
                }
            }

            bestEncryptionKey = population.Fittest;

            return bestFitness;
        }
    }

}
