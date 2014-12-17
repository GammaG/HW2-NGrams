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
        protected Thread loaderThread;
        public Form1()
        {
           
            InitializeComponent();
            languageBox.SelectedIndex = 0;
        }



        private void btnLoadF_Click(object sender, EventArgs e)
        {
            if (languageBox.SelectedIndex.Equals("English"))
                language = Constant.ENG;

            loaderThread = new Thread(new Loader().loadInformation);
            loaderThread.Start();

            while (loaderThread.IsAlive)
            {
                Thread.Sleep(1000);
            }
            
            ListRender listRender = ListRender.getInstance();
            listRender.renderSentences(FileLoader.getInstance().getText());
            listRender.renderStopWords(FileLoader.getInstance().getStopWords());

            resultsText.AppendText(listRender.getSentences().Count + " sentences were loaded.\r\n");
            resultsText.AppendText(listRender.getStopWords().Count + " stopwords were loaded.\r\n");
                      
            
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
               

            }

          

        
    }
}
