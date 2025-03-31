using CDS.CLIMenus.Basic;
using ConsoleDemo;

// --------------------------------------------------------------------------------
// Fluent API for building menus
new MenuBuilder("Main menu")
    .AddItem("Generate Prime Numbers", new PrimeNumberGenerator().Run)
    .AddItem("Play High-Low Game", "Try to guess the number I'm thinking of!", new HighLowGame().Run)
    .SetOnItemComplete(() => Console.WriteLine("Menu item completed its action"))
    .Build()
    .Run();


//// --------------------------------------------------------------------------------
//// Conventional API for building menus
//var menuItems = new List<MenuItem>
//{
//    new("Generate Prime Numbers", () => new PrimeNumberGenerator().Run()),
//    new("Play High-Low Game", "Try to guess the number I'm thinking of!", () => new HighLowGame().Run())
//};

//var menu = new Menu("Main Menu", menuItems);
//menu.OnItemComplete = () => Console.WriteLine("Menu item completed its action!");
//menu.Run();
