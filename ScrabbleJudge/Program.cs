using System;
using System.Collections.Generic;
    
class Program
{
    static void Main(string[] args)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>
        {
            {'A', 1},
            {'E', 1},
            {'I', 1},
            {'O', 1},
            {'U', 1},
            {'L', 1},
            {'N', 1},
            {'R', 1},
            {'S', 1},
            {'T', 1},
            {'D', 2},
            {'G', 2},
            {'B', 3},
            {'C', 3},
            {'M', 3},
            {'P', 3},
            {'F', 4},
            {'H', 4},
            {'V', 4},
            {'W', 4},
            {'Y', 4},
            {'K', 5},
            {'X', 8},
            {'J', 8},
            {'Q', 10},
            {'Z', 10},
        };

        while(true)
        {
            Console.WriteLine("Podaj słowo: ");
            int score = 0;
            string input = Console.ReadLine().ToUpper();
            
            foreach(char i in input)
            {
                score += dict[i];
            }

            Console.WriteLine($"Twój wynik to: {score}");
        }        
    }
}
