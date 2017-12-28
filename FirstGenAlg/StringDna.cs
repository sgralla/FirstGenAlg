using System;

namespace FirstGenAlg
{
    public class StringDna
    {
        public char[] GeneA;
        
        public int Fitness { get; internal set; }
        public int FitnessMother { get; internal set; }
        public int FitnessFather { get; internal set; }
        
        
        private static readonly Random Rng = new Random();
        
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz ".ToCharArray();
        private static readonly int AlphabetLength = Alphabet.Length;
        
        
        
        internal StringDna(string phrase)
        {
            GeneA = phrase.ToCharArray();
            Fitness = phrase.Length;
            FitnessMother = Fitness;
            FitnessFather = Fitness;
        }

        internal StringDna(char[] phrase)
        {
            GeneA = phrase;
            Fitness = phrase.Length;
            FitnessMother = Fitness;
            FitnessFather = Fitness;
        }

        internal void Initialize(int len)
        {
            var genetemp = new char[len];
            for (var i = 0; i < len; i++)
            {
                genetemp[i] = Alphabet[Rng.Next(0, AlphabetLength - 1)];
            }
            GeneA = genetemp;
        }

        internal StringDna CrossOver(StringDna father,int targetlen)
        {
            var temp = new char[targetlen];
            for (var i = 0; i < targetlen; i+=1)
            {
                if (i < targetlen / 2)
                {
                    temp[i] = GeneA[i];
                }
                else
                {
                    temp[i] = father.GeneA[i];
                }
            }
            var child = new StringDna(temp);
            
            //child.Mutate(Rng.Next(0,AlphabetLength - 1));
            child.Mutate(1);
            return child;
        }

        public static StringDna[] DnaInitialize(int size, int targetlen, string startstring = "")
        {
            var dnaarray = new StringDna[size];
            for (var i = 0; i < size; i++)
            {
                var tempdna = new StringDna(startstring);
                if (string.IsNullOrWhiteSpace(startstring))
                {
                    tempdna.Initialize(targetlen);
                }
                dnaarray[i] = tempdna;
            }
            return dnaarray;
        }


        private void Mutate(int mutationrate = 1)
        {
            var changechar = Rng.Next(0, GeneA.Length);

            for (var i = 0; i < mutationrate; i++)
            {
                var t = Array.IndexOf(Alphabet, GeneA[changechar]);
                t += Rng.Next(0, AlphabetLength);
                t %= AlphabetLength;
                GeneA[changechar] = Alphabet[t];
            }
        }
    }
}