using System;

namespace Square
{
    public class Kata
    {
        public static int SquareDigits(int n)
        {
            string sum = string.Empty;
            char[] c = n.ToString().ToCharArray();
            
            for(int i = 0; i < c.Length; i++)
            {
            int x = int.Parse(c[i].ToString());
            System.Console.WriteLine(c[i]);
            sum += (Math.Pow(x, 2)).ToString();
            }
            
            return int.Parse(sum);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.SquareDigits(9119));
        }
    }
}
