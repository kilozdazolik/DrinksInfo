using Spectre.Console;

namespace DrinksInfo.kilozdazolik;

public class TableVisualisationEngine
{
    public void ShowTable<T>(List<T> data, string tableName = "")
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
}