// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0)
//    {
//        context.Database.Migrate();
//    }
//}

//AddBooks();
//GetAllBooks();
//UpdateBook();
//DeleteBook();
//GetBook();

//async void UpdateBook()
//{
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.Where(u => u.Publisher_Id == 1).ToListAsync();
//    foreach (var book in books)
//    {
//        book.Price = 55.55m;
//    }
//    await context.SaveChangesAsync();
//}

//async void DeleteBook()
//{
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.FindAsync(7);
//    context.Books.Remove(books);
//    await context.SaveChangesAsync();
//}
//async void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.ToListAsync();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " " + book.ISBN);
//    }

//    Console.ReadLine();
//}



//async void AddBooks()
//{
//    Book book = new Book() { Title = "New Ef Core Book", ISBN = "1231231212", Price = 10.93m, Publisher_Id = 1 };
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.AddAsync(book);
//    await context.SaveChangesAsync();

//}

//async void GetBook()
//{
//    using var context = new ApplicationDbContext();
    //var input = "Cookie Jar";
    //var books = context.Books;
    //var books = context.Books.First(); //if db is null it will throw exception  it fetch top 1

    // var books = context.Books.Where(u=>u.Publisher_Id==3 && u.Price>30).FirstOrDefault();

    //var books = context.Books.FirstOrDefault(u=>u.Title ==  input); 

    //var books = context.Books.Find(7); //only work in primary key column
    // var books = context.Books.Single(); //it can work on any column it fetch top 2 

    //var books = context.Books.Where(u=>u.ISBN.Contains("12"));
    //var books = context.Books.Where(u=> EF.Functions.Like(u.ISBN,"12%"));
    //Console.WriteLine(books.Title + " " + books.ISBN);

    //var books = context.Books.OrderBy(u=>u.Title).ThenByDescending(u=>u.ISBN);
    // var books = context.Books.Where(u=>u.Price > 10).OrderBy(u => u.Title).ThenByDescending(u => u.ISBN);

//    var books = await context.Books.Skip(0).Take(2).ToListAsync();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }

//    books = await context.Books.Skip(4).Take(1).ToListAsync();
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }

//}