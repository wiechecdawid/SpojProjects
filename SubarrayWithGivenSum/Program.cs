using System;
using System.Linq;

namespace SubarrayWithGivenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // int T = int.Parse(Console.ReadLine());
            // for(int i = 0; i < T; i++)
            // {
            //     string[] ns = Console.ReadLine().Split(' ');
            //     int N = int.Parse(ns[0]);
            //     int S = int.Parse(ns[1]);
                
            //     var A = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                
            //     Console.WriteLine(FindSubString(A, N, S));
            // }
            var b = new B();
        }
    }

    class A
    {
        public A()
        {
            Console.WriteLine(x);
        }
        public int x = 5;
    }
    class B : A
    {
        public B()
        {
            this.x = 1;
            base.x = 5;
            Console.WriteLine($"{x} {base.x} {object.ReferenceEquals(this.x, base.x)}");
        }
    }
}
