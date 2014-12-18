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
       
        public Form1()
        {
           
            InitializeComponent();
            languageBox.SelectedIndex = 0;
        }



        private void btnLoadF_Click(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex.Equals("English"))
                language = Constant.ENG;

            Thread loaderThread = new Thread(new Loader().loadInformation);
            loaderThread.Start();

            while (loaderThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            
            ListRender listRender = ListRender.getInstance();
            listRender.renderSentences(FileLoader.getInstance().getText());
            listRender.renderStopWords(FileLoader.getInstance().getStopWords());

            Thread.Sleep(250);

            resultsText.AppendText(listRender.getSentences().Count + " sentences were loaded.\r\n");
            resultsText.AppendText(listRender.getStopWords().Count + " stopwords were loaded.\r\n");

            resultsText.AppendText("StopWordsFilter active please wait...\r\n");
            textFilterThread = new Thread(new StopWorldFilter().startCleaning);
            textFilterThread.Start();

            new Thread(checkThread).Start();
        }


        public void checkThread()
        {
            while (textFilterThread.IsAlive)
            {
                Thread.Sleep(250);
            }
            AppendTextBox("StopWordsFilter has finished.\r\n");
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

            public void AppendTextBox(string value)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                    return;
                }
                //ActiveForm.Text += value;
                addTextToResult(value);
            }

          

        
    }
}
