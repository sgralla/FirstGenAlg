using System;
using System.Runtime.InteropServices;

namespace FirstGenAlg
{
    internal class Program
    {
        public static void Main(string[] args)
        {
          //  IntSearch.IntDna();
//            StringSearch.StringDna(
//                                 // "mein test string hier war mist deswegen suche ich weiter hier nach dies ist " +
//                                 // "ein test lala ihn mit zu singen weswegen ich hier weiter rum schreibe und hoffe " +
//                                 // "mir faellt noch mehr dreckszeug ein um hier mehr zeichen zu haben " +
//                                 // "ich koennte die anzahl der zur verfuegung stehenden zeichen erhoehen " +
//                                   "aber dafuer muss ich die random funktion anpassen" +
//                                    "test" +
//                                   "",1000,10000);
            var mod = 1;
            var a = new[] {1024, 124, 0};
//            var b = 123144;
//            var c = 0;
//            mod = a % b;
//            
            //6 % 4 = 2
            //4 % 2 = 0

            a[2] = a[0] % a[1];
            
            while (a[2] > 0)
            {
//                Array.Copy(a,1,a);
                Array.Copy(a, 1, a, 0, 2);
                a[2] = a[0] % a[1];
                //mod = a[2];
            }
            Console.WriteLine(a[1]);
        }

        
        
    }
}