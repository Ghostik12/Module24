using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25
{
    public class UserRepository
    {
        public AppContext appContext { get; set; }

        public UserRepository() 
        {
            appContext = new AppContext();
        }

        public User SelectObjectById(int Id)
        {
            var obj = appContext.Users.FirstOrDefault(x => x.Id == Id);
            Console.WriteLine($"Его зовут: {obj.Name}, email: {obj.Email}");
            return obj;
        }

        public List<User> SelectAll()
        {
            var obj = appContext.Users.ToList();
            foreach (var item in obj)
                Console.WriteLine($"Его зовут: {item.Name}, email: {item.Email}\t");
            return obj;
        }

        public void AddObj()
        {
            Console.WriteLine("Введите id пользователя: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введите id пользователя: ");
            var email = Console.ReadLine();
            var user = new User { Name = name, Email = email };
            appContext.Users.Add(user);
            appContext.SaveChanges();
        }

        public void DeleteObjByID()
        {
            Console.WriteLine("Введите id пользователя: ");
            var Id = Convert.ToInt32(Console.ReadLine());
            var user = appContext.Users.FirstOrDefault( x => x.Id == Id);
            appContext.Users.Remove(user);
            appContext.SaveChanges();
        }

        public void UpdateNameById()
        {
            Console.WriteLine("Введите id пользователя: ");
            var Id = Convert.ToInt32(Console.ReadLine());
            var user = appContext.Users.FirstOrDefault(x => x.Id == Id);
            Console.WriteLine("Введите имя: ");
            var name = Console.ReadLine();
            user.Name = name;
            appContext.SaveChanges();
            Console.WriteLine("Данные обновленны");
        }

        public void GetBook()
        {
            Console.Write("Введите название книги которую хотите взять: ");
            var title = Console.ReadLine();
            var book = appContext.Books.FirstOrDefault(x => x.Title == title);

            Console.Write("Введите свой email: ");
            var email = Console.ReadLine();
            var user = appContext.Users.First(x => x.Email == email);
            
            user.Books.Add(book);
            appContext.SaveChanges();
            Console.WriteLine("Книга получена!");
        }

        public void GetCountBooksOnHands()
        {
            Console.Write("Введите email пользователя: ");
            var email = Console.ReadLine();
            var count = appContext.Books.Include(x => x.Users).Where(x => x.Users.Email == email).Count();
        }

        public void GetLastYearOfRelease()
        {
            var lastBook = appContext.Books.OrderByDescending(x => x.YearOfRelease).First();

            Console.Write("Введите свой email: ");
            var email = Console.ReadLine();
            var user = appContext.Users.First(x => x.Email == email);

            user.Books.Add(lastBook);
            appContext.SaveChanges();
            Console.WriteLine("Книга получена!");
        }
    }
}
