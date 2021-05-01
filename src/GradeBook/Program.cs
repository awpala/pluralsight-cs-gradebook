using System;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var name = (args.Length == 1) ? args[0] : "there";
      Console.WriteLine($"Hello {name}!");
    }
  }
}
