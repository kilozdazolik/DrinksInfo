using DrinksInfo.kilozdazolik.Models;
using Spectre.Console;

namespace DrinksInfo.kilozdazolik.Managers;

public static class FavoritesManager
{
    private static List<DrinkDetail> _favoriteDrinks = new();
    private static TableVisualisationEngine _tableVisualisationEngine = new();
    private static Dictionary<string, int> _viewCounts = new Dictionary<string, int>();
    public static void AddFavorite(DrinkDetail drink)
    {
        if (!_favoriteDrinks.Any(d => d.Id == drink.Id))
        {
            _favoriteDrinks.Add(drink);
            AnsiConsole.Markup($"[bold green]Added favorite drink {drink.Name}[/]");
        }
        else
        {
            AnsiConsole.Markup($"[bold red]Drink is already in the list: {drink.Name}[/]");
        }
    }

    public static List<DrinkDetail> GetFavoriteDrinks()
    {
        return _favoriteDrinks;
    }
    
    public static void ShowFavoriteDrinks()
    {
        var favoriteDetails = FavoritesManager.GetFavoriteDrinks();

        if (favoriteDetails.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]There are no favorite drinks yet![/]");
            return;
        }
        
        var favoriteListItems = favoriteDetails.Select(d => new DrinkListItem
        {
            ID = d.Id,
            Name = d.Name,
            Category = d.Category,
            Alcoholic = d.Alcohol
        }).ToList();
        
        _tableVisualisationEngine.ShowTable(favoriteListItems, "Favorite Drinks");
    }
    
    public static void IncrementViewCount(string drinkId)
    {
        if (_viewCounts.ContainsKey(drinkId))
        {
            _viewCounts[drinkId]++;
        }
        else
        {
            _viewCounts.Add(drinkId, 1);
        }
    }
    
    public static int GetViewCount(string drinkId)
    {
        if (_viewCounts.ContainsKey(drinkId))
        {
            return _viewCounts[drinkId];
        }
        return 0;
    }
}