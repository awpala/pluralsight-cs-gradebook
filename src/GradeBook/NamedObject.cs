namespace GradeBook {
  public class NamedObject {
    public string Name { get; /* private */ set; } // can designate setter to `private` to prevent setting
    public NamedObject(string name) {
      Name = name;
    }
  }
}
