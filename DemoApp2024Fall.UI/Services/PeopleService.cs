using System.Net.Http.Json;
using DemoApp2024Fall.Shared;

namespace DemoApp2024Fall.UI.Services;

public class PeopleService : IPeopleService
{
    private readonly HttpClient _httpClient;
    
    public PeopleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Person>>("people");
    }

    public async Task AddAsync(Person person)
    {
        await _httpClient.PostAsJsonAsync("people", person);
    }

    public async Task<Person> GetAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Person>($"people/{id}");
    }

    public async Task DeleteAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"people/{id}");
    }

    public async Task UpdateAsync(Person person)
    {
        await _httpClient.PutAsJsonAsync<Person>($"people/{person.Id}", person);
    }
}