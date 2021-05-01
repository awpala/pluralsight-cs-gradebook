using System;
using System.Collections.Generic;

namespace GradeBook {
  class Book {
    private string name;
    private List<double> grades;

    public Book(string name) {
      this.name = name;
      grades = new List<double>();
    }

    public void AddGrade(double grade) {
      grades.Add(grade);
    }

    public void ShowStatistics()
    {
      var result = 0.0;
      var lowestGrade = double.MaxValue;
      var highestGrade = double.MinValue;

      foreach(var num in grades) {
        lowestGrade = Math.Min(num, lowestGrade);
        highestGrade = Math.Max(num, highestGrade);
        result += num;
      }

      result /= grades.Count;

      Console.WriteLine($"The lowest grade is {lowestGrade}");
      Console.WriteLine($"The highest grade is {highestGrade}");
      Console.WriteLine($"The average grade is {result:N1}");
    }
  }
}
