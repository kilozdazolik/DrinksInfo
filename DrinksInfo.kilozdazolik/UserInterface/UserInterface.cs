using System.ComponentModel;
using Spectre.Console;
using DrinksInfo.kilozdazolik.Enums;
using DrinksInfo.kilozdazolik.Models;

namespace DrinksInfo.kilozdazolik;

public class UserInterface
{
    private static TableVisualisationEngine _tableVisualisationEngine = new();
    private static DrinksService _drinksService = new();
    private static UserInput _userInput = new();
    internal static async Task MainMenu()
    {
        AnsiConsole.MarkupLine("Welcome to the DrinksInfo!");
        var choices = Enum.GetValues<MenuAction>()
            .Select(v => (Value: v, 
                Text: v.GetType()
                    .GetField(v.ToString())?
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .Cast<DescriptionAttribute>()
                    .FirstOrDefault()?.Description ?? v.ToString()))
            .ToDictionary(x => x.Text, x => x.Value);

        var choiceText = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What do you want to do [green]next[/]?")
                .AddChoices(choices.Keys));

        var choice = choices[choiceText];
        switch (choice)
        {
            case MenuAction.ViewCategories:
                var categories = await _drinksService.GetCategoriesAsync();
                _tableVisualisationEngine.ShowTable(categories, "Categories");
                break;
            case MenuAction.ViewDrinks:
                var category = await _userInput.GetCategoriesInputAsync();
                var drinks = await _drinksService.GetDrinksByCategoryAsync(category);
                _tableVisualisationEngine.ShowTable(drinks, "Drinks");
                break;
            case MenuAction.ViewDrinkDetails:
                var selectedDrink = await _userInput.GetDrinkInputAsync();
                var drinkDetail = await _drinksService.GetDrinkDetailAsync(selectedDrink.Id);
                await _tableVisualisationEngine.ShowDrinkDetailAsync(drinkDetail); 
                break;
            case MenuAction.Exit:
                Environment.Exit(0);
                break;
        }
    }
  
}