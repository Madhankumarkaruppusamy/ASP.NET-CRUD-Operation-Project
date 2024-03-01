using BookStoreDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public Book GetByID(long id);
        public void InsertBook(Book detail);
        public void UpdateBook(long id, Book book);
        public void DeleteBook(long id);
    }
}