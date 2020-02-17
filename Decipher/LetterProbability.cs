using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class LetterProbability
    {
        public Dictionary<char, double> dictionary;

        public LetterProbability()
        {
            dictionary = new Dictionary<char, double>();
        }

        public void ReadFromFile(string filename)
        {
            string line;
            string[] separators = { " - " };

            using (StreamReader sr = new StreamReader(filename))
            {
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(separators, StringSplitOptions.None);
                    char letter = char.Parse(parts[0]);
                    double value = double.Parse(parts[1]);

                    dictionary.Add(letter, value);
                }
            }
        }

        public void AllProbabilitiesFromText (string filename)
        {
            string text = File.ReadAllText(filename);
            int i = 0;
            while(i<text.Length)
            {
                char current = text[i];
                if(!dictionary.ContainsKey(current)&&char.IsLetter(current))
                {
                    double probability = SingleProbability(text, current);

                    dictionary.Add(current, probability);
                }
                i++;
            }
        }

        private double SingleProbability(string text, char letter)
        {
            double occurences = 0;
            double count = 0;
            foreach(char c in text)
            {
                if (char.IsLetter(c))
                    count++;
                if (c == letter)
                    occurences++;
            }
            return occurences / count;
        }
    }
}
