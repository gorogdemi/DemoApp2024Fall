using DemoApp2024Fall.Contexts;
using DemoApp2024Fall.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace DemoApp2024Fall.Tests;

public sealed class PersonServiceUnitTests : IAsyncDisposable
{
    private readonly DemoAppContext _inMemoryDbContext;

    public PersonServiceUnitTests()
    {
        var contextOptions = new DbContextOptionsBuilder<DemoAppContext>()
            .UseInMemoryDatabase("DemoApp2024FallTests")
            .Options;
        
        _inMemoryDbContext = new DemoAppContext(contextOptions);

        _inMemoryDbContext.Database.EnsureDeleted();
        _inMemoryDbContext.Database.EnsureCreated();

        _inMemoryDbContext.SaveChanges();
    }

    [Fact]
    public async Task John_AddAsync_ContainsOnePerson()
    {
        // Arrange
        var personService = new PersonService(NullLogger<PersonService>.Instance, _inMemoryDbContext);

        await personService.AddAsync(new Person
        {
            Name = "John",
            BirthDate = DateOnly.Parse("1998-01-01"),
            Email = "a@b.com",
            Items = [],
        });
        
        // Act
        var people = await personService.GetAllAsync();
        
        // Assert
        Assert.Single(people);
    }

    [Fact]
    public async Task Doe_AddAsync_ContainsOnePerson()
    {
        // Arrange
        var personService = new PersonService(NullLogger<PersonService>.Instance, _inMemoryDbContext);

        await personService.AddAsync(new Person
        {
            Name = "Doe",
            BirthDate = DateOnly.Parse("1998-01-01"),
            Email = "a@b.com",
            Items = [],
        });
        
        // Act
        var people = await personService.GetAllAsync();
        
        // Assert
        Assert.Single(people);
    }

    public async ValueTask DisposeAsync()
    {
        await _inMemoryDbContext.DisposeAsync();
    }
}