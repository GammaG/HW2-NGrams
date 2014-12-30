using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGrams
{
    class LevenshteinDistance
    {


        private static volatile LevenshteinDistance levenshteinDistance;
        private List<int> resultsentences;
        private String searchTerm;



        public void setResultSet(List<int> resultsentences)
        {
            this.resultsentences = resultsentences;
        }

        public void setSerachTerm(String searchterm) 
        {
            this.searchTerm = searchterm;
        }


        private LevenshteinDistance()
        {
           
        }


        public List<String> generateDistance()
        {
            List<String> list = new List<String>();
            if (resultsentences != null & searchTerm != null)
            {
                List<String> sentences = ListRender.getInstance().getSentencesClean();
                foreach (int i in resultsentences)
                {
                    list.Add(i + " distance " + compute(searchTerm, sentences[i]));
                }
                
            }


            return list;


        }

        public void clear()
        {
            resultsentences = null;
            searchTerm = null;
        }

        public static LevenshteinDistance getInstance()
        {
            if (levenshteinDistance == null)
            {
                levenshteinDistance = new LevenshteinDistance();
            }
            return levenshteinDistance;
        }




            /// <summary>
            /// Compute the distance between two strings.
            /// </summary>
            private int compute(string s, string t)
            {
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];

                // Step 1
                if (n == 0)
                {
                    return m;
                }

                if (m == 0)
                {
                    return n;
                }

                // Step 2
                for (int i = 0; i <= n; d[i, 0] = i++)
                {
                }

                for (int j = 0; j <= m; d[0, j] = j++)
                {
                }

                // Step 3
                for (int i = 1; i <= n; i++)
                {
                    //Step 4
                    for (int j = 1; j <= m; j++)
                    {
                        // Step 5
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                        // Step 6
                        d[i, j] = Math.Min(
                            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                            d[i - 1, j - 1] + cost);
                    }
                }
                // Step 7
                return d[n, m];
            }
        }


    
}
