namespace DemoApp2024Fall;

public interface IPersonService
{
    Task AddAsync(Person person);

    Task DeleteAsync(Guid id);

    Task<Person> GetAsync(Guid id);

    Task<List<Person>> GetAllAsync();

    Task UpdateAsync(Person newPerson);
}