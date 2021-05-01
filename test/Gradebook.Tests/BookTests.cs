using System;
using Xunit;

namespace GradeBook.Tests
{
  public class BookTests {
    [Fact] // N.B. `[...]` denotes an attribute
    public void BookCalculatesAnAverageGrade() {
      // arrange
      var book = new Book("");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.3);

      // act
      var result = book.GetStatistics();

      // assert
      Assert.Equal(77.3, result.LowestGrade, 1);
      Assert.Equal(90.5, result.HighestGrade, 1);
      Assert.Equal(85.6, result.Average, 1);
    }
  }
}
