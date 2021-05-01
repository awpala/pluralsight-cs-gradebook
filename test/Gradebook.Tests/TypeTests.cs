using System;
using Xunit;

namespace GradeBook.Tests
{
  public class TypeTests {
    InMemoryBook GetBook(string name) {
      return new InMemoryBook(name);
    }

    [Fact]
    public void GetBookReturnsDifferentObjects() {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
      Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject() {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2)); // equivalent to previous line (but less idiomatic)
    }

    private void SetName(Book book, string name) {
      book.Name = name; // `book` holds a reference to the same object as the argument passed in (which holds a reference)
    }

    [Fact]
    public void CanSetNameFromReference() {
      var book1 = GetBook("Book 1");
      SetName(book1, "New Name"); // `book1` is passed by value

      Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(Book book, string name) {
      book = new InMemoryBook(name); // parameter `book` (local variable) receives a new object reference, while the argument passed in retains its original object reference
      book.Name = name; // no net effect -- acts on `book` rather than the object from the argument
    }

    [Fact]
    public void CSharpIsPassByValue() {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name"); // `book1` is passed by value

      Assert.Equal("Book 1", book1.Name); // is not "New Name" -- a separate object is created inside of function `GetBookSetName()`, `book1` (which was passed by value) remains unchanged
    }

    private void GetBookRefSetName(ref InMemoryBook book, string name) { // kewyord `ref` changes parameter behavior from pass by value (default) to pass by reference
      book = new InMemoryBook(name);
      book.Name = name;
    }

    [Fact]
    public void CSharpCanPassByRef() {
      var book1 = GetBook("Book 1");
      GetBookRefSetName(ref book1, "New Name"); // `book1` is passed by reference -- must also use `ref` in argument (i.e., in addition to corresponding parameter in function signature) to explicitly pass by reference (otherwise, passes by value)

      Assert.Equal("New Name", book1.Name);
    }
  }
}
