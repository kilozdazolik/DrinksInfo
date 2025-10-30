using DrinksInfo.kilozdazolik.Models;
using Spectre.Console;

namespace DrinksInfo.kilozdazolik.Managers;

public class FavoritesManager
{
    private static readonly List<DrinkDetail> FavoriteDrinks = new();
    private static readonly TableVisualisationEngine TableVisualisationEngine = new();
    private static readonly Dictionary<string, int> ViewCounts = new();
    public static void AddFavorite(DrinkDetail drink)
    {
        if (FavoriteDrinks.All(d => d.Id != drink.Id))
        {
            FavoriteDrinks.Add(drink);
            AnsiConsole.Markup($"[bold green]Added favorite drink {drink.Name}[/]");
        }
        else
        {
            AnsiConsole.Markup($"[bold red]Drink is already in the list: {drink.Name}[/]");
        }
    }

    private static List<DrinkDetail> GetFavoriteDrinks()
    {
        return FavoriteDrinks;
    }
    
    public static void ShowFavoriteDrinks()
    {
        var favoriteDetails = GetFavoriteDrinks();

        if (favoriteDetails.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]There are no favorite drinks yet![/]");
            return;
        }
        
        var favoriteListItems = favoriteDetails.Select(d => new DrinkListItem
        {
            Id = d.Id,
            Name = d.Name,
            Category = d.Category,
            Alcoholic = d.Alcohol
        }).ToList();
        
        TableVisualisationEngine.ShowTable(favoriteListItems, "Favorite Drinks");
    }
    
    public static void IncrementViewCount(string drinkId)
    {
        if (!ViewCounts.TryAdd(drinkId, 1))
        {
            ViewCounts[drinkId]++;
        }
    }
    
    public static int GetViewCount(string drinkId)
    {
        return ViewCounts.GetValueOrDefault(drinkId, 0);
    }
}