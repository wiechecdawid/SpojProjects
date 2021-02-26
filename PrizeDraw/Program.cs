using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw
{
    class Program
    {
      static void Main(string[] args)
      {
        string st = "Addison,Jayden,Sofia,Michael,Andrew,Lily,Benjamin";
        var we = new int[] {4, 2, 1, 4, 3, 1, 2};
        Console.WriteLine(Rank.NthRank(st, we, 4));
      }
    }
}

public class Rank
{
  static string alphabet = "abcdefghijklmnopqrstuvwxyz";
  static Dictionary<string, int> dict;
  
  public static string NthRank(string st, int[] we, int n)
  {
    dict = new Dictionary<string, int>();

    if(string.IsNullOrEmpty(st))
      return "No participants";

    var arr = st.Split(',');

    if(arr.Length < n)
      return "Not enough participants";
    
    for(int i = 0; i < arr.Length; i++)
    {
      int val = (arr[i].Select(x => char.ToLower(x)).Sum(x => alphabet.IndexOf(x)+1) + arr[i].Length) * we[i];
      
      dict.Add(arr[i], val);
    }
    
    var sorted = dict.OrderByDescending( x => x.Value ).ThenBy( x => x.Key ).ToList();
    
    return sorted[n-1].Key;
  }
}