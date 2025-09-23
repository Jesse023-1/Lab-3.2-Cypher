using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;




namespace Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Reads Encrypted text file
            string path = @"C:/Users/Jesse John/Documents/School/.NET Development/Assignment 3/Encrypted.txt";
            string text = File.ReadAllText(path);


            string[] lines = File.ReadAllLines(path);
            Console.WriteLine(text);

            // 2. Number of lines and characters
            Console.WriteLine($"Number of characters including spaces = {text.Length}");

            char[] chars = text.ToCharArray();

            int count = 0;
            foreach (char c in chars)
            {
                if (char.IsLetter(c))
                {
                    count++;
                }

            }
            Console.WriteLine($"Number of letter characters without space = {count}");
            Console.WriteLine($"Number of lines = {lines.Length}");

            // 3. Most occuring characters

            Dictionary<char, int> letters = new Dictionary<char, int>();
            char occuring = '\0';
            int maxCount = 0;

            foreach (char c in text.ToLower())
            {
                if (char.IsLetter(c))
                {
                    if (letters.ContainsKey(c))
                    {
                        letters[c]++;
                    }
                    else
                    {
                        letters[c] = 1;
                    }

                    if (letters[c] > maxCount)
                    {
                        maxCount = letters[c];
                        occuring = c;
                    }
                }
            }
            Console.WriteLine($"The most occurring character is '{occuring}' with {maxCount} occurrences.");

            // 4. Decrypting
            int shift = 13;
            string decryptedText = DecryptText(text, shift);

            Console.WriteLine("Decrypt text? Y/N");

            string yes = "Y";
            string no = "N";
            string answer = Console.ReadLine();
            answer = answer.ToUpper();
            
            if (answer.Equals(yes))
            {
                Console.WriteLine($"{decryptedText}");
            } else if (answer.Equals(no))
            {
                Console.WriteLine("Good bye");
            }

            // 5. Writing to output file

           
            Console.WriteLine("Enter filename");
            string filename = Console.ReadLine();

            File.WriteAllText(filename, decryptedText);
            Console.WriteLine("Writing decrypted text to file");


            
        }
        static string DecryptText(string input, int shift)
        {
            char DecryptChar(char c)
            {
                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    return (char)(((c - baseChar - shift + 26) % 26) + baseChar);
                }
                return c; 
            }

            char[] decryptedChars = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                decryptedChars[i] = DecryptChar(input[i]);
            }

            return new string(decryptedChars);
        }
    }
}