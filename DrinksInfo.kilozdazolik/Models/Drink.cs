using System.Text.Json.Serialization;

namespace DrinksInfo.kilozdazolik.Models;

public class Drink
{
    [JsonPropertyName("idDrink")]
    public string Id { get; set; }
    [JsonPropertyName("strDrink")]
    public string Name {get; set;}
}

public class Drinks
{
    [JsonPropertyName("drinks")]
    public List<Drink> DrinksList {get; set;}
}