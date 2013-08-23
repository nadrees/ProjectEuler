using Lib.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _059
{
    /// <summary>
    /// Each character on a computer is assigned a unique code and the preferred standard is ASCII 
    /// (American Standard Code for Information Interchange). For example, uppercase A = 65, asterisk 
    /// (*) = 42, and lowercase k = 107.
    /// 
    /// A modern encryption method is to take a text file, convert the bytes to ASCII, then XOR each 
    /// byte with a given value, taken from a secret key. The advantage with the XOR function is that 
    /// using the same encryption key on the cipher text, restores the plain text; for example, 65 XOR 
    /// 42 = 107, then 107 XOR 42 = 65.
    /// 
    /// For unbreakable encryption, the key is the same length as the plain text message, and the key 
    /// is made up of random bytes. The user would keep the encrypted message and the encryption key 
    /// in different locations, and without both "halves", it is impossible to decrypt the message.
    /// 
    /// Unfortunately, this method is impractical for most users, so the modified method is to use a 
    /// password as a key. If the password is shorter than the message, which is likely, the key is 
    /// repeated cyclically throughout the message. The balance for this method is using a sufficiently 
    /// long password key for security, but short enough to be memorable.
    /// 
    /// Your task has been made easy, as the encryption key consists of three lower case characters. 
    /// Using cipher1.txt (right click and 'Save Link/Target As...'), a file containing the encrypted ASCII 
    /// codes, and the knowledge that the plain text must contain common English words, decrypt the message 
    /// and find the sum of the ASCII values in the original text.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // most common words according to wikipedia: http://en.wikipedia.org/wiki/Most_common_words_in_English
            var commonWords = new[] { "the", "be", "to", "of", "and" };

            var filesToDelete = Directory.EnumerateFiles(@".", "*.txt").Where(fn => fn != ".\\cipher1.txt");
            foreach (var file in filesToDelete)
                File.Delete(file);

            var cipherText = File.ReadAllText(@"cipher1.txt").Split(',').Select(n => (byte)int.Parse(n)).ToArray();

            // a = 97, z = 122
            for (byte i = 97; i <= 122; i++)
            {
                for (byte j = 97; j <= 122; j++)
                {
                    for (byte k = 97; k <= 122; k++)
                    {
                        var secret = new byte[] { i, j, k };
                        var decodedText = new Xor(secret).DoXor(cipherText, Encoding.ASCII);

                        bool isPotential = true;
                        foreach (var commonWord in commonWords)
                        {
                            if (!decodedText.Contains(commonWord))
                            {
                                isPotential = false;
                                break;
                            }
                        }

                        if (isPotential)
                        {
                            var bytes = Encoding.ASCII.GetBytes(decodedText);
                            Console.WriteLine(bytes.Select(b => (int)b).Sum());
                        }
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
