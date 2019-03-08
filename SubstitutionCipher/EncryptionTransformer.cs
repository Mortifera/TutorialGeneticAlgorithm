using System.Linq;
using System.Collections.Generic;
using TutorialGeneticAlgorithm.Framework.Encryption;

namespace TutorialGeneticAlgorithm.SubstitutionCipher
{
    public class EncryptionTransformer : IStringTransformer
    {

        public string Transform(string message, string encryptionKey)
        {
            message = message.ToUpper();
            var encryptionKeyMap = createEncryptionMap(encryptionKey);
            return message.Select(msgChar => encryptionKeyMap.ContainsKey(msgChar) ? encryptionKeyMap[msgChar] : msgChar)
                            .Aggregate("", (current, character) => current + character);
        }

        private Dictionary<char, char> createEncryptionMap(string encryptionKey)
        {
            encryptionKey = encryptionKey.ToUpper();
            if (encryptionKey.Length == 26)
            {
                var encryptionKeyMap = new Dictionary<char, char>();

                char letter = 'A';

                for (int i = 0; i < 26; ++i, ++letter)
                {
                    encryptionKeyMap.Add(letter, encryptionKey[i]);
                }

                return encryptionKeyMap;
            }
            return null;
        }
    }
}
