# DrinksInfo Console Application 🍹

This is a terminal-based application developed to fetch and display detailed information about various cocktails and drinks from an external API (TheCocktailDB).

## 🚀 Features

The application provides a comprehensive command-line interface for exploring drink categories, viewing drinks by category, accessing detailed instructions, and managing personal favorites.

* **View Categories:** List all available drink categories.
* **View Drinks by Category:** Retrieve and display a list of drinks based on a selected category.
* **Drink Details:** Access detailed information, including ingredients, measures, instructions, and IBA classification for any specific drink.
* **Favorite Management:** Users can add and manage a list of their favorite drinks.
* **View Count:** Tracks the popularity of each drink by counting how many times its details have been viewed.

---

## 🛠️ Technology Stack

* **Language:** C#
* **Framework:** .NET 8 (or your current version)
* **Console UI:** [Spectre.Console](https://spectreconsole.net/) for rich, interactive terminal UI.
* **API:** TheCocktailDB

---

📝 Usage
Upon running the application, you will be presented with the main menu:

- View Categories
- View Drinks (Prompts for a category)
- View Drink Details (Prompts for a drink ID/name)
- View Favorite (Lists your saved drinks)
- Exit

Select an option using the arrow keys and press Enter.

---

## ⚙️ Installation and Setup

Follow these steps to set up the project locally.

### Prerequisites

* [.NET SDK 8.0](https://dotnet.microsoft.com/download) or newer.

### Clone the Repository

### Build and Run

Follow these steps to build and run the application from the command line:

1.  **Clone the Repository:**
    
    ```
    git clone [Your Repository URL Here]
    cd [Your Project Folder Name]
    
    ```
    
2.  **Restore dependencies:**
    
    ```
    dotnet restore
    
    ```
    
3.  **Build the project:**
    
    ```
    dotnet build
    
    ```
    
4.  **Run the application:**
    
    ```
    dotnet run
    
    ```
    
    The application will launch the main menu in your terminal.
