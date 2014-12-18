﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NGrams
{
    class NGramGenerator
    {
       private NGramTable nGramTable = NGramTable.getInstance();
       private ListRender listRender = ListRender.getInstance();

        public void startGenNGrams()
        {
            List<String> sentences = listRender.getSentencesClean();

            for (int i = 0; i < sentences.Count; i++)
            {
                String s = sentences[i];
                Regex regex = new Regex("[ ]+");
                String[] array = regex.Split(s);

                for (int j = 0; j < array.Length-1; j++)
                {
                    String nGram = array[j] + " " + array[j + 1];
                    nGramTable.addNGram(nGram, i);
                }
            }


        }


    }
}
