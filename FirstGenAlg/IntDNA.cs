using System;

namespace FirstGenAlg
{
    public class IntDNA
    {
        public int Gene { get; private set; }
        public int Fitness { get; private set; }

        private static readonly Random Rng = new Random();
        private int _bit;
        
            
        public IntDNA(int size)
        {
            Gene = size;
        }

        internal void CalculateFitness()
        {
            var gene = Gene + 1;
            //var divider = 2;
            var fitness = 0;
            ///*  
            while (gene > 1)
            {
                if ((gene & 1) == 0) break;
                fitness += 1;
                gene >>= 1;
                //divider = 2;
                //else
                //{
                //    divider += 1;
                //}
            }
            //*/  
            
            //while (gene ^ 1 > 0)
            Fitness = fitness;
        }

       
        internal IntDNA CrossOverAnd(IntDNA father)
        {
            //var sumfitness = father.Fitness + Fitness;
            //var fatherfitness = father.Fitness / sumfitness;
            //var motherfitness = 
            //return(new DNA(father.Gene & Gene));
            var child = new IntDNA(father.Gene & Gene);
            child.Mutate();
            return (child);
        }

        public IntDNA CrossOverTilde(IntDNA father)
        {
            //return (new DNA(father.Gene ^ Gene));
            var child = new IntDNA(father.Gene ^ Gene);
            child.Mutate();
            return (child);
        }

        public IntDNA MutateBestOnly(IntDNA father)
        {
            var child = father.Fitness > Fitness ? father : this;
            //child.Mutate();
            child.GoodMutation();
            return (child);
        }
        
        public static IntDNA[] DnaInitialize(int size = 20)
        {
            //var rng = new Random();
            var dnalist = new IntDNA[size];
            for (var i = 0; i < size; i++)
            {
                dnalist[i] = new IntDNA(Rng.Next(0, 65536));
            }
            return dnalist;
        }

        private void Mutate()
        {
            _bit = 1 << Rng.Next(0, 31);
            //_bit = Rng.Next(0, 30);
            //_bit = Convert.ToInt32(Math.Pow(2, _bit));
           
            

            Gene ^= _bit;
        }

        private void GoodMutation()
        {
//            _bit = 1 << Rng.Next(0, 32);
//            var tempgene = Gene;
//            tempgene &= _bit;
//            if (tempgene == 0)
//            {
//                
//            }
            //var temp = (1 << 31);
            //temp ^= temp;
            //_bit &= temp;
//            Gene |= _bit;
            Gene |= 1 << Rng.Next(0, 30);
        }
    }
    
}