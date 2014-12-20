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
        private volatile static NGramTable nGramTable;

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

        public List<int> searchNGram(String ngram)
        {

            List<int> temp = new List<int>();
            try
            {
                temp = ngramTable[ngram];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return temp;

        }

        public int getCount()
        {
            return ngramTable.Keys.Count;
        }

        public List<int> searchForSimilarSentence(String number)
        {
            List<int> result = new List<int>();

            try
            {
                int num = Convert.ToInt32(number);
                List<String> sentences = ListRender.getInstance().getSentencesClean();
                String searchTerm = sentences[num];
                for (int i = 0; i < sentences.Count; i++)
                {
                    if (sentences[i].Contains(searchTerm))
                    {
                        result.Add(i);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

    }
}
