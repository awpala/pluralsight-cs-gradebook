﻿using System;

namespace GradeBook {
  class Program {
    static void OnGradeAdded(object sender, EventArgs e) { // delegate event handler
      Console.WriteLine("A grade was added.");
    }

    static void Main(string[] args) {
      var book = new Book("Scott's Grade Book");
      book.GradeAdded += OnGradeAdded;

      while(true) {
        Console.WriteLine("Enter a grade or `q` to quit");
        var input = Console.ReadLine();

        if(input.ToLower() == "q") {
          break;
        }

        try {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        } catch (ArgumentException ex) {
          Console.WriteLine(ex.Message);
        } catch (FormatException ex) {
          Console.WriteLine(ex.Message);
        } finally {
          Console.WriteLine("**");
        }
      }

      var stats = book.GetStatistics();

      Console.WriteLine($"For the book named {book.Name}");
      Console.WriteLine($"The lowest grade is {stats.LowestGrade}");
      Console.WriteLine($"The highest grade is {stats.HighestGrade}");
      Console.WriteLine($"The average grade is {stats.Average:N1}");
      Console.WriteLine($"The average letter grade is {stats.Letter}");
    }
  }
}
