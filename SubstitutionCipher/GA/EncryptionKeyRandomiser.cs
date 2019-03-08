using System;
using System.Text;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.GA
{
        class EncryptionKeyRandomiser : IRandomiser<string> {
            private static Random random = new Random();

            private static string RandomEncryptionStringVar(string chars, int shuffleCount)
            {
                StringBuilder sb = new StringBuilder(chars);

                for(int i = 0; i < shuffleCount; ++i) {
                    var randomI = random.Next(chars.Length);
                    var random2 = random.Next(chars.Length);

                    var character = sb[randomI];

                    sb[randomI] = sb[random2];
                    sb[random2] = character;
                }

                return sb.ToString();
            }

            public string Random()
            {
                string initialEncryptionKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return RandomEncryptionStringVar(initialEncryptionKey, 62);
            }
        }
    
}
