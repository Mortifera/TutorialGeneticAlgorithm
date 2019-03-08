namespace TutorialGeneticAlgorithm.Framework
{
    interface ISolver<S, F> {
        F Solve(out S solution);
    }
}
