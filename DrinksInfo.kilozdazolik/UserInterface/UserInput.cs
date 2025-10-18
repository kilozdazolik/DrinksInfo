using DrinksInfo.kilozdazolik.Models;
using Spectre.Console;

namespace DrinksInfo.kilozdazolik;

public class UserInput
{
    private DrinksService _drinksService = new();

    internal async Task<string> GetCategoriesInputAsync()
    {
        var categories = await _drinksService.GetCategoriesAsync();

        var category = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Select a [green]category[/]:")
                .AddChoices(categories.Select(c => c.Name)));

        return category;
    }
    
    internal async Task<Drink> GetDrinkInputAsync()
    {
        var category = await GetCategoriesInputAsync();
        var drinks = await _drinksService.GetDrinksByCategoryAsync(category);
        
        var drinkName = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Select a [green]drink[/]:")
                .AddChoices(drinks.Select(d => d.Name)));
        
        var selectedDrink = drinks.FirstOrDefault(d => d.Name == drinkName);

        if (selectedDrink == null)
        {
            throw new InvalidOperationException("Selected drink not found.");
        }

        return selectedDrink;
    }
}