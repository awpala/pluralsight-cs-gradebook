using System;
using System.IO;

namespace GradeBook {
  public class DiskBook : Book {
    public DiskBook(string name) : base(name) {}

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade) {
      using(var writer = File.AppendText($"{Name}.txt")) { // common C# idiom via `using` to handle resource which may be interrupted (e.g., file I/O, network socket, etc.) 
        writer.WriteLine(grade);

        if (GradeAdded != null) {
          GradeAdded(this, new EventArgs());
        }
      } // closes `writer` upon exit (even if writing was not successful)
    }

    public override Statistics GetStatistics() {
      var result = new Statistics();

      using(var reader = File.OpenText($"{Name}.txt")) {
        var line = reader.ReadLine();
        while(line != null) {
          var grade = double.Parse(line);
          result.Add(grade);
          line = reader.ReadLine();
        }
      }

      return result;
    }
  }
}
