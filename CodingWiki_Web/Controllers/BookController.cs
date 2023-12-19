﻿using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
             IQueryable<Book> bookList = _db.Books.Include(u=>u.Publisher).Include(u=>u.BookAuthorMap)
                .ThenInclude(u=>u.Author);

            var temp = bookList.Where(u=>u.BookId == 1).ToList();

            //List<Book> bookList = _db.Books.ToList();
            //foreach (var obj in bookList)
            //{
            //    //least efficient
            //    // obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);

            //    //more efficient
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //    _db.Entry(obj).Collection(u => u.BookAuthorMap).Load();
            //    foreach (var bookAuth in obj.BookAuthorMap)
            //    {
            //        _db.Entry(bookAuth).Reference(u => u.Author).Load();
            //        //_db.Entry(bookAuth).Reference(u => u.Book).Load();
            //    }
            //}
            return View(bookList);
        }

       
        public IActionResult Upsert(int? id)
        {
            BookVM bookObj = new BookVM();
            bookObj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });


            if (id == null || id == 0)
            {
                //create
                return View(bookObj);
            }
            bookObj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (bookObj == null)
            {
                return NotFound();
            }

            return View(bookObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
                if(obj.Book.BookId == 0)
                {
                    await _db.Books.AddAsync(obj.Book);
                    
                }
                else
                {
                    _db.Books.Update(obj.Book);
                    
                }
               
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int? id)
        {
            BookVM bookObj = new BookVM();           

            if (id == null || id == 0)
            {
                //create
                return NotFound();
            }
            bookObj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            bookObj.Book.BookDetail=_db.BookDetails.FirstOrDefault(u=>u.Book_Id == id);
            if (bookObj == null)
            {
                return NotFound();
            }

            return View(bookObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(BookVM obj)
        {
            obj.Book.BookDetail.Book_Id = obj.Book.BookId;
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                await _db.BookDetails.AddAsync(obj.Book.BookDetail);

            }
            else
            {
                _db.BookDetails.Update(obj.Book.BookDetail);

            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            Book obj = new Book();
            obj = _db.Books.FirstOrDefault(u=>u.BookId==id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Books.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorVM obj = new BookAuthorVM()
            {
                BookAuthorList = _db.BookAuthorMaps.Include(u => u.Author).Include(u => u.Book)
                     .Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new()
                {
                    Book_Id = id
                },
                Book = _db.Books.FirstOrDefault(u => u.BookId == id)
            };

            List<int> tempListOfAssignedAuthor = obj.BookAuthorList.Select(u => u.Author_Id).ToList();

            //NOT IN clause
            //get all the authors whos id is not in tempListOfAssignedAuthors

            var tempList = _db.Authors.Where(u => !tempListOfAssignedAuthor.Contains(u.Author_Id)).ToList();
            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });

            return View(obj);

        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorVM bookAuthorVM)
        {
            if(bookAuthorVM.BookAuthor.Book_Id !=0 && bookAuthorVM.BookAuthor.Author_Id != 0)
            {
                _db.BookAuthorMaps.Add(bookAuthorVM.BookAuthor);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new {@id = bookAuthorVM.BookAuthor.Book_Id});
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorVM bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.BookId;
            BookAuthorMap bookAuthorMap = _db.BookAuthorMaps.FirstOrDefault(
                u=>u.Author_Id == authorId && u.Book_Id == bookId);
            _db.BookAuthorMaps.Remove(bookAuthorMap);
            _db.SaveChanges();

            
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public async Task<IActionResult> Playground()
        {
            IEnumerable<Book> bookList1 = _db.Books;
            var filteredbook1 = bookList1.Where(b => b.Price > 50).ToList();

            IQueryable<Book> bookList2 = _db.Books;
            var filteredbook2 = bookList2.Where(b => b.Price > 50).ToList();

            //var bookTemp = _db.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _db.Books;
            //decimal totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _db.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _db.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _db.Books.Count();
            return RedirectToAction(nameof(Index));
        }
    }
}
