public class PopupState
{
    public string Title { get; }
    public string Subtitle { get; }
    public string ButtonText { get; }

    public PopupState(string title, string subtitle, string buttonText)
    {
        Title = title;
        Subtitle = subtitle;
        ButtonText = buttonText;
    }
}
