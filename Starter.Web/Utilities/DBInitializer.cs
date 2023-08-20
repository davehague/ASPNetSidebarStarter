using FmxLite.Model;

namespace FmxLite.Web
{
    public static class DbInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Name = "John Smith", PhoneNumber = "123-456-7890" },
                new User { Name = "Jane Doe", PhoneNumber = "234-567-8901" },
                new User { Name = "James Johnson", PhoneNumber = "345-678-9012" },
                new User { Name = "Patricia Brown", PhoneNumber = "456-789-0123" },
                new User { Name = "Robert Davis", PhoneNumber = "567-890-1234" },
                new User { Name = "Jennifer Garcia", PhoneNumber = "678-901-2345" },
                new User { Name = "Michael Martinez", PhoneNumber = "789-012-3456" },
                new User { Name = "Linda Wilson", PhoneNumber = "890-123-4567" },
                new User { Name = "William Anderson", PhoneNumber = "901-234-5678" },
                new User { Name = "Jessica Taylor", PhoneNumber = "012-345-6789" }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();
        }
    }
}
