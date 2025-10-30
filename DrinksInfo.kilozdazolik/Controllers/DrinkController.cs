namespace DrinksInfo.kilozdazolik.Controllers;

public class DrinkController
{
    private static TableVisualisationEngine _tableVisualisationEngine = new();
    private static DrinksService _drinksService = new();
    private static UserInput _userInput = new();

    internal static async Task ViewCategories()
    {
        var categories = await _drinksService.GetCategoriesAsync();
        _tableVisualisationEngine.ShowTable(categories, "Categories");
    }

    internal static async Task ViewDrinks()
    {
        var category = await _userInput.GetCategoriesInputAsync();
        var drinks = await _drinksService.GetDrinksByCategoryAsync(category);
        _tableVisualisationEngine.ShowTable(drinks, "Drinks");
    }

    internal static async Task ViewDrinkDetails()
    {
        var selectedDrink = await _userInput.GetDrinkInputAsync();
        var drinkDetail = await _drinksService.GetDrinkDetailAsync(selectedDrink.Id);
        await _tableVisualisationEngine.ShowDrinkDetailAsync(drinkDetail);
    }
}