using System.Net.Http.Json;
using DrinksInfo.kilozdazolik.Models;

namespace DrinksInfo.kilozdazolik;

public class DrinksService
{
    private readonly HttpClient _httpClient;

    public DrinksService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
    }

    private async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<T>(endpoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return default;
        }
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var result = await GetAsync<Categories>("list.php?c=list");
        return result.CategoriesList;
    }
}