using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGenAlg
{
    public static class StringSearch
    {
        public static void StringDna(string target, ref string bestgene, int size = 100, int generations = 100000)
        {
            var currentBestGene = bestgene;
            var bestgeneration = 0;

            var finished = false;
            var targetlen = target.Length;
            var bestfitness = targetlen;
            
            var targetchar = target.ToCharArray();
            

            var dnaarray = FirstGenAlg.StringDna.DnaInitialize(size, targetlen, currentBestGene);
            
            
            for (var generation = 0; generation < generations; generation+= 1)
            {
                var paroptions = new ParallelOptions {MaxDegreeOfParallelism = -1};
                // -1 is for unlimited. 1 is for sequential.
                
                var generation1 = generation;
                Parallel.ForEach(dnaarray, paroptions, (dna) =>
                //foreach (var dna in dnaarray)
                {
                    //dna.Fitness = StringDistance.CalculateFitness(targetchar, dna.GeneA);
                    StringDistance.CalculateFitness(targetchar, dna);
                    
                    if (bestfitness <= dna.Fitness) return;
                    bestfitness = dna.Fitness;
                    currentBestGene = new string(dna.GeneA);
                    bestgeneration = generation1;
                    
                    
                    Console.WriteLine("Fitness: " + dna.Fitness + 
                                      " gene: " + new string(dna.GeneA) + 
                                      " generation: " + generation1 +
                                      " ");
                    if (bestfitness == 0)
                    {
                        finished = true;
                    }
                }
                );
                
                if (finished) break;
                //var sorteddnalist = dnaarray.OrderBy(dna=>dna.Fitness).Take(2).ToList();
                var sorteddnalistFather = dnaarray.OrderBy(dna=>dna.FitnessFather).Take(1).ToList();
                var sorteddnalistMother = dnaarray.OrderBy(dna=>dna.FitnessMother).Take(1).ToList();
                
                
                Parallel.For(0, size, i =>
                    {
                    //    dnaarray[i] = sorteddnalist[0].CrossOver(sorteddnalist[1], targetlen);
                        dnaarray[i] = sorteddnalistMother[0].CrossOver(sorteddnalistFather[0], targetlen);
                    }
                );
                if (generation % 1000 == 0)
                {
                    Console.WriteLine(generation);
                }
            }

            Console.WriteLine("Fitness: " + bestfitness + " gene: " + currentBestGene + " generation: " + bestgeneration);
            bestgene = currentBestGene;
        }
        
    }
    
    
}