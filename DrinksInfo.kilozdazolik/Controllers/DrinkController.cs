namespace DrinksInfo.kilozdazolik.Controllers;

public static class DrinkController
{
    private static readonly TableVisualisationEngine TableVisualisationEngine = new();
    private static readonly DrinksService DrinksService = new();
    private static readonly UserInput UserInput = new();

    internal static async Task ViewCategories()
    {
        var categories = await DrinksService.GetCategoriesAsync();
        TableVisualisationEngine.ShowTable(categories, "Categories");
    }

    internal static async Task ViewDrinks()
    {
        var category = await UserInput.GetCategoriesInputAsync();
        var drinks = await DrinksService.GetDrinksByCategoryAsync(category);
        TableVisualisationEngine.ShowTable(drinks, "Drinks");
    }

    internal static async Task ViewDrinkDetails()
    {
        var selectedDrink = await UserInput.GetDrinkInputAsync();
        var drinkDetail = await DrinksService.GetDrinkDetailAsync(selectedDrink.Id);
        await TableVisualisationEngine.ShowDrinkDetailAsync(drinkDetail);
    }
}