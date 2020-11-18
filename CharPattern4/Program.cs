using System;
using System.Text;

namespace CharPattern4
{
    class Program
    {
        static void Main(string[] args)
        {
            int l, c, h, w;
            int t = int.Parse(Console.ReadLine());

            for(int i = 0; i < t; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                l = int.Parse(input[0]);
                c = int.Parse(input[1]);
                h = int.Parse(input[2]);
                w = int.Parse(input[3]);

                var builder = new PatternBuilder();

                string output = string.Empty;
                builder.BuildPatternLine(w, c)
                                        .BuildStarsLine()
                                        .ReturnPattern(l, h, out output);
                
                Console.WriteLine(output);                        
            }
        }
    }

    public class PatternBuilder
    {
        private string _starsLine;
        private string _patternLine;

        public PatternBuilder BuildPatternLine(int width, int columns)
        {
            int chunk = width + 1;
            int total = chunk * columns + 1;

            char[] chars = new char[total];

            for(int i = 0; i < total; i++)
            {
                chars[i] = (i != 0 && i % chunk != 0) ? '.' : '*';
            }

            _patternLine = new string(chars);

            return this;
        }

        public PatternBuilder BuildStarsLine()
        {
            for(int i = 0; i < _patternLine.Length; i++)
                _starsLine += '*';

            return this;
        }

        public PatternBuilder ReturnPattern(int lines, int heigth, out string result)
        {
            var sb = new StringBuilder(_starsLine + Environment.NewLine);

            int singleRect = heigth + 1;
            int total = singleRect * lines;

            for(int i = 1; i <= total; i++)
            {
                if(i % singleRect == 0)
                    sb.AppendLine(_starsLine);
                
                else                    
                    sb.AppendLine(_patternLine);
            }

            result = sb.ToString();

            return this;
        }
    }
}
