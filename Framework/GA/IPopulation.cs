namespace TutorialGeneticAlgorithm.Framework.GA
{
    interface IPopulation<T, F>
    {
        void Update(IFitnessFunction<T, F> fitnessFunction);

        F AverageFitness { get; }
        F BestFitness { get; }
        T Fittest { get; }
    }

}
