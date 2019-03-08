using System;
using TutorialGeneticAlgorithm.Framework;
using TutorialGeneticAlgorithm.Framework.Encryption;
using TutorialGeneticAlgorithm.Framework.GA;
using TutorialGeneticAlgorithm.SubstitutionCipher;
using TutorialGeneticAlgorithm.SubstitutionCipher.GA;
using TutorialGeneticAlgorithm.SubstitutionCipher.Solvers;

namespace TutorialGeneticAlgorithm
{
    partial class Program
    {

        static void Main(string[] args)
        {
            var encryptor = GetEncryptor();
            var decryptionTransformer = new DecryptionTransformer();

            string testString = "The quick brown fox jumps over a lazy dog.";
            testString = testString.ToUpper();

            var fitnessFunction = new StringCompareFitnessFunction(testString, encryptor.Transform(testString), decryptionTransformer);

            SolvePairSwapping(fitnessFunction, out string bestGuessEncryptionKey);
            //SolveGA(fitnessFunction, out string bestGuessEncryptionKey);

            TestEncryptionKey(bestGuessEncryptionKey, encryptor, decryptionTransformer);
        }

        private static IEncryptor GetEncryptor() {
            const string EncryptionKey = "YBXOMGSWKCPZFNTDHRQUJVELIA";

            return new Encryptor(EncryptionKey, new EncryptionTransformer());
        }

        private static void SolvePairSwapping(IFitnessFunction<string,int> fitnessFunction, out string encryptionKey) {
            var solver = new EncryptionKeyPairSwappingSolver(fitnessFunction, 3000);

            solver.Solve(out encryptionKey);

            System.Console.WriteLine("PairSwapping Solution: " + encryptionKey);
        }

        private static void SolveGA(IFitnessFunction<string, int> fitnessFunction, out string encryptionKey) {
            var gaPopulation = new EliteSelectionPopulation<string, int>(new StringMutator(), new StringBreeder(), new EncryptionKeyRandomiser(), 100, 0.1f, 0.4f, 0.01f);
            var solverGa = new EncryptionKeySolverGA<string, int>(fitnessFunction, gaPopulation, 10);

            solverGa.Solve(out encryptionKey);

            System.Console.WriteLine("GA Solution: " + encryptionKey);
        }

        private static void TestEncryptionKey(string encryptionKey, IEncryptor encryptor, IStringTransformer decryptionTransformer) {
            string testString = "The quick brown fox jumps over a lazy dog.";
            testString = testString.ToUpper();

            var encrypted = encryptor.Transform(testString);

            var decrypted = decryptionTransformer.Transform(encrypted, encryptionKey);

            if (testString.Equals(decrypted)) {
                System.Console.WriteLine("SOLVED");
            } else {
                System.Console.WriteLine("NOT SOLVED");
            }
            System.Console.WriteLine("Decrypted message: " + decrypted);
        }
    }
}
