namespace TutorialGeneticAlgorithm.Framework.GA
{
    interface IBreeder<T>
    {
        T Breed(T parent1, T parent2);
    }

}
