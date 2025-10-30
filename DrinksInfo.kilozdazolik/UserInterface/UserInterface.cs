using System.ComponentModel;
using DrinksInfo.kilozdazolik.Controllers;
using Spectre.Console;
using DrinksInfo.kilozdazolik.Enums;
using DrinksInfo.kilozdazolik.Managers;

namespace DrinksInfo.kilozdazolik;

public abstract class UserInterface
{
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

        while (true)
        {
            AnsiConsole.MarkupLine("\n----------------------------------------\n");
            var choiceText = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do [green]next[/]?")
                    .AddChoices(choices.Keys));
            var choice = choices[choiceText];
            AnsiConsole.Clear();
            switch (choice)
            {
                case MenuAction.ViewCategories:
                    await DrinkController.ViewCategories();
                    break;
                case MenuAction.ViewDrinks:
                    await DrinkController.ViewDrinks();
                    break;
                case MenuAction.ViewDrinkDetails:
                    await DrinkController.ViewDrinkDetails();
                    break;
                case MenuAction.ViewFavorite:
                    FavoritesManager.ShowFavoriteDrinks();
                    break;
                case MenuAction.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }

}