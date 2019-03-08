using System;
using System.Linq;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.GA
{
    class StringBreeder : IBreeder<string>
    {
        private static Random random = new Random();

        public string Breed(string parent1, string parent2)
        {
            int crossoverPoint = random.Next(parent1.Length);

            return parent1.Take(crossoverPoint)
                        .Union(parent2.Skip(crossoverPoint))
                        .Aggregate("", (current, newChar) => current + newChar);
        }
    }

}
