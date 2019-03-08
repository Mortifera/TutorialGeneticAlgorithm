namespace TutorialGeneticAlgorithm.Framework.Encryption
{

    public class Encryptor : IEncryptor
    {
        private readonly string encryptionKey;
        IStringTransformer encryptor;

        public Encryptor(string encryptionKey, IStringTransformer encryptor) {
            this.encryptionKey = encryptionKey;
            this.encryptor = encryptor;
        }

        public string Transform(string message)
        {
            return encryptor.Transform(message, encryptionKey);
        }
    }
}
