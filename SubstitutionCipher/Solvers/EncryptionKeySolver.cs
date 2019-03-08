using System;
using System.Text;
using TutorialGeneticAlgorithm.Framework;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.Solvers
{
    class EncryptionKeyPairSwappingSolver : ISolver<string, int>
    {
        private readonly int generations;
        private IFitnessFunction<string, int> fitnessFunction;

        public EncryptionKeyPairSwappingSolver(IFitnessFunction<string, int> fitnessFunction, int generations)
        {
            this.fitnessFunction = fitnessFunction;
            this.generations = generations;
        }

        public int Solve(out string bestEncryptionKey)
        {

            string currentEncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            bestEncryptionKey = currentEncryptionKey;

            int currentFitness = fitnessFunction.Fitness(currentEncryptionKey);
            int bestFitness = currentFitness;

            int bestSolutionFoundAtGeneration = 0;

            for (int i = 0; i < generations; ++i)
            {
                currentEncryptionKey = RandomEncryptionStringVar(bestEncryptionKey);
                currentFitness = fitnessFunction.Fitness(currentEncryptionKey);

                if (currentFitness > bestFitness)
                {
                    bestFitness = currentFitness;
                    bestEncryptionKey = currentEncryptionKey;
                    bestSolutionFoundAtGeneration = i;
                }
            }

            return bestFitness;
        }

        private static Random random = new Random();
        public static string RandomEncryptionStringVar(string chars)
        {
            var randomI = random.Next(chars.Length);
            var random2 = random.Next(chars.Length);

            StringBuilder sb = new StringBuilder(chars);

            var character = sb[randomI];

            sb[randomI] = sb[random2];
            sb[random2] = character;

            return sb.ToString();
        }
    }
}
