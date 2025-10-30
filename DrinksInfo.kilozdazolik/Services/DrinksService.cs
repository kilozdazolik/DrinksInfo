using System.Net.Http.Json;
using DrinksInfo.kilozdazolik.Models;

namespace DrinksInfo.kilozdazolik;

public class DrinksService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseApiUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

    public DrinksService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_baseApiUrl);
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

    public async Task<List<Drink>> GetDrinksByCategoryAsync(string category)
    {
        var result = await GetAsync<Drinks>($"filter.php?c={category}");
        return result.DrinksList;
    }

    public async Task<DrinkDetail> GetDrinkDetailAsync(string drinkId)
    {
        var response = await GetAsync<DrinkDetails>($"lookup.php?i={drinkId}");
        return response.DrinksList.FirstOrDefault();
    }
    
    public async Task<string?> DownloadImageAsync(string imageUrl)
    {
        try
        {
            // Download the image
            var imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

            // Save to temp file
            var tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.jpg");
            await File.WriteAllBytesAsync(tempFile, imageBytes);

            return tempFile;
        }
        catch (Exception)
        {
            return null;
        }
    }
}