using System.Linq;
using System.Collections.Generic;
using TutorialGeneticAlgorithm.Framework.Encryption;

namespace TutorialGeneticAlgorithm.SubstitutionCipher
{
    public class DecryptionTransformer : IStringTransformer
    {

        public string Transform(string message, string encryptionKey)
        {
            message = message.ToUpper();
            var decryptionMap = createDecryptionMap(encryptionKey);
            return message.Select(msgChar => decryptionMap.ContainsKey(msgChar) ? decryptionMap[msgChar] : msgChar)
                            .Aggregate("", (current, character) => current + character);
        }

        private Dictionary<char, char> createDecryptionMap(string encryptionKey)
        {
            encryptionKey = encryptionKey.ToUpper();
            if (encryptionKey.Length == 26)
            {
                var encryptionKeyMap = new Dictionary<char, char>();

                char letter = 'A';

                for (int i = 0; i < 26; ++i, ++letter)
                {
                    encryptionKeyMap.Add(encryptionKey[i], letter);
                }

                return encryptionKeyMap;
            }
            return null;
        }
    }
}
