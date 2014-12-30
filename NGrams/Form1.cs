using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


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
        private static volatile Stopwatch timer = new Stopwatch(); 
        private static String NGRAM = "NGram";
        private static String TERM = "Terms";
        private static String SIMILAR = "Similar";

       
        public MainFrame()
        {
            InitializeComponent();
            languageBox.SelectedIndex = 0;
            chart.Series.Clear();
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
            timer.Reset();
            timer.Start();
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
            timer.Stop();
            appendTimeBox(timer.ElapsedTicks + " Ticks for Loading");
            textFilterThread = new Thread(new StopWorldFilter().startCleaning);
            textFilterThread.Start();

            new Thread(checkThreadFilter).Start();
          

        }


        private void checkThreadFilter()
        {
            timer.Reset();
            timer.Start();
            while (textFilterThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            appendTextBox("StopWordsFilter has finished.\r\n");

            appendTextBox("NGram generation started.");
            generateNGramsThread = new Thread(genNGrams);
            generateNGramsThread.Start();

            timer.Stop();
            appendTimeBox(timer.ElapsedTicks + " Ticks for Filtering");

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
                if (NGramTable.getInstance().getCount() == 0)
                {
                    appendTextBox("Please load data first.");
                    return;
                }
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

            private void appendTimeBox(string value)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(appendTimeBox), new object[] { value });
                    return;
                }
              
                resultTimes.AppendText(value + "\r\n");
            }

          

            private void genNGrams()
            {
                new NGramGenerator().startGenNGrams();
            }

            private void checkNGramGeneration()
            {
                timer.Reset();
                timer.Start();
                while (generateNGramsThread.IsAlive)
                {
                    Thread.Sleep(250);
                }
                appendTextBox("NGram generation has finished.");
                finised = true;
                timer.Stop();
                appendTimeBox(timer.ElapsedTicks + " Ticks for NGram Generation");
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {
                if (NGramTable.getInstance().getCount() == 0)
                {
                    appendTextBox("There are no NGrams available.");
                    return;
                }
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

               new Thread(search).Start();
            }

            private void search()
            {
                timer.Reset();
                timer.Start();
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
               timer.Stop();
               appendTimeBox(timer.ElapsedTicks + " Ticks for NGram Search"); 
               appendTextBox(temp.Substring(0, temp.Length - 2));
               appendChart(timer.ElapsedTicks, NGRAM);
               new Thread(generateLevenshteinDistance).Start();
            }

            private void btn_print_result_Click(object sender, EventArgs e)
            {
                if (!finised)
                {
                    appendTextBox("There is currently a process running, please wait until it has finished.");
                    return;
                }
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
            if (NGramTable.getInstance().getCount() == 0)
            {
                appendTextBox("There are no NGrams available.");
                return;
            }
            if (!finised)
            {
                appendTextBox("There is currently a process running, please wait until it has finished.");
                return;
            }

            input = searchBox.Text;
            if (input.Length == 0 )
            {
                appendTextBox("Your searchTerm is to short.");
                return;
            }

            Match match = Regex.Match(input, "[0-9]+");
            if (!match.Success)
            {
                appendTextBox("Please enter a number or more seperated by ' ' out of the collection to match for.");
                return;
            }

            int temp = ListRender.getInstance().getSentencesClean().Count;
            Regex regex = new Regex("[ ]+");
            string[] array = regex.Split(input);
            try { 
            foreach (String s in array)
            {
                int num = Convert.ToInt32(s);
                if (num < 0 | num > temp)
                {
                    appendTextBox("Your choosen sentence does not exist in the collection, max index is " + temp);
                }

                appendTextBox("\r\n Sentence to match for: " + ListRender.getInstance().getSentenceFromCollection(num) + "\r\n");

            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                appendTextBox("At least of your terms wasn't valid.");
                return;
            }
            
               

            new Thread(searchForSimilarSentence).Start();
           
        }
        private void searchForSimilarSentence()
        {


            timer.Reset();
            timer.Start();
            NGramTable table = NGramTable.getInstance();
   
            resultList = table.searchForSimilarSentence(input, Convert.ToInt32(minNGrams.Value));
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

            timer.Stop();
            appendTimeBox(timer.ElapsedTicks + " Ticks for Similar Search");
            appendTextBox(temp.Substring(0, temp.Length - 2));
            appendChart(timer.ElapsedTicks, SIMILAR);
            new Thread(generateLevenshteinDistance).Start();

        }

        private void btn_printSentenceByID_Click(object sender, EventArgs e)
        {
            if (NGramTable.getInstance().getCount() == 0)
            {
                appendTextBox("Please load data first.");
                return;
            }
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
            if (NGramTable.getInstance().getCount() == 0)
            {
                appendTextBox("There are no NGrams available.");
                return;
            }
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
            if (!input.Contains(" "))
            {
                appendTextBox("Please use at least 2 words for a valid search!");
                return;
            }
            new Thread(searchMatchingPattern).Start();
        }

        private void searchMatchingPattern()
        {

            timer.Reset();
            timer.Start();
            NGramTable table = NGramTable.getInstance();
            
            resultList = table.searchForSentencesContainingNGrams(input);
            if (resultList.Count == 0)
            {
                appendTextBox("No sentences have been found to your given NGram: \"" + input + "\" has been found.");
                return;
            }


            String temp = "\r\nYour NGrams: \"" + input + "\" have been found in: ";
            foreach (int i in resultList)
            {
                temp += i + 1 + ", ";
            }

            timer.Stop();
            appendTimeBox(timer.ElapsedTicks + " Ticks for Term Search");
            appendTextBox(temp.Substring(0, temp.Length - 2));
            appendChart(timer.ElapsedTicks, TERM);
            new Thread(generateLevenshteinDistance).Start();
        }


        private void appendChart(long value, string mode)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<long, string>(appendChart), new object[] { value, mode });
                return;
            }

          
            if (!chart.Series.IsUniqueName(mode))
            {
                chart.Series.Remove(chart.Series[mode]);

            }

            chart.Series.Add(mode);
            chart.Series[mode].ChartType = SeriesChartType.Column;
            chart.ChartAreas[0].AxisY.Title = "cpuTimes";
            
            if(mode.Equals(NGRAM))
                chart.Series[mode].Points.AddXY(1, value);

            if (mode.Equals(TERM))
                chart.Series[mode].Points.AddXY(2, value);

            if (mode.Equals(SIMILAR))
                chart.Series[mode].Points.AddXY(3, value);


        }

        private void generateLevenshteinDistance()
        {
            if (resultList.Count < 1)
            {
                return;
            }
            LevenshteinDistance levenshteinDistance = LevenshteinDistance.getInstance();
            levenshteinDistance.clear();
            levenshteinDistance.setSerachTerm(input);
            levenshteinDistance.setResultSet(resultList);

            List<String> result = levenshteinDistance.generateDistance();
            if (result.Count > 0)
            {
                appendTimeBox("");
                appendTimeBox("LevenshteinDistance for: "+input+"\r\n");
                appendTimeBox("Changes are needed to change the input into the result:");

                foreach (String s in result)
                {
                    appendTimeBox(s);
                }
                appendTimeBox("");
            }
            
        }

    }
}

