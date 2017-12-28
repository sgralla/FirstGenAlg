using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGenAlg
{
    public static class IntSearch
    {
        public static void IntDna()
        {
            
            var bestgene = 0;
            var bestfitness = 0;
            var bestgeneration = 0;
            
            const int size = 100;
            const int generations = 2000000;

            var dnaarray = IntDNA.DnaInitialize(size);
            
            for (var generation = 0; generation < generations; generation++)
            {
                //foreach (var dna in dnaarray)
                var generation1 = generation;
                Parallel.ForEach(dnaarray, dna =>
                {
                    dna.CalculateFitness();
                    if (bestfitness >= dna.Fitness) return;
                    bestfitness = dna.Fitness;
                    bestgene = dna.Gene;
                    bestgeneration = generation1;
                    Console.WriteLine("Fitness: " + bestfitness + " gene: " + bestgene + " generation: " +
                                      bestgeneration);
                });
                var sorteddnalist = dnaarray.OrderByDescending(dna=>dna.Fitness).ToList();

                for (var i = 0; i < sorteddnalist.Count - 1; i += 2)
                {
                    dnaarray[i] = sorteddnalist[i].MutateBestOnly(sorteddnalist[i + 1]);
                }
                //Console.WriteLine(generation);
            }

            Console.WriteLine("Fitness: " + bestfitness + " gene: " + bestgene + " generation: " + bestgeneration);
            Console.WriteLine("Fitness: " + Convert.ToString(bestfitness,2) + 
                              " gene: " + Convert.ToString(bestgene,2) + 
                              " generation: " + Convert.ToString(bestgeneration,2));
            
        }

    }
}