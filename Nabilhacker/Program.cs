using System;
using System.Linq;
using System.Collections.Generic;

namespace Nabilhacker
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(Console.ReadLine(), out int T);
            for(int i = 0; i < T; i++)
                Console.WriteLine(HackThePassword(Console.ReadLine()));
        }

        static string HackThePassword(string input)
        {
            var passwordStack = new Stack<char>();
            var helperStack = new Stack<char>();

            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == '-')
                {
                    try
                    {
                        passwordStack.Pop();
                    }
                    catch(InvalidOperationException){ continue; }
                }
                else if(input[i] == '<')
                {
                    try
                    {
                        helperStack.Push(passwordStack.Pop());
                    }
                    catch(InvalidOperationException){ continue; }
                }
                else if(input[i] == '>')
                {
                    try
                    {
                        passwordStack.Push(helperStack.Pop());
                    }
                    catch(InvalidOperationException){ continue; }
                }
                else
                {
                    passwordStack.Push(input[i]);
                }
            }

            while(helperStack.Count > 0)
                passwordStack.Push(helperStack.Pop());

            string output =  string.Join("", passwordStack.ToArray().Reverse());

            return output;
        }
    }
}
