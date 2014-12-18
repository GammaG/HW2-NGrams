using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGrams
{
    class NGramTable
    {
        private Dictionary<String, List<int>> ngramTable = new Dictionary<String,List<int>>();
        private static NGramTable nGramTable;

        private NGramTable()
        {

        }

        public static NGramTable getInstance()
        {
            if (nGramTable == null)
            {
                nGramTable = new NGramTable(); 
            }
            return nGramTable;
        }

        public void addNGram(String ngram, int row)
        {
            if (ngramTable.ContainsKey(ngram))
            {
                ngramTable[ngram].Add(row);
            }
            else
            {
                List<int> list = new List<int>();
                list.Add(row);
                ngramTable.Add(ngram, list);
            }
        }


    }
}
