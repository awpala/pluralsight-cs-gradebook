using System;

namespace GradeBook {
  // `Book` inherits from class `NamedObject` and implements interface `IBook`
  public abstract class Book : NamedObject, IBook { // C# does not support multiple inheritance directly, however, it can be implemented via inheritance and/or abstract base classes
    public Book(string name) : base(name) {}

    public virtual event GradeAddedDelegate GradeAdded; // `virtual` delegates and methods can be overriden by any class(es) extending this interface 

    public abstract void AddGrade(double grade); // N.B. All `abstract` methods are "implicitly `virtual` methods" that must be overriden

    public virtual Statistics GetStatistics() {
      throw new NotImplementedException();
    }
  }
}
