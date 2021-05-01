using System;
using System.Collections.Generic;

namespace GradeBook {
  public class Book {
    public string Name;
    private List<double> grades;

    public Book(string name) {
      Name = name;
      grades = new List<double>();
    }

    public void AddLetterGrade(char letter) {
      switch (letter) {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        case 'D':
          AddGrade(60);
          break;
        default:
          AddGrade(0);
          break;
      }
    }

    public void AddGrade(double grade) {
      if (grade >= 0 && grade <= 100) {
        grades.Add(grade);
      } else {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public Statistics GetStatistics() {
      var result = new Statistics();
      result.Average = 0.0;
      result.LowestGrade = double.MaxValue;
      result.HighestGrade = double.MinValue;

      foreach (var grade in grades) {
        result.LowestGrade = Math.Min(grade, result.LowestGrade);
        result.HighestGrade = Math.Max(grade, result.HighestGrade);
        result.Average += grade;
      }

      result.Average /= grades.Count;

      switch (result.Average) {
        case var d when d >= 90:
          result.Letter = 'A';
          break;
        case var d when d >= 80:
          result.Letter = 'B';
          break;
        case var d when d >= 70:
          result.Letter = 'C';
          break;
        case var d when d >= 60:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }
  }
}
