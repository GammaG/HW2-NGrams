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

        private List<String> sentences;
        private List<String> stopwords;

        public void startCleaning()
        {
            sentences = ListRender.getInstance().getSentences();
            stopwords = ListRender.getInstance().getStopWords();
            startFiltering();
            ListRender.getInstance().setSentencesCleaned(sentences);

        }

        private void startFiltering()
        {
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

        private String filterStopWords(String s)
        {
            foreach (String stopWord in stopwords)
            {
                s.Replace(stopWord, "");
            }
            return s;
        }

    }
}
