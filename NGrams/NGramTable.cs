using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public List<int> searchForSimilarSentence(String number, int minNGrams)
        {
            List<int> similarSentences = new List<int>();
            if (minNGrams < 0)
            {
                minNGrams = 2;
            }

            try
            {

               

                int num = Convert.ToInt32(number);
                List<String> sentences = ListRender.getInstance().getSentencesClean();
                String sentence = sentences[num];
          

                Regex regex = new Regex("[ ]+");
                String[] array = regex.Split(sentence);

                List<String> ngrams = new List<string>();
                for (int i = 0; i < array.Length - 1; i++)
                {
                    ngrams.Add(array[i] + " " + array[i + 1]);
                }


               
              
               
                Dictionary<int,int> counterDic = new Dictionary<int,int>();
                foreach(String s in ngrams){
                    List<int> locSentences = ngramTable[s];
                    foreach (int i in locSentences)
                    {
                        if (counterDic.ContainsKey(i))
                        {
                            counterDic[i] += 1;
                        }
                        else
                        {
                            counterDic.Add(i, 1);
                        }
                    }
                }
                foreach (int i in counterDic.Keys)
                {
                    if (counterDic[i] > minNGrams | counterDic[i] == minNGrams)
                    {
                        similarSentences.Add(i);
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return similarSentences;
        }

        public List<int> searchForSentencesContainingNGrams(String input)
        {
            List<int> list = new List<int>();

            Regex regex = new Regex("[ ]+");
            String[] array = regex.Split(input);

            List<String> ngrams = new List<string>();
            for (int i = 0; i < array.Length - 1; i++)
            {
                ngrams.Add(array[i] + " " + array[i + 1]);
            }

            foreach (String ngram in ngrams)
            {
                if (ngramTable.ContainsKey(ngram))
                {
                    foreach (int i in ngramTable[ngram])
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                    }
                }
            }

            return list;
        }


    }
}
