using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InconsistenciasDeclaracaoImportacao
{
    public class StringUtil
    {
        public static double JaroDistance(string s1, string s2)
        {
            // If the Strings are equal 
            if (s1 == s2)
                return 1.0;

            // Length of two Strings 
            int len1 = s1.Length;
            int len2 = s2.Length;

            // Maximum distance upto which matching 
            // is allowed 
            int max_dist = (int)(Math.Floor((double)((Math.Max(len1, len2) / 2) - 1)));

            // Count of matches 
            int match = 0;

            // Hash for matches 
            int[] hash_s1 = new int[s1.Length];
            int[] hash_s2 = new int[s2.Length];

            // Traverse through the first String 
            for (int i = 0; i < len1; i++)
            {

                // Check if there is any matches 
                for (int j = Math.Max(0, i - max_dist);
                    j < Math.Min(len2, i + max_dist + 1); j++)

                    // If there is a match 
                    if (s1[i] == s2[j] && hash_s2[j] == 0)
                    {
                        hash_s1[i] = 1;
                        hash_s2[j] = 1;
                        match++;
                        break;
                    }
            }

            // If there is no match 
            if (match == 0)
                return 0.0;

            // Number of transpositions 
            double t = 0;

            int point = 0;

            // Count number of occurrences 
            // where two characters match but 
            // there is a third matched character 
            // in between the indices 
            for (int i = 0; i < len1; i++)
                if (hash_s1[i] == 1)
                {

                    // Find the next matched character 
                    // in second String 
                    while (hash_s2[point] == 0)
                        point++;

                    if (s1[i] != s2[point++])
                        t++;
                }

            t /= 2;

            // Return the Jaro Similarity 
            return ((match / ((double)len1)) + (match / ((double)len2)) + (match - t) / match) / 3.0;
        }
    }
}
