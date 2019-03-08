namespace TutorialGeneticAlgorithm.Framework.GA
{
    interface IFitnessFunction<T, F> {
        F Fitness(T solution);
    }
}
