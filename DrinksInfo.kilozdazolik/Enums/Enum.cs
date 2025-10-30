using System.ComponentModel;

namespace DrinksInfo.kilozdazolik.Enums;

internal enum MenuAction {
    [Description("View Categories")]
    ViewCategories,

    [Description("View Drinks")]
    ViewDrinks,

    [Description("View Drink Details")]
    ViewDrinkDetails,
    
    [Description("View Favorite Drinks")]
    ViewFavorite,

    [Description("Exit")]
    Exit
}