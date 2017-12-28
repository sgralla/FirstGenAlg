using System;

namespace FirstGenAlg
{
    public class StringDna
    {
        //public string GeneA { get; set; }
        public char[] GeneA;
        public int Fitness { get; internal set; }
       // public int FrontFitness { get; internal set; }
       // public int 
        //internal bool[] ColorBools = new[] {false, false, false, false};
        
        private static readonly Random Rng = new Random();
        
        //StringBuilder _gene = new StringBuilder("");

        //private static readonly char[] Target = "to be or not to be".ToCharArray();
        //private static readonly char[] Target = "valhalla deliverance have you ever forgotten me ".ToCharArray();
        //private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz ".ToCharArray();
        private static readonly int AlphabetLength = Alphabet.Length;
        
                                       //abcdefghijklmnopqrstuvwxyz 	
        //internal static int Targetlen = Target.Length;

        
        public StringDna(string phrase)
        {
            GeneA = phrase.ToCharArray();
            Fitness = phrase.Length;
//            ColorBools = new bool[Fitness];
//            for (var i = 0; i < Fitness; i+=1)
//            {
//                ColorBools[i] = false;
//            }
        }

        public StringDna(char[] phrase)
        {
            GeneA = phrase;
            Fitness = phrase.Length;
//            ColorBools = new bool[Fitness];
//            for (var i = 0; i < Fitness; i+=1)
//            {
//                ColorBools[i] = false;
//            }
        }

        internal void Initialize(int len)
        {
            var genetemp = new char[len];
            for (var i = 0; i < len; i++)
            {
                //_gene.Append(Alphabet[Rng.Next(0, 26)]);
            //    GeneA[i] = _alphabet[Rng.Next(0, 26)];
                genetemp[i] = Alphabet[Rng.Next(0, AlphabetLength - 1)];
            }
            //GeneA =  genetemp.ToString().PadRight(18,'x');
            GeneA = genetemp;
        }

        internal StringDna CrossOver(StringDna father,int targetlen)
        {
            //var tempString = new StringBuilder();
            //for (var i = 0; i < 18/2; i+=2)
            /*var minlen = Math.Min(father.GeneA.Length, GeneA.Length);
            for (var i = 0; i < minlen / 2 ; i+=2)
            {
                tempString.Append(GeneA[i*2]);
                tempString.Append(father.GeneA[i*2 + 1]);
                
            }*/
            //var child = new StringDna(tempString.ToString());
            //var child = new StringDna(GeneA.Substring(0,targetlen/2) + father.GeneA.Substring(targetlen/2));
            //GeneA.CopyTo()
            //var child = new StringDna(GeneA.CopyTo() (0,targetlen/2) + father.GeneA.Substring(targetlen/2));
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
            
            //var child = new StringDna(GeneA.);
            child.Mutate(Rng.Next(0,AlphabetLength - 1));
            child.Mutate(Rng.Next(0,AlphabetLength - 1));
            //child.Mutate();
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
            //var genechar = GeneA;
            var t = Array.IndexOf(Alphabet, GeneA[changechar]);
            t += mutationrate;
            t %= 27;
            GeneA[changechar] = Alphabet[t];
            //GeneA = new string(genechar);

        }
        
        //public async static Task<bool> LoadAsync(List<Schedule> scheduleList)
        //{
        //    var scheduleTaskList = scheduleList.Select(schedule => 
        //        LoadAsync((int)schedule.JobId, schedule.ScheduleId)).ToList();
        //    await Task.WhenAll(scheduleTaskList);

//            return true;
//        }
        
//        public static Task CalcGenFit(StringDna[] dnaarray) 
//        {
//            //int[] ids = new[] { 1, 2, 3, 4, 5 };
//            //return Task.WhenAll(ids.Select(i => DoSomething(1, i, blogClient)));
//            return Task.WhenAll(dnaarray.Select(CalcFit ));
//            
//            //return Task.WhenAll(dnaarray.AsEnumerable(i => CalcFit(i)));
//        }

//        public static Task CalcFit(StringDna stringDna)
//        {
//            var fitness = 0;
//            var minlen = Math.Min(Target.Length, stringDna.GeneA.Length);
//            for (var i = 0; i < minlen; i++)
//            {
//                var t = Target[i];
//                var g = stringDna.GeneA[i];
//                //if (Target[i] == GeneA[i])
//                if (t == g)
//                
//                {
//                    fitness++;
//                } 
//            }
//            stringDna.Fitness = fitness;
//            //return System.Threading.Tasks;
//            return null;
//        }

    }
}