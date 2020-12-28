using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, int> precedence = new Dictionary<char, int>
    {
        {'(', 0},
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'^', 3}
    };
    static string ReversedPolishNotation(string input)
    {
        string output = String.Empty;
        Stack<char> operands = new Stack<char>();

        for(int i = 0; i < input.Length; i++)
        {
            switch(input[i])
            {
                case '(':
                    operands.Push(input[i]);
                    break;
                case ')':
                    while(operands.Peek() != '(')
                        output += operands.Pop();
                    operands.Pop();
                    break;
                case '+':
                    if(precedence[operands.Peek()] > precedence[input[i]])
                    {
                        while(precedence[operands.Peek()] >= precedence[input[i]])
                            output += operands.Pop();
                    }
                    operands.Push(input[i]);
                    break;
                case '-':
                    goto case '+';
                case '*':
                    goto case '+';
                case '/':
                    goto case '+';
                case '^':
                    operands.Push(input[i]);
                    break;
                default:
                    output += input[i];
                    break;
            }
        }
        while(operands.TryPop(out char op))
            output += op;

        return output;
    }

    static void Main(string[] args)
    {
        // int t = int.Parse(Console.ReadLine());
        // for(int i = 0; i < t; i++)
        // {
        //     Console.WriteLine(ReversedPolishNotation(Console.ReadLine()));
        // }
        int i = 0x13F22;
        //System.Console.WriteLine(i.ToString("X"));
        System.Console.WriteLine(i);
        System.Console.WriteLine(Convert.ToString(i, 2));
        byte c1 = (byte)(i >> 8);
        System.Console.WriteLine(Convert.ToString(c1,2));
        byte c2 = (byte)((i << 8) >> 8);
        System.Console.WriteLine(Convert.ToString(c2,2));
        int[] ints = new int[3];
        int j = 0;
        foreach(var n in ints)
        {
            Console.WriteLine(j);
            j++;
        }
        Console.WriteLine(j);

    }
}