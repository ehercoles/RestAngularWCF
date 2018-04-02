using RestAngularWCF.Data;
using RestAngularWCF.Domain.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestAngularWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        BookContext db = new BookContext();

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void AddBookOptions(Book book)
        {
            
        }

        public void DeleteBook(string bookId)
        {
            Book book = db.Books.Find(bookId);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void DeleteBookOptions(string bookId)
        {
            
        }

        public List<Book> GetBook()
        {
            return db.Books.ToList();
        }

        public Book GetBookDetails(string bookId)
        {
            return db.Books.Find(bookId);
        }

        public void UpdateBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
