using System;
using System.Collections.Generic;

namespace GradeBook {
  public delegate void GradeAddedDelegate(object sender, EventArgs args); // N.B. By convention, in C#.NET event delegates are defined with these two parameters
  
  public class InMemoryBook : Book {
    private List<double> grades;
    public override event GradeAddedDelegate GradeAdded; // overrides delegate `GradeAdded` of abstract base class `Book`

    public InMemoryBook(string name): base(name) { // keyword `base` is used to call constructor of base class `NamedObject`
      Name = name;
      grades = new List<double>();
    }

    public void AddGrade(char letter) {
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

    public override void AddGrade(double grade) { // `override` is used to implement `abstract` or `virtual` methods
      if (grade >= 0 && grade <= 100) {
        grades.Add(grade);
        if (GradeAdded != null) {
          GradeAdded(this, new EventArgs());
        }
      } else {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }

    public override Statistics GetStatistics() { // overrides method `GetStatistics()` of abtract base class `Book`
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
