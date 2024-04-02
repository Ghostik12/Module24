using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25
{
    public class BookRepository
    {
        public AppContext appContext { get; set; }

        public BookRepository()
        {
            appContext = new AppContext();
        }

        public Book SelectObjectById()
        {
            Console.WriteLine("Введите id книги: ");
            var Id = Convert.ToInt32(Console.ReadLine());
            var obj = appContext.Books.FirstOrDefault(x => x.Id == Id);
            Console.WriteLine($"Название книги: {obj.Title}, год выпуска: {obj.YearOfRelease}");
            return obj;
        }

        public List<Book> SelectAll()
        {
            var obj = appContext.Books.ToList();
            foreach (var item in obj)
                Console.WriteLine($"Название книги: {item.Title}, год выпуска: {item.YearOfRelease}\t");
            return obj;
        }

        public void AddObj()
        {
            Console.WriteLine("Напишите название книги для добавления: ");
            var title = Console.ReadLine();
            Console.Write("Напишу дату выхода: ");
            var yearOfRelease = Convert.ToDateTime(Console.ReadLine());
            var book= new Book { Title = title, YearOfRelease = yearOfRelease };
            appContext.Books.Add(book);
            appContext.SaveChanges();
        }

        public void DeleteObjByID()
        {
            Console.WriteLine("Введите id книги: ");
            var Id = Convert.ToInt32(Console.ReadLine());
            var book = appContext.Books.FirstOrDefault(x => x.Id == Id);
            appContext.Books.Remove(book);
            appContext.SaveChanges();
        }

        public void UpdateTitleById()
        {
            Console.WriteLine("Введите id книги: ");
            var Id = Convert.ToInt32(Console.ReadLine());
            var user = appContext.Books.FirstOrDefault(x => x.Id == Id);
            Console.Write("Введите название книги: ");
            var title = Console.ReadLine();
            user.Title = title;
            appContext.SaveChanges();
        }

        public void SearchGenre()
        {
            Console.Write("Напишите какой жанр вы хотите почитать: ");
            var genre = Console.ReadLine();
            var bookGenre = appContext.Books.Where(x => x.Genre == genre).ToList();
            
            foreach (var book in bookGenre) 
                Console.WriteLine($"Название книги: {book.Title}\t");
        }

        public void SearchYear()
        {
            Console.Write("Напишите года между которыми хотите найти книгу\t Первый год:");
            var year1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Второй год: ");
            var year2 = Convert.ToInt32(Console.ReadLine());
            var books = appContext.Books.Where(x => x.YearOfRelease.Year > year1 && x.YearOfRelease.Year < year2).ToList();

            foreach(var book in books)
                Console.WriteLine($"Название книги: {book.Title} ({book.YearOfRelease})\t");
        }

        public void CountBooksAuthor()
        {
            Console.Write("Напишите фамилию автора: ");
            var author = Console.ReadLine();
            var bookAuthor = appContext.Books.Where(x => x.Author == author).Count();

            Console.WriteLine($"Количество книг: {bookAuthor}");
        }

        public void CountBooksGenre()
        {
            Console.Write("Напишите жанр книг: ");
            var genre = Console.ReadLine();
            var bookGenre = appContext.Books.Where(x => x.Genre == genre).Count();

            Console.WriteLine($"Количество книг: {bookGenre}");
        }

        public bool BookAuthorTitle()
        {
            Console.Write("Напишите фамилию автора: ");
            var author = Console.ReadLine();
            Console.Write("Напишите название книги: ");
            var title = Console.ReadLine();
            var flag = appContext.Books.Any(x => x.Title == title && x.Author == author);
            return flag;
        }

        public bool BookOnHands()
        {
            Console.Write("Напишите название книги: ");
            var title = Console.ReadLine();
            var flag = appContext.Books.Include(x => x.Users).Where(x => x.Title == title).Any();
            return flag;
        }

        public void ListBooksAbc()
        {
            var listBooks = appContext.Books.OrderBy(x => x.Title).ToList();
            foreach( var book in listBooks )
                Console.WriteLine($"{book.Title}");
        }

        public void ListBooksCba()
        {
            var listBooks = appContext.Books.OrderByDescending(x => x.YearOfRelease).ToList();
            foreach (var book in listBooks)
                Console.WriteLine($"{book.Title}");
        }
    }
}
