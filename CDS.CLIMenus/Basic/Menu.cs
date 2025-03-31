namespace CDS.CLIMenus.Basic;

/// <summary>
/// A console-based menu manager that displays options and handles user input.
/// </summary>
public class Menu
{
    private readonly List<MenuItem> items;
    private readonly string title;
    private bool isRunning = false;


    /// <summary>
    /// Callback action to execute when a menu item's action has completed.
    /// </summary>
    public Action? OnItemComplete { get; set; }


    /// <summary>
    /// Creates a new menu with the specified title and menu items.
    /// </summary>
    /// <param name="title">The title of the menu.</param>
    /// <param name="items">The collection of menu items.</param>
    public Menu(string title, IEnumerable<MenuItem> items)
    {
        this.title = title ?? string.Empty;
        this.items = new List<MenuItem>(items ?? new List<MenuItem>());
    }

    /// <summary>
    /// Displays the menu and handles user input until quit is requested.
    /// </summary>
    public void Run()
    {
        isRunning = true;

        while (isRunning)
        {
            DisplayMenu();
            HandleUserInput();
        }
    }

    /// <summary>
    /// Quits the menu, causing it to exit the Run loop.
    /// </summary>
    public void Quit()
    {
        isRunning = false;
    }

    private void DisplayMenu()
    {
        Console.Clear();

        if (!string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine(title);
            Console.WriteLine(new string('-', title.Length));
            Console.WriteLine();
        }

        if (items.Count == 0)
        {
            Console.WriteLine("No menu items available.");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].DisplayText}");
        }

        Console.WriteLine();
        Console.WriteLine("Enter a number to select an option");
        Console.WriteLine("Enter a number followed by 'D' to see a description (e.g., '1D')");
        Console.WriteLine("Enter 'Q' to quit");
        Console.WriteLine();
    }

    private void HandleUserInput()
    {
        Console.Write("> ");
        var input = Console.ReadLine()?.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(input))
        {
            ShowError("Please enter a valid option.");
            return;
        }

        if (input! == "q")
        {
            Quit();
            return;
        }

        // Check if user is requesting a description
        if (input!.EndsWith("d") && input.Length > 1)
        {
            var numberPart = input.Substring(0, input.Length - 1);
            if (int.TryParse(numberPart, out var index) && index >= 1 && index <= items.Count)
            {
                ShowDescription(index - 1);
            }
            else
            {
                ShowError($"Invalid option: {input}");
            }
            return;
        }

        // Handle regular menu option selection
        if (int.TryParse(input, out var selection) && selection >= 1 && selection <= items.Count)
        {
            try
            {
                var selectedItem = items[selection - 1];
                selectedItem.Action();
                OnItemComplete?.Invoke();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                ShowError($"Error executing menu action: {ex.Message}");
            }
        }
        else
        {
            ShowError($"Invalid option: {input}");
        }
    }

    private void ShowDescription(int index)
    {
        MenuItem item = items[index];
        
        Console.Clear();
        Console.WriteLine($"Description for: {item.DisplayText}");
        Console.WriteLine();
        
        if (string.IsNullOrWhiteSpace(item.Description))
        {
            Console.WriteLine("No description available.");
        }
        else
        {
            Console.WriteLine(item.Description);
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey(true);
    }

    private void ShowError(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}
