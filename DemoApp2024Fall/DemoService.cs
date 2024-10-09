namespace DemoApp2024Fall;

public class DemoService : IDemoService
{
    private Guid _id;

    public DemoService()
    {
        _id = Guid.NewGuid();
    }

    public string GetMessage()
    {
        return _id.ToString();
    }
}