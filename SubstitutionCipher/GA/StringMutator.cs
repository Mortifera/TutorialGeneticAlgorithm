using System;
using System.Text;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.GA
{
    class StringMutator : IMutator<string>
    {
        private static Random random = new Random();

        public string Mutate(string chromosome)
        {
            return RandomEncryptionStringVar(chromosome);
        }

        private static string RandomEncryptionStringVar(string chars)
        {
            StringBuilder sb = new StringBuilder(chars);

            var randomI = random.Next(chars.Length);
            var random2 = random.Next(chars.Length);

            var character = sb[randomI];

            sb[randomI] = sb[random2];
            sb[random2] = character;

            return sb.ToString();
        }

    }

}
