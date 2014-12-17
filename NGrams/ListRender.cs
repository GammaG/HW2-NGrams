using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NGrams
{
    class ListRender
    {
        private List<String> sentences = new List<string>();
        private List<String> stopWords = new List<string>();
        private static ListRender listRender; 

        private ListRender()
        {

        }

        public static ListRender getInstance()
        {
            if (listRender == null)
            {
                listRender = new ListRender();
            }
            return listRender;
        }

        public void renderSentences(String text){
            if (sentences.Count > 0)
            {
                sentences.Clear();
            }
            Regex regex = new Regex("[\\n]+");
            
            string[] array = regex.Split(text);
            sentences.AddRange(array);
          
        }

        public void renderStopWords(String stopwords)
        {
            if (stopWords.Count > 0)
            {
                stopWords.Clear();
            }
            Regex regex = new Regex("[\\n]+");

            string[] array = regex.Split(stopwords);
            stopWords.AddRange(array);


        }

        public List<String> getSentences()
        {
            return sentences;
        }

        public List<String> getStopWords()
        {
            return stopWords;
        }
    }
}
