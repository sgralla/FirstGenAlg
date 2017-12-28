namespace FirstGenAlg.Properties
{
    public class GenerationPool
    {
        private int size;
        
        public static StringDna[] DnaInitialize(int size = 20)
        {
            //var rng = new Random();
            var dnaarray = new StringDna[size];
            for (var i = 0; i < size; i++)
            {
                var tempdna = new StringDna("");
                tempdna.Initialize(18);
                dnaarray[i] = tempdna;
            }
            return dnaarray;
        }
    }
}