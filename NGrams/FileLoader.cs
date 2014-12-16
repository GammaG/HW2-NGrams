using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NGrams
{

    class FileLoader
    {
        
        private int _bufferSize = 16384; 
        private static volatile FileLoader fileLoader;
        private String inputText = "";
        private String stopWords = "";
        private String textLocation = "";
        private String stopWordsLocation = "";

        private FileLoader()
        {

        }

        public static FileLoader getInstance()
        {
            if (fileLoader == null)
                fileLoader = new FileLoader();
            return fileLoader;
        }

    
        public void setConfig(String language)
        {
            if (language.Equals(Constant.ENG))
            {
                textLocation = Constant.ENG_TEXT;
                stopWordsLocation = Constant.ENG_STOPWORDS;
            }
        }

        public void loadInformation()
        {
            if (textLocation.Equals("") | stopWordsLocation.Equals(""))
                throw new InvalidDataException("You didn't set a config.");
            try
            {
                Thread loadInformationThread = new Thread(fileLoader.loadText);
                Thread loadStopWordsThread = new Thread(fileLoader.loadStopWords);
                loadInformationThread.Start();
                loadStopWordsThread.Start();
             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void loadText()
        {
            StringBuilder builder = new StringBuilder();
            FileStream fStream = new FileStream(textLocation, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);

                // Can't do much with 0 bytes        
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");

                while (charsRead > 0)
                {
                    builder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
                streamReader.Close();
                fStream.Close();
            }
            inputText = builder.ToString();

        }

        private void loadStopWords()
        {
            StringBuilder builder = new StringBuilder();
            FileStream fStream = new FileStream(stopWordsLocation, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);

                // Can't do much with 0 bytes        
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");

                while (charsRead > 0)
                {
                    builder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
                streamReader.Close();
                fStream.Close();
            }
            stopWords = builder.ToString();
            
        }

        public String getStopWords()
        {
            return stopWords;
        }

        public String getText()
        {
            return inputText;
        }
    }

}
