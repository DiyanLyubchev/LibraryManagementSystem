namespace LibrarySystem.Models.Contracts.Books
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
        int Id { get; set; }
        string ToString();
    }
}