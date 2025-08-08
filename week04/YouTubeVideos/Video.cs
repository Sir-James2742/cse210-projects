public class Video
{
    private string _title;
    private string _author;
    private int _length;
    public List<Comment> Comments{get;  set;}

    public string getTitle()
    {
        return _title;
    }
    public void setTitle(string title)
    {
        _title = title;
    }
    public string getAuthor()
    {
        return _author;
    }
    public void setAuthor(string author)
    {
        _author = author;
    }
    public int getlength()
    {
        return _length;
    }
    public void setlength(int length)
    {
        _length = length;
    }
    
   
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        Comments = new List<Comment>();
    }

    public string displayVideo()
    {
        return $"{_title} by {_author} has {_length}seconds length.";
    }
}