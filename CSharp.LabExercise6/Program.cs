using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    class Validations
    {
        public static bool HasNoWhitespace(string text)
        {
            foreach (char ch in text)
            {
                if (Char.IsWhiteSpace(ch))
                {
                    Console.WriteLine("Please Remove Whitespaces");
                    return false;
                }
            }
            return true;
        }
        public static bool IsValidLetter(string text)
        {
            string validLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char ch in text.ToUpper())
            {
                if (!validLetters.Contains(ch))
                {
                    Console.WriteLine("Please Input A Valid Word");
                    return false;
                }
            }
            return true;
        }
    }
    class Letters
    {
        public Dictionary<int, string> LetterWithValue { get; set; }
        public Letters()
        {
            LetterWithValue = new Dictionary<int, string>()
            {
                {1, "AEIOULNRST" },
                {2, "DG" },
                {3, "BCMP" },
                {4, "FHVWY" },
                {5, "K" },
                {8, "JX" },
                {10, "QZ" }
            };
        }
    }

    class Scrabble
    {
        readonly Letters letters;
        public Scrabble()
        {
            this.letters = new Letters();
        }

        public void Start()
        {
            var answer = "y";
            while (answer.Trim().ToLower().Equals("y"))
            {
                Console.Write("Enter A Word: ");
                string inputWord = Console.ReadLine();
                int points = 0;

                if (Validations.HasNoWhitespace(inputWord) && Validations.IsValidLetter(inputWord))
                {
                    foreach (char ch in inputWord.ToUpper())
                    {
                        foreach (KeyValuePair<int, string> pair in this.letters.LetterWithValue)
                        {
                            if (pair.Value.Contains(ch))
                            {
                                points += pair.Key;
                            }
                        }
                    }
                    Console.WriteLine($"The \"{inputWord}\" word is worth {points} points");
                }

                Console.Write("Do you want to continue(y/n)? ");
                answer = Console.ReadLine().ToLower();

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Scrabble scrabble = new();
            scrabble.Start();
        }
    }
}
