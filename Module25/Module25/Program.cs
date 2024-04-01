
namespace Module25
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "A", Role = "Admin", Email = "AL" };
                var user2 = new User { Name = "B", Role = "User", Email = "BL" };
                var user3 = new User { Name = "С", Role = "User2", Email = "СL" };

                db.Users.Add(user3);

                db.SaveChanges();
            }
        }
    }
}