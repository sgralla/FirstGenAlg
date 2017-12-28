using System;
using System.Runtime.InteropServices;

namespace FirstGenAlg
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //  IntSearch.IntDna();
            const string targetstring = 
                "mein test string hier war mist deswegen suche ich weiter hier nach dies ist " +
                "ein test lala ihn mit zu singen weswegen ich hier weiter rum schreibe und hoffe " +
                "mir faellt noch mehr dreckszeug ein um hier mehr zeichen zu haben " +
                "ich koennte die anzahl der zur verfuegung stehenden zeichen erhoehen " +
                "aber dafuer muss ich die random funktion anpassen " +
//                                    "test" +
                "";

            var bestgene = "";
            StringSearch.StringDna(targetstring, ref bestgene, 1000, 1000);
            StringSearch.StringDna(targetstring, ref bestgene, 1000, 1000);
            
        }
    }
}