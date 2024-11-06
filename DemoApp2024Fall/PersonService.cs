using DemoApp2024Fall.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DemoApp2024Fall;

public class PersonService : IPersonService
{
    private DemoAppContext _context;
    private ILogger<PersonService> _logger;

    public PersonService(ILogger<PersonService> logger, DemoAppContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task AddAsync(Person person)
    {
        _logger.LogInformation("Person to add: {@Person}", person);

        await _context.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var person = await GetAsync(id);

        if (person is null)
        {
            throw new KeyNotFoundException("Person not found");
        }

        _context.RemoveRange(person.Items);
        _context.Remove(person);
        await _context.SaveChangesAsync();
    }

    public async Task<Person> GetAsync(Guid id)
    {
        return await _context.FindAsync<Person>(id);
    }

    public async Task<List<Person>> GetAllAsync()
    {
        _logger.LogInformation("All people retrieved");
        return await _context.People.ToListAsync();
    }

    public async Task UpdateAsync(Person newPerson)
    {
        var existingPerson = await GetAsync(newPerson.Id);

        existingPerson.Name = newPerson.Name;
        existingPerson.Email = newPerson.Email;
        existingPerson.BirthDate = newPerson.BirthDate;
        existingPerson.Items = newPerson.Items;
        
        await _context.SaveChangesAsync();
    }
}