using System;

namespace GradeBook {
  public class Statistics {
    public double LowestGrade;
    public double HighestGrade;
    public int Count;
    public double Sum;

    public double Average { 
      get { 
        return Sum / Count;
      }
    }

    public char Letter {
      get {
        switch (Average) {
          case var d when d >= 90:
            return 'A';
          case var d when d >= 80:
            return 'B';
          case var d when d >= 70:
            return 'C';
          case var d when d >= 60:
            return 'D';
          default:
            return 'F';
        }
      }
    }

    public Statistics() {
      LowestGrade = double.MaxValue;
      HighestGrade = double.MinValue;
      Count = 0;
      Sum = 0.0;
    }

    public void Add(double grade) {
      Sum += grade;
      Count++;
      LowestGrade = Math.Min(grade, LowestGrade);
      HighestGrade = Math.Max(grade, HighestGrade);
    }
  }
}
