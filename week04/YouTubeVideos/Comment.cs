public class Comment
{
    private string _text;
    private string _commenter;

    public string getCommenter()
    {
        return _commenter;
    }
    public void setCommenter(string commenter)
    {
        _commenter = commenter;
    }
    public string getText()
    {
        return _text;
    }
    public void setText(string text)
    {
        _text = text;
    }
    public Comment(string text, string commenter)
    {
        _text = text;
        _commenter = commenter;
    }
    public string displayComment()
    {
        return $"{_commenter}: {_text}";
    }
}