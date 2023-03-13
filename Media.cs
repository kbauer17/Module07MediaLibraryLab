public class Media
{
    // public properties
    public UInt64 mediaId { get; set; }
    public string title { get; set; }
    public List<string> genres { get; set; }

    // constructor
    public Media()
    {
        genres = new List<string>();
    }

    // public method
    public string Display()
    {
        return $"Id: {mediaId}\nTitle: {title}\nGenres: {string.Join(", ", genres)}\n";
    }
}
