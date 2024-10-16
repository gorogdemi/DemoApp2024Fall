namespace DemoApp2024Fall;

public interface IPersonService
{
    void Add(Person person);

    void Delete(Guid id);

    Person Get(Guid id);

    List<Person> GetAll();

    void Update(Person newPerson);
}