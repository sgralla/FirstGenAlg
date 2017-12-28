using System;
using System.Linq;

namespace FirstGenAlg
{
    internal static class StringDistance
    {
        public static int GetHammingDistance(string s, string t)
        {
            if (s.Length != t.Length)
            {
                throw new Exception("Strings must be equal length");
            }
 
            var distance =
                s.ToCharArray()
                    .Zip(t.ToCharArray(), (c1, c2) => new { c1, c2 })
                    .Count(m => m.c1 != m.c2);
 
            return distance;
        }

        public static int GetHammingDistance(char[] m, char[] f)
        {
            if (m.Length != f.Length)
            {
                throw new Exception("not equal  in length");
            }

            var distance =
                m.Zip(f, (c1, c2) => new {c1, c2})
                    .Count(x => x.c1 != x.c2);
            return distance;
        }
        
        public static int LevenshteinDistance(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.IsNullOrEmpty(t) ? 0 : t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            var n = s.Length;
            var m = t.Length;
            var d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (var i = 0; i <= n; d[i, 0] = i++) { }
            for (var j = 1; j <= m; d[0, j] = j++) { }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    var cost = t[j - 1] == s[i - 1] ? 0 : 1;
                    var min1 = d[i - 1, j] + 1;
                    var min2 = d[i, j - 1] + 1;
                    var min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }
        
        internal static int CalculateFitness(char[] target, char [] geneA)
        {
            var targetlen = target.Length;
            var fitness = targetlen;
            //var minlen = Math.Min(target.Length, GeneA.Length);
            // Aufhoeren wenn klar ist, dass kein besserer erreicht werden kann ???
            for (var i = 0; i < targetlen; i++)
            {
                //var t = target[i];
                //var g = GeneA[i];
                if (target[i] != geneA[i]) continue;
                fitness--;
                //colorBools[i] = true;
            }

            //fitness = GeneA.Intersect(target);
            return fitness;

        }
    }
}