using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstGenAlg
{
    public static class StringSearch
    {
    
        public static void StringDna(string target, int size = 100, int generations = 100000)
        {
            var bestgene = "";
            //var bestfitness = ;
            var bestgeneration = 0;

            var finished = false;
            var targetlen = target.Length;
            var bestfitness = targetlen;
            
            var targetchar = target.ToCharArray();
            
            //const int size = 200;
            //const int generations = 500000;

            var dnaarray = FirstGenAlg.StringDna.DnaInitialize(size, targetlen);
            
            
            for (var generation = 0; generation < generations; generation+= 1)
            {
                var paroptions = new ParallelOptions {MaxDegreeOfParallelism = -1};
                // -1 is for unlimited. 1 is for sequential.
                
                var generation1 = generation;
                Parallel.ForEach(dnaarray, paroptions, (dna) =>
                //foreach (var dna in dnaarray)
                {
                    //var dna = dnaarray[i];
                    //dna.Fitness = StringDistance.LevenshteinDistance(target, new string(dna.GeneA));
                    //dna.Fitness = StringDistance.GetHammingDistance(targetchar, dna.GeneA);
                    dna.Fitness = StringDistance.CalculateFitness(targetchar, dna.GeneA);
                    //dna.Fitness = StringDistance.CalculateFitness(targetchar, dna.GeneA, ref dna.ColorBools);
                    if (bestfitness <= dna.Fitness) return;
                    //if (bestfitness <= dna.Fitness) continue;
                    bestfitness = dna.Fitness;
                    bestgene = new string(dna.GeneA);
                    bestgeneration = generation1;
                    
                    
                    Console.WriteLine("Fitness: " + dna.Fitness + 
                                      " gene: " + new string(dna.GeneA) + 
                                      " generation: " + generation1 +
                                      //" colorbool: " + new string(dna.ColorBools) +
                                    " ");
                    if (bestfitness == 0)
                    {
                        finished = true;
                    }
                }
                );
                
                if (finished) break;
                
//                var sorteddnalist = dnaarray.OrderByDescending(dna=>dna.Fitness).ToList();
                //var sorteddnalist = dnaarray.OrderBy(dna=>dna.Fitness).ToList();
                var sorteddnalist = dnaarray.OrderBy(dna=>dna.Fitness).Take(2).ToList();
                
                //Console.WriteLine("Fitness: " + sorteddnalist[0].Fitness + " " + sorteddnalist[1].Fitness +
                //                  " gene: " + sorteddnalist[0].GeneA + " " + sorteddnalist[1].GeneA);
                //var
                //for (var i = 0; i < sorteddnalist.Count / 2; i += 2)
                Parallel.For(0, size, i =>
                    {
                        dnaarray[i] = sorteddnalist[0].CrossOver(sorteddnalist[1], targetlen);
                    }
                );
                if (generation % 1000 == 0)
                {
                    Console.WriteLine(generation);
                }
            }

            Console.WriteLine("Fitness: " + bestfitness + " gene: " + bestgene + " generation: " + bestgeneration);
            
        }
        
    }
    
    
}