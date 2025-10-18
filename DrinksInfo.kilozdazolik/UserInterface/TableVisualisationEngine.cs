using Spectre.Console;
using DrinksInfo.kilozdazolik.Models;

namespace DrinksInfo.kilozdazolik;

public class TableVisualisationEngine
{
    private static DrinksService _drinksService = new();
    public void ShowTable<T>(List<T> data, string tableName = "") where T : class
    {
        var table = new Table();
        table.Title(tableName);
        
        var props  = typeof(T).GetProperties();
        foreach (var prop in props)
        {
            table.AddColumn(prop.Name);
        }

        foreach (var item in data)
        {
            var values = props.Select(p => p.GetValue(item)?.ToString() ?? "");
            table.AddRow(values.ToArray());
        }
        
        AnsiConsole.Write(table);
    }
    
    public async Task ShowDrinkDetailAsync(DrinkDetail detail)
    {
        if (detail == null)
        {
            AnsiConsole.MarkupLine("[red]Could not retrieve drink details.[/]");
            return;
        }
        
        // Display the image if available
        if (!string.IsNullOrWhiteSpace(detail.ImageThumb))
        {
            await DisplayDrinkImageAsync(detail.ImageThumb);
        }

        AnsiConsole.MarkupLine($"\n[bold green]--- {detail.Name} ---[/]");
        AnsiConsole.MarkupLine($"[yellow]Category:[/]\t\t{detail.Category}");
        AnsiConsole.MarkupLine($"[yellow]Alcoholic:[/]\t{detail.Alcohol}");
        AnsiConsole.MarkupLine($"[yellow]Served In:[/]\t{detail.Glass}");
        AnsiConsole.MarkupLine($"[yellow]IBA:[/]\t\t{detail.IBA ?? "N/A"}");

        AnsiConsole.WriteLine("\n[bold]Ingredients:[/]");
        
        for (int i = 1; i <= 15; i++)
        {
            var ingredient = typeof(DrinkDetail).GetProperty($"Ingredient{i}")?.GetValue(detail)?.ToString();
            var measure = typeof(DrinkDetail).GetProperty($"Measure{i}")?.GetValue(detail)?.ToString();
        
            if (!string.IsNullOrWhiteSpace(ingredient))
            {
                AnsiConsole.WriteLine($"- {ingredient.Trim()} ({measure?.Trim() ?? "as needed"})");
            }
        }
        
        AnsiConsole.MarkupLine(detail.Instructions);
        
        AnsiConsole.MarkupLine("\n[grey]Press any key to return to the main menu...[/]");
        Console.ReadKey(true);
    }
    
    private async Task DisplayDrinkImageAsync(string imageUrl)
    {
        var tempFilePath = await _drinksService.DownloadImageAsync(imageUrl);
        
        if (tempFilePath != null)
        {
            try
            {
                var image = new CanvasImage(tempFilePath)
                    .MaxWidth(16);
                
                AnsiConsole.Write(image);
            }
            finally
            {
                // Cleanup: delete temp file
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }
    }
}