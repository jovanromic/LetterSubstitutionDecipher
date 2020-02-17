using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class Comparer
    {
        public LetterProbability ciphered;
        public LetterProbability plain;
        public Dictionary<char, char> pairs;

        public Comparer(string filetext, string fileletters)
        {
            ciphered = new LetterProbability();
            plain = new LetterProbability();
            pairs = new Dictionary<char, char>();

            ciphered.AllProbabilitiesFromText(filetext);
            plain.ReadFromFile(fileletters);

            DeterminePairs();
        }

        private void DeterminePairs()
        {
            foreach(KeyValuePair<char,double> clp in ciphered.dictionary)
            {
                char key = clp.Key;
                double value = clp.Value;

                //ako je slovo sifrovano
                if(plain.dictionary.ContainsKey(key))
                {
                    double difference = 200;
                    char deciphered_letter = '+';
                    foreach(KeyValuePair<char,double> plp in plain.dictionary)
                    {
                        double current_difference = Math.Abs(value - plp.Value);
                        if(current_difference<difference)
                        {
                            difference = current_difference;
                            deciphered_letter = plp.Key;
                        }
                    }

                    pairs.Add(key, deciphered_letter);
                }
                //u protivnom se slovo prepisuje
                else
                {
                    pairs.Add(key, key);
                }
            }
        }

        public string Decipher(string file)
        {
            string plaintext = "";
            int i = 0;
            while(i<file.Length)
            {
                char current = file[i];
                if (char.IsLetter(current) && pairs.ContainsKey(current))
                    plaintext += pairs[current].ToString();
                else
                    plaintext += current.ToString();

                i++;
            }
            return plaintext;
        }

    }
}
