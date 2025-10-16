using DrinksInfo.kilozdazolik.Models;
using DrinksInfo.kilozdazolik;

DrinksService _drinksService = new DrinksService();
TableVisualisationEngine _tableVisualisationEngine = new TableVisualisationEngine();


List<Category> categories = await _drinksService.GetCategoriesAsync();

_tableVisualisationEngine.ShowTable(categories, "categories");