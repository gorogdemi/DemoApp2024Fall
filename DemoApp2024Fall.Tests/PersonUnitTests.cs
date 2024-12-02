using System.ComponentModel.DataAnnotations;
using DemoApp2024Fall.Shared;

namespace DemoApp2024Fall.Tests;

public class PersonUnitTests
{
    [Fact]
    public void ValidName_PersonValidation_IsValid()
    {
        // Arrange
        var person = new Person
        {
            Name = "John Doe",
            Email = "a@b.com",
            BirthDate = DateOnly.Parse("1995-01-01"),
        };

        // Act
        var results = new List<ValidationResult>();
        var context = new ValidationContext(person, null, null);
        var result = Validator.TryValidateObject(person, context, results, true);

        // Assert
        Assert.True(result);
        Assert.Empty(results);
    }
}