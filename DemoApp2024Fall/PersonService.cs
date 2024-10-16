namespace DemoApp2024Fall;

public class PersonService : IPersonService
{
    private List<Person> _personList;
    private ILogger<PersonService> _logger;

    public PersonService(ILogger<PersonService> logger)
    {
        _personList = [];
        _logger = logger;
    }

    public void Add(Person person)
    {
        _logger.LogInformation("Person to add: {@Person}", person);
        _personList.Add(person);
    }

    public void Delete(Guid id)
    {
        _personList.RemoveAll(p => p.Id == id);
    }

    public Person Get(Guid id)
    {
        return _personList.Find(p => p.Id == id);
    }

    public List<Person> GetAll()
    {
        _logger.LogInformation("All people retrieved");
        return _personList;
    }

    public void Update(Person newPerson)
    {
        var existingPerson = Get(newPerson.Id);
        existingPerson.Name = newPerson.Name;
        existingPerson.Email = newPerson.Email;
        existingPerson.BirthDate = newPerson.BirthDate;
    }
}