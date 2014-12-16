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
                  
            
        }



       

            private class Loader{
                public void loadInformation(){
                      FileLoader fileLoader = FileLoader.getInstance();
                      fileLoader.setConfig(language);
                      fileLoader.loadInformation();
                      Console.WriteLine(fileLoader.getStopWords());
                      
                }
            }

            private void btnPrint_Click(object sender, EventArgs e)
            {
                if (loaderThread.IsAlive)
                {
                    resultsText.AppendText("\r\nLoading is still in progress.");
                    return;
                }
                resultsText.AppendText(FileLoader.getInstance().getStopWords());
                resultsText.AppendText(FileLoader.getInstance().getText());

            }

          

        
    }
}
