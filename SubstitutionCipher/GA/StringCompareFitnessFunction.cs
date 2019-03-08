using TutorialGeneticAlgorithm.Framework.Encryption;
using TutorialGeneticAlgorithm.Framework.GA;

namespace TutorialGeneticAlgorithm.SubstitutionCipher.GA
{
    class StringCompareFitnessFunction : IFitnessFunction<string, int>
    {
        private readonly IStringTransformer stringTransformer;
        private readonly string originalStr;
        private readonly string transformedStr;

        public StringCompareFitnessFunction(string originalStr, string transformedStr, IStringTransformer stringTransformer)
        {
            this.originalStr = originalStr;
            this.transformedStr = transformedStr;
            this.stringTransformer = stringTransformer;
        }

        public int Fitness(string solution)
        {
            var invertedTransformedString = stringTransformer.Transform(transformedStr, solution);

            var originalStrByChar = originalStr.ToCharArray();
            var invertedTransformedStringByChar = invertedTransformedString.ToCharArray();

            int matches = 0;

            for (int i = 0; i < originalStrByChar.Length; ++i)
            {
                if (originalStrByChar[i] == invertedTransformedStringByChar[i])
                {
                    ++matches;
                }
            }

            return matches;
        }
    }
}
