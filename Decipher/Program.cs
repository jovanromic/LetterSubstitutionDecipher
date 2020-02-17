using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("1 (sifrovano).txt");
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Šifrovani tekst:\n"+text+ "\n\nDešifrovani tekst:\n");

            Comparer comparer = new Comparer("1 (sifrovano).txt", "1 (verovatnoce).txt");

            string plain = comparer.Decipher(text);
            File.WriteAllText("1 (desifrovano).txt", plain);
            Console.WriteLine(plain);
        }
    }
}
