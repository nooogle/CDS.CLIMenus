namespace CDS.CLIMenus.Basic;


/// <summary>
/// Represents a single menu item in a console menu.
/// </summary>
public class MenuItem
{
    /// <summary>
    /// The text to display for this menu item.
    /// </summary>
    public string DisplayText { get; }

    /// <summary>
    /// Optional description providing more details about this menu item.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Action to execute when this menu item is selected.
    /// </summary>
    public Action Action { get; }

    /// <summary>
    /// Creates a new menu item.
    /// </summary>
    /// <param name="displayText">The text to display for this menu item.</param>
    /// <param name="action">The action to execute when this menu item is selected.</param>
    public MenuItem(string displayText, Action action) : this(displayText, string.Empty, action)
    {
    }

    
    /// <summary>
    /// Creates a new menu item.
    /// </summary>
    /// <param name="displayText">The text to display for this menu item.</param>
    /// <param name="action">The action to execute when this menu item is selected.</param>
    /// <param name="description">Optional description providing more details about this menu item.</param>
    public MenuItem(string displayText, string description, Action action)
    {
        DisplayText = displayText ?? throw new ArgumentNullException(nameof(displayText));
        Action = action ?? throw new ArgumentNullException(nameof(action));
        Description = description ?? string.Empty;
    }
}
