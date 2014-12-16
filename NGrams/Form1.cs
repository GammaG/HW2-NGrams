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

        Thread loaderThread;
        public Form1()
        {
            InitializeComponent();
        }



        private void btnLoadF_Click(object sender, EventArgs e)
        {
            loaderThread = new Thread(new Loader().loadInformation);
            loaderThread.Start();
                      
            
        }







            private class Loader{
                public void loadInformation(){
                      FileLoader fileLoader = FileLoader.getInstance();
                      fileLoader.setConfig(Constant.ENG);
                      fileLoader.loadInformation();
                      Console.WriteLine(fileLoader.getStopWords());
                }
            }

            private void btnPrint_Click(object sender, EventArgs e)
            {
                loaderThread.Join();
                resultsText.AppendText(FileLoader.getInstance().getStopWords());
                resultsText.AppendText(FileLoader.getInstance().getText());

            }

        
    }
}
