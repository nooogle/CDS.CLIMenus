# CDS.CLIMenus

CDS.CLIMenus is a library for creating very simple and quick 
console-app menus. It is great for simple demo and test applications.

It's available for .Net 8 and .Net Framework 4.8 console applications.

It will only save you 10-20 minutes of coding, but that leaves more 
time for the fun stuff!

In this release there is only a basic menu system, in the `Basic` namespace. Future 
release will include more advanced features.

## Usage

### Fluent API for Building Menus

The following example demonstrates how to use the fluent API to build and run a menu:

```csharp
using CDS.CLIMenus.Basic; 
using ConsoleDemo;

new MenuBuilder("Main menu")
	.AddItem("Generate Prime Numbers", new PrimeNumberGenerator().Run) 
	.AddItem("Play High-Low Game", new HighLowGame().Run, "Try to guess the number I'm thinking of!") 
	.Build() 
	.Run();
```

![Console Screenshot](https://raw.githubusercontent.com/nooogle/CDS.CLIMenus/master/Console_Screenshot.png)


### Conventional API for Building Menus

Alternatively, you can use the conventional API to build and run a menu:

```csharp
using .Basic; 
using ConsoleDemo;

var menuItems = new List<MenuItem>
{
    new("Generate Prime Numbers", () => new PrimeNumberGenerator().Run()),
    new("Play High-Low Game", () => new HighLowGame().Run(), "Try to guess the number I'm thinking of!")
};

var menu = new Menu("Main Menu", menuItems);
menu.Run();
```


## License

This project is licensed under the MIT License.

## Attributions

[Number package icon](https://www.flaticon.com/free-icons/number), created by Freepik - Flaticon.



