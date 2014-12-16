using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGrams
{

    class FileLoader
    {
        
        private int _bufferSize = 16384; 
        private FileLoader fileLoader;
        private String inputText = "";
        private String stopWords = "";
        private String textLocation = "";
        private String stopWordsLocation = "";

        private FileLoader()
        {

        }

        public FileLoader getInstance()
        {
            if (fileLoader == null)
                fileLoader = new FileLoader();
            return fileLoader;
        }

    
        private void setConfig(String language)
        {
            if (language.Equals(Constants.ENG))
            {
                textLocation = Constants.ENG_TEXT;
                stopWordsLocation = Constants.ENG_STOPWORDS;
            }
        }

        private void loadInformation()
        {
            if (textLocation.Equals("") | stopWordsLocation.Equals(""))
                throw new InvalidDataException("You didn't set a config.");
            try
            {
                loadText(textLocation);
                loadStopWords(stopWordsLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void loadText(String location)
        {
            StringBuilder builder = new StringBuilder();
            FileStream fStream = new FileStream(location, FileMode.Open, FileAccess.Read);
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
            }
            inputText = builder.ToString();

        }

        private void loadStopWords(String location)
        {
            StringBuilder builder = new StringBuilder();
            FileStream fStream = new FileStream(location, FileMode.Open, FileAccess.Read);
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
            }
            stopWords = builder.ToString();

        }
    }

}
