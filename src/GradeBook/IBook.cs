/*
  In C#, an interface is used to define the "shape" of a class/type,
  but does not provide the implementation; this is another form
  of polymorphism (i.e., in addition to abstract base classes)

  N.B. In practice, interfaces are more common that abstract base classes
*/

namespace GradeBook {
  public interface IBook {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get; }
    event GradeAddedDelegate GradeAdded;
  }
}
