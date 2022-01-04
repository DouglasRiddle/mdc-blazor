namespace SsExample.Code;

public class Common
{
    public readonly string DateTimeFormat = "MM/dd/yyyy h:mm tt";

    /// <summary>
    /// Navigate to element based on #elementId passed in the URL
    /// </summary>
    public static async Task NavigateToElementAsync(NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        string fragment = new Uri(navigationManager.Uri).Fragment;

        if (string.IsNullOrEmpty(fragment)) { return; }

        string elementId = fragment.StartsWith("#") ? fragment.Substring(1) : fragment;

        if (string.IsNullOrEmpty(elementId)) { return; }

        await jsRuntime.InvokeVoidAsync("SsExample.scrollToElementId", elementId);
    }
}
