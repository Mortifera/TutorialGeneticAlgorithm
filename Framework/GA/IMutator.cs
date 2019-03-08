namespace TutorialGeneticAlgorithm.Framework.GA
{
    interface IMutator<T> {
        T Mutate(T chromosome);
    }

}
