using System;
using System.Collections.Generic;
using System.Linq;

namespace CarParkEscape
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] carpark = new int[,] { { 1, 0, 0, 0, 2 },
                                          { 0, 0, 0, 0, 1 },
                                          { 1, 0, 0, 0, 0 },
                                          { 0, 0, 0, 0, 0 } };

            string[] escape = new Kata().escape(carpark);

            foreach(var e in escape)
            {
                Console.WriteLine(e);
            }
        }
    }

    public class Kata
    {
        public string[] escape(int[,] carpark)
        {
            var movements = new List<string>();
            (int h, int w) currentPosition = FindCoordinates(carpark);
            int temp;
            int esc;
            string movement = string.Empty;

            
            if( (carpark.GetLength(0) - 1 == 1 || currentPosition.h == carpark.GetLength(0) - 1) && currentPosition.w != carpark.GetLength(1) - 1)
                return new string[] { $"R{carpark.GetLength(1) - currentPosition.w - 1}" };

          
            while(!TryExit(currentPosition, carpark))
            {
                temp = FindStairs(currentPosition, Row(carpark, currentPosition.h));
                movement = temp < 0 ? $"L{temp * (-1)}" : $"R{temp}";
                movements.Add(movement);
                currentPosition = (currentPosition.h, currentPosition.w + temp);
                
                temp = GetDown(currentPosition, carpark);
                movement = $"D{temp}";
                movements.Add(movement);
                currentPosition = (currentPosition.h + temp, currentPosition.w);
                
                if(currentPosition.h == carpark.GetLength(0) - 1)
                {                        
                    esc = carpark.GetLength(1) - currentPosition.w - 1;
                    if(esc > 0)
                    {                    
                        movements.Add($"R{esc}");
                        break;
                    }
                }
            }          
            
            return movements.ToArray();
        }

        (int h, int w) FindCoordinates(int[,] carpark)
        {
            for(int i = 0; i < carpark.GetLength(0); i++)
            {
                for(int j = 0; j < carpark.GetLength(1); j++)
                {
                    if(carpark[i,j] == 2)
                        return (i, j);
                }
            }

            return(-1, -1);
        }

        bool TryExit((int h, int w) position, int[,] arr) => position.h != arr.GetLength(0) - 1 ?
                                                                false : (position.w == arr.GetLength(1) - 1 ?
                                                                true : false);
      
        int GetDown((int h, int w) position, int[,] arr)
        {
            int i = 0;
        
            while(arr[position.h, position.w] == 1)
            {
                position.h++;
                i++;
            }

            return i;
        }
        
        int FindStairs((int h, int w) pos, int[] row) => Array.IndexOf(row, 1) - pos.w;
      
        static int[] Row(int[,] arr, int heigth)
        {
            int[] row = new int[arr.GetLength(1)];
          
            for(int i = 0; i < arr.GetLength(1); i++)
            {
                row[i] = arr[heigth, i];  
            }
          
            return row;
        }
    }
}
