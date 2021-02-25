using System;
using System.Linq;
using System.Collections.Generic;

namespace AlphabetWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.AlphabetWar("mrpcsdb"));
            Console.WriteLine(Kata.AlphabetWar("zdqmwpbs"));
            Console.WriteLine(Kata.AlphabetWar("zzzzs"));
            Console.WriteLine(Kata.AlphabetWar("wwwwwwz"));
        }
    }
}


public class Kata
{
    static Dictionary<char, int> Left = new Dictionary<char, int>
    {
        {'w', 4},
        {'p', 3},
        {'b', 2},
        {'s', 1}  
    };
    static Dictionary<char, int> Right = new Dictionary<char, int>
    {
        {'m', 4},
        {'q', 3},
        {'d', 2},
        {'z', 1}  
    };
    public static string AlphabetWar(string fight)
    {
        int left = fight.Where(x => Left.ContainsKey(x)).Sum(x => Left[x]);
        int right = fight.Where(x => Right.ContainsKey(x)).Sum(x => Right[x]);
        
        return left > right ? "Left side wins!" : (right > left ? "Right side wins!" : "Let's fight again!");
    }
}
