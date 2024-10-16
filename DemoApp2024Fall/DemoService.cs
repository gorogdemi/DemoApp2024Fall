namespace DemoApp2024Fall;

public class DemoService : IDemoService
{
    private Guid _id;
    private int _count;

    public DemoService()
    {
        _id = Guid.NewGuid();
        _count = 0;
    }

    public string GetMessage()
    {
        return _id.ToString();
    }

    public int NextCount()
    {
        return _count++;
    }
}