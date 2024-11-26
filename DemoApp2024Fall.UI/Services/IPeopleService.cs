using DemoApp2024Fall.Shared;

namespace DemoApp2024Fall.UI.Services;

public interface IPeopleService
{
    public Task<List<Person>> GetAllAsync();
    
    public Task AddAsync(Person person);
    
    public Task<Person> GetAsync(Guid id);
    
    public Task DeleteAsync(Guid id);
    
    public Task UpdateAsync(Person person);
}