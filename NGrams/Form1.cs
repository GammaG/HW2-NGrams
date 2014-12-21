using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NGrams
{
    public partial class MainFrame : Form
    {

        private static String language = "";
        private static Thread textFilterThread;
        private static Thread loaderThread;
        private static Thread generateNGramsThread;
        private static Thread printCleanSentencesThread;
        private static Thread printResultSentencesThread;
        private static String input; 
        private static List<int> resultList = new List<int>();
        private static Boolean finised = false;
       
        public MainFrame()
        {
            InitializeComponent();
            languageBox.SelectedIndex = 0;
        }



        private void btnLoadF_Click(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex.Equals("English"))
                language = Constant.ENG;

            finised = false;
            loaderThread = new Thread(new Loader().loadInformation);
            loaderThread.Start();


            new Thread(checkThreadLoader).Start();     

            
        }

        private void checkThreadLoader()
        {
            while (loaderThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            //AppendTextBox("StopWordsFilter has finished.\r\n");
            Thread.Sleep(500);

            ListRender listRender = ListRender.getInstance();
            listRender.renderSentences(FileLoader.getInstance().getText());
            listRender.renderStopWords(FileLoader.getInstance().getStopWords());

            appendTextBox(listRender.getSentences().Count + " sentences were loaded.");
            appendTextBox(listRender.getStopWords().Count + " stopwords were loaded.");

            appendTextBox("StopWordsFilter active please wait...");
            textFilterThread = new Thread(new StopWorldFilter().startCleaning);
            textFilterThread.Start();

            new Thread(checkThreadFilter).Start();
            

        }


        private void checkThreadFilter()
        {
            while (textFilterThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            appendTextBox("StopWordsFilter has finished.\r\n");

            appendTextBox("NGram generation started.");
            generateNGramsThread = new Thread(genNGrams);
            generateNGramsThread.Start();

            new Thread(checkNGramGeneration).Start();
        }
       

            private class Loader{
                public void loadInformation(){
                      FileLoader fileLoader = FileLoader.getInstance();
                      fileLoader.setConfig(language);
                      fileLoader.loadInformation();
                      
                      
                }
            }

            private void btnPrint_Click(object sender, EventArgs e)
            {
                printCleanSentencesThread = new Thread(printAllSentences);
                printCleanSentencesThread.Start();

            }

            private void printAllSentences()
            {
                if (!finised)
                {
                    appendTextBox("There is currently a process running, please wait until it has finished.");
                    return;
                }
                List<String> temp = ListRender.getInstance().getSentences();
                foreach (String s in temp)
                    appendTextBox(s);
            }

            private void addTextToResult(String message)
            {
                resultsText.AppendText(message + "\r\n");
            }

            private void appendTextBox(string value)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(appendTextBox), new object[] { value });
                    return;
                }
                //ActiveForm.Text += value;
                addTextToResult(value);
            }

          

            private void genNGrams()
            {
                new NGramGenerator().startGenNGrams();
            }

            private void checkNGramGeneration()
            {
                while (generateNGramsThread.IsAlive)
                {
                    Thread.Sleep(250);
                }
                appendTextBox("NGram generation has finished.");
                finised = true;
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
               input = searchBox.Text;
               if (input.Length == 0)
               {
                   appendTextBox("Your searchTerm is to short.");
                   return;
               }

               new Thread(search).Start();
            }

            private void search()
            {
                if (!finised)
                {
                    appendTextBox("There is currently a process running, please wait until it has finished.");
                    return;
                }
                NGramTable table = NGramTable.getInstance();
                if (table.getCount() == 0)
                {
                    appendTextBox("There are no NGrams available.");
                    return;
                }

               resultList = table.searchNGram(input);
               if (resultList.Count == 0)
               {
                   appendTextBox("Your term: \"" + input + "\" wasn't found.");
                   return;
               }
               String temp = "Your NGram: \""+input+"\" was found in line ";
               foreach (int i in resultList)
               {
                   temp += i+1 + ", ";
               }

               appendTextBox(temp.Substring(0, temp.Length - 2));
            }

            private void btn_print_result_Click(object sender, EventArgs e)
            {
              printResultSentencesThread = new Thread(printResult);
              printResultSentencesThread.Start();
            }

        private void printResult(){
            List<String> list = ListRender.getInstance().getSentences();

            while (!finised)
            {
                Thread.Sleep(250);
            }

            foreach (int i in resultList)
            {
               appendTextBox("\r\n"+ list[i] + "\r\n");
            }
        }

        private void btn_abort_Click(object sender, EventArgs e)
        {
            if (printCleanSentencesThread.IsAlive)
                printCleanSentencesThread.Abort();
            else if (printResultSentencesThread.IsAlive)
                printResultSentencesThread.Abort();
        }

        private void btnSeachForSimilar_Click(object sender, EventArgs e)
        {

            input = searchBox.Text;
            if (input.Length == 0 )
            {
                appendTextBox("Your searchTerm is to short.");
                return;
            }

            Match match = Regex.Match(input, "[0-9]+");
            if (!match.Success)
            {
                appendTextBox("Please enter a number out of the collection to match for.");
            }

            int num = Convert.ToInt32(input);
            int temp = ListRender.getInstance().getSentencesClean().Count;
            if (num < 0 | num > temp)
            {
                appendTextBox("Your choosen sentence does not exist in the collection, max index is "+temp);
            }

            appendTextBox("Your sentence is: \"" + ListRender.getInstance().getSentenceFromCollection(num)+"\"\r\n");

            new Thread(searchForSimilarSentence).Start();
           
        }
        private void searchForSimilarSentence()
        {
            if (!finised)
            {
                appendTextBox("There is currently a process running, please wait until it has finished.");
                return;
            }
            NGramTable table = NGramTable.getInstance();
            if (table.getCount() == 0)
            {
                appendTextBox("There are no NGrams available.");
                return;
            }

            resultList = table.searchForSimilarSentence(input);
            if (resultList.Count == 0)
            {
                appendTextBox("No sentences similar to your choosen: \"" + input + "\" has been found.");
                return;
            }

                    
            String temp = "Your sentence: \"" + input + "\" is similar to: ";
            foreach (int i in resultList)
            {
                temp += i + 1 + ", ";
            }

            appendTextBox(temp.Substring(0, temp.Length - 2));

        }

        private void btn_printSentenceByID_Click(object sender, EventArgs e)
        {

            if (!finised)
            {
                appendTextBox("There is currently a process running, please wait until it has finished.");
                return;
            }
            input = searchBox.Text;
            if (input.Length == 0)
            {
                appendTextBox("Your searchTerm is to short.");
                return;
            }

            Match match = Regex.Match(input, "[0-9]+");
            if (!match.Success)
            {
                appendTextBox("Please enter a number out of the collection to match for.");
            }

            int num = Convert.ToInt32(input);
            int temp = ListRender.getInstance().getSentencesClean().Count;
            if (num < 0 | num > temp)
            {
                appendTextBox("Your choosen sentence does not exist in the collection, max index is " + temp);
            }

            appendTextBox(ListRender.getInstance().getSentenceFromCollection(num));
        }

        private void btnSearchByTerm_Click(object sender, EventArgs e)
        {

        }


    }
}
