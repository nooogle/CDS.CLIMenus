using CDS.CLIMenus.Basic;
using ConsoleDemo;

// --------------------------------------------------------------------------------
// Fluent API for building menus
new MenuBuilder("Main menu")
    .AddItem("Generate Prime Numbers", new PrimeNumberGenerator().Run)
    .AddItem("Play High-Low Game", new HighLowGame().Run, "Try to guess the number I'm thinking of!")
    .Build()
    .Run();


//// --------------------------------------------------------------------------------
//// Conventional API for building menus
//var menuItems = new List<MenuItem>
//{
//    new("Generate Prime Numbers", () => new PrimeNumberGenerator().Run()),
//    new("Play High-Low Game", () => new HighLowGame().Run(), "Try to guess the number I'm thinking of!")
//};

//var menu = new Menu("Main Menu", menuItems);
//menu.Run();
