using App.Core.Models;

public interface IBookService
{
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(string id);
    List<Book> GetAllBooks();
    Book? GetBookById(string id);
    List<Book> SearchBooks(string keyword);
}