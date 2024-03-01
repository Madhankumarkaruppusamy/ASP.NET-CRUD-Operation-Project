using BookStoreDataAccessLayer.Models;
using BookStoreDataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TN_BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _stall;
        private readonly string _connectionstring;
        public BooksController(IBookRepository stall, IConfiguration configuration)
        {
            _stall = stall;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: BooksController
        public ActionResult Index()
        {
            try
            {
                var result = _stall.GetAllBooks();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _stall.GetByID(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: BooksController/Create
        [HttpGet]
        public ActionResult Create(int ? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var Get = _stall.GetByID(id.Value);
                    return View("Create", Get);
                }
                else
                {
                    var result = new Book();
                    return View("Create", result);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: BooksController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Book value)
        {
            try
            {
                if (value.BookId == 0)
                {
                    _stall.InsertBook(value);

                }
                else
                {
                    _stall.UpdateBook(value.BookId, value);
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                _stall.DeleteBook(id);
                var result = _stall.GetAllBooks();
                return View("View",result);

            }
            catch
            {
                return View("Error");
            }
        }
    }
}
