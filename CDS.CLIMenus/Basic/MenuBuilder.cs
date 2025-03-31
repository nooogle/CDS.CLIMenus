namespace CDS.CLIMenus.Basic;

/// <summary>
/// Builder class for creating console menus with a fluent interface.
/// </summary>
public class MenuBuilder
{
    private readonly string title;
    private readonly List<MenuItem> items = new List<MenuItem>();
    private Action? onItemComplete = null;


    /// <summary>
    /// Creates a new menu builder with the specified title.
    /// </summary>
    /// <param name="title">The title of the menu.</param>
    public MenuBuilder(string title)
    {
        this.title = title ?? string.Empty;
    }


    /// <summary>
    /// Adds a menu item to the menu.
    /// </summary>
    /// <param name="displayText">The text to display for this menu item.</param>
    /// <param name="action">The action to execute when this menu item is selected.</param>
    public MenuBuilder AddItem(string displayText, Action action)
    {
        items.Add(new MenuItem(displayText, action));
        return this;
    }


    /// <summary>
    /// Adds a menu item to the menu.
    /// </summary>
    /// <param name="displayText">The text to display for this menu item.</param>
    /// <param name="action">The action to execute when this menu item is selected.</param>
    /// <param name="description">Optional description providing more details about this menu item.</param>
    /// <returns>The builder instance for method chaining.</returns>
    public MenuBuilder AddItem(string displayText, string description, Action action)
    {
        items.Add(new MenuItem(displayText, description, action));
        return this;
    }


    /// <summary>
    /// Creates and returns a Menu instance based on the builder configuration.
    /// </summary>
    /// <returns>A configured Menu instance.</returns>
    public Menu Build()
    {
        var menu = new Menu(title, items);
        menu.OnItemComplete = onItemComplete;
        return menu;
    }


    /// <summary>
    /// Sets the action to execute when a menu item's action has completed.
    /// </summary>
    public MenuBuilder SetOnItemComplete(Action value)
    {
        onItemComplete = value;
        return this;
    }
}
