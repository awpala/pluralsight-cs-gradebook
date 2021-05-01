using System;

namespace GradeBook {
  class Program {
    static void Main(string[] args) {
      var book = new Book("Scott's Grade Book");

      while(true) {
        Console.WriteLine("Enter a grade or `a` to quit");
        var input = Console.ReadLine();

        if(input.ToLower() == "q") {
          break;
        }

        var grade = double.Parse(input);
        book.AddGrade(grade);
      }

      var stats = book.GetStatistics();

      Console.WriteLine($"The lowest grade is {stats.LowestGrade}");
      Console.WriteLine($"The highest grade is {stats.HighestGrade}");
      Console.WriteLine($"The average grade is {stats.Average:N1}");
      Console.WriteLine($"The average letter grade is {stats.Letter}");
    }
  }
}
