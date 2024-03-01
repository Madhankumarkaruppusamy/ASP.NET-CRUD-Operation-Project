using BookStoreDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _contxt;
        public BookRepository(DatabaseContext contxt)
        {
            _contxt = contxt;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            try
            {
                var result = _contxt.Books.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetByID(long id)
        {
            try
            {
                var result = _contxt.Books.Where(x => x.BookId == id);
                return result.ToList().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertBook(Book detail)
        {
            try
            {
                _contxt.Books.Add(detail);
                _contxt.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBook(long id, Book detail)
        {
            try
            {

                _contxt.Books.Update(detail);
                _contxt.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteBook(long id)
        {
            try
            {
                var book = _contxt.Books.Find(id);
                if (book != null)
                {
                    _contxt.Books.Remove(book);
                    _contxt.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
