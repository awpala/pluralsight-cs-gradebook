using System;
using System.Collections.Generic;

namespace GradeBook {
  public class Book {
    private string name;
    private List<double> grades;

    public Book(string name) {
      this.name = name;
      grades = new List<double>();
    }

    public void AddGrade(double grade) {
      grades.Add(grade);
    }

    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Average = 0.0;
      result.LowestGrade = double.MaxValue;
      result.HighestGrade = double.MinValue;

      foreach(var grade in grades) {
        result.LowestGrade = Math.Min(grade, result.LowestGrade);
        result.HighestGrade = Math.Max(grade, result.HighestGrade);
        result.Average += grade;
      }

      result.Average /= grades.Count;

      return result;
    }
  }
}
