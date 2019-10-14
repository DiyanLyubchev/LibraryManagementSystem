namespace LibrarySystem
{
    public interface IBook
    {
        string Author { get; set; }
        string ISBN { get; set; }
        int Pages { get; set; }
        string PublishDate { get; set; }
        string Publishers { get; set; }
        string Subject { get; set; }
        string Title { get; set; }

        string ToString();
    }
}