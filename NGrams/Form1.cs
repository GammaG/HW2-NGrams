using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NGrams
{
    public partial class Form1 : Form
    {

        private static String language = "";
        private static Thread textFilterThread;
        private static Thread loaderThread;
        private static Thread generateNGramsThread;
        private static String input; 
        private Boolean dataValid = false;
       
        public Form1()
        {
            InitializeComponent();
            languageBox.SelectedIndex = 0;
        }



        private void btnLoadF_Click(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex.Equals("English"))
                language = Constant.ENG;

            if (dataValid)
            {
                appendTextBox("New Datasource has been set, please run NGram generation again.");
            }
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
            dataValid = true;
        }


        private void checkThreadFilter()
        {
            while (textFilterThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            appendTextBox("StopWordsFilter has finished.\r\n");
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
                List<String> temp = ListRender.getInstance().getSentencesClean();
                foreach (String s in temp)
                    Console.WriteLine(s);

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

            private void btnNGrams_Click(object sender, EventArgs e)
            {
                if (textFilterThread.IsAlive | loaderThread.IsAlive )
                {
                    appendTextBox("There is currently a process running, please wait until it has finished.");
                    return;
                }
                if(!dataValid){
                    appendTextBox("There is no input text available, please load data first.");
                    return;
                }
                appendTextBox("NGram generation started.");
                generateNGramsThread = new Thread(genNGrams);
                generateNGramsThread.Start();

                new Thread(checkNGramGeneration).Start();


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
                if (textFilterThread.IsAlive | loaderThread.IsAlive | generateNGramsThread.IsAlive)
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
               List<int> list = table.searchNGram(input);
               if (list.Count == 0)
               {
                   appendTextBox("Your term: " + input + " wasn't found.");
                   return;
               }
               String temp = "Your NGram: "+input+" was found in line ";
               foreach (int i in list)
               {
                   temp += i+1 + ", ";
               }

               appendTextBox(temp.Substring(0, temp.Length - 2));
            }


    }
}
