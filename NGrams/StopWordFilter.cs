using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NGrams
{
    public class StopWorldFilter
    {

        private List<String> sentencesOrg;
        private List<String> sentences = new List<String>();
        private List<String> stopwords;

        public void startCleaning()
        {
            sentencesOrg = ListRender.getInstance().getSentences();
            stopwords = ListRender.getInstance().getStopWords();

            foreach (String s in sentencesOrg)
            {
                sentences.Add(s);
            }

            startFiltering();
            ListRender.getInstance().setSentencesCleaned(sentences);

        }

        private void startFiltering()
        {
            
                for (int j = 0; j < stopwords.Count; j++)
                {
                    stopwords[j] = removeUnusedSigns(stopwords[j]);
                }

                for (int i = 0; i < sentences.Count; i++)
                {
                    String s = sentences[i];
                    s = filterNumberAndSeperator(s);
                    sentences[i] = filterStopWords(s);
                }
        }

        private String filterNumberAndSeperator(String s)
        {
            if (s == "")
            {
                return s;
            }
            Regex regex = new Regex("[\\t]+");
            string[] array = regex.Split(s);
            if (array.Count() > 1)
                return array[1];
            return array[0];
        }

        private String removeUnusedSigns(String s)
        {
           return Regex.Replace(s, "\\r", String.Empty);
        }

        private String filterStopWords(String s)
        {
            String temp = s.ToLower();

            string pattern = "";

            //foreach (string word in stopwords)
            //{

                pattern = " (" + string.Join("|", stopwords) + ") ";
                //pattern = @"\b" + word + @"\b";
                temp = Regex.Replace(temp, pattern, " ");
                temp = Regex.Replace(temp, "[\\r.]", String.Empty);

            //}

            return temp;
        }

    }
}
