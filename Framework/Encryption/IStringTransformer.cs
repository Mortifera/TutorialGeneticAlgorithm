namespace TutorialGeneticAlgorithm.Framework.Encryption
{
    public interface IStringTransformer
    {
        string Transform(string message, string transformationKey);
    }
}
