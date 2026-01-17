using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MiniSocialMedia
{
    class Program
    {
        static Repository<User> _users = new();
        static User? _currentUser = null;
        static readonly string _dataFile = "social-data.json";

        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite("Error: " + ex.Message, ConsoleColor.Red);
                    if (ex.InnerException != null)
                        Console.WriteLine(" → " + ex.InnerException.Message);
                }
                catch (Exception ex)
                {
                    ConsoleColorWrite("Unexpected error occurred!", ConsoleColor.Red);
                    Console.WriteLine(ex);
                    LogError(ex);
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            var ch = Console.ReadLine();

            if (ch == "1") Register();
            else if (ch == "2") Login();
            else if (ch == "3")
            {
                SaveData();
                Environment.Exit(0);
            }
        }

        static void Register()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine();

            Console.Write("Email: ");
            var e = Console.ReadLine();

            if (_users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase)) != null)
                throw new SocialException("Username already exists");

            var user = new User(u!, e!);
            _users.Add(user);

            Console.WriteLine("Registered successfully!");
        }

        static void Login()
        {
            Console.Write("Username: ");
            var u = Console.ReadLine();

            var user = _users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new SocialException("User not found");

            _currentUser = user;

            _currentUser.OnNewPost += p =>
            {
                ConsoleColorWrite($"[Notification] {p.Author} posted a new post!", ConsoleColor.Yellow);
            };

            Console.WriteLine("Login successful!");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine($"Logged in as {_currentUser}");
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. List users");
            Console.WriteLine("4. Logout");

            var ch = Console.ReadLine();

            if (ch == "1") PostMessage();
            else if (ch == "2") ShowPosts(_currentUser!.GetPosts());
            else if (ch == "3") ListUsers();
            else if (ch == "4") _currentUser = null;
        }

        static void PostMessage()
        {
            Console.Write("Enter post content: ");
            var text = Console.ReadLine();

            if (string.IsNullOrEmpty(text)) return;

            _currentUser!.AddPost(text);
            Console.WriteLine("Post created successfully!");
        }

        static void ShowPosts(System.Collections.Generic.IEnumerable<Post> posts)
        {
            if (!posts.Any())
            {
                Console.WriteLine("No posts to show.");
                return;
            }

            foreach (var p in posts.OrderByDescending(p => p.CreatedAt))
            {
                Console.WriteLine(p);
                Console.WriteLine($"({p.CreatedAt.FormatTimeAgo()})");
                Console.WriteLine("----------------------------------");
            }
        }

        static void ListUsers()
        {
            foreach (var u in _users.GetAll().OrderBy(x => x))
            {
                Console.WriteLine(u.GetDisplayName());
            }
        }

        static void SaveData()
        {
            try
            {
                var json = JsonSerializer.Serialize(_users.GetAll());
                File.WriteAllText(_dataFile, json);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile)) return;

                var json = File.ReadAllText(_dataFile);
                var users = JsonSerializer.Deserialize<System.Collections.Generic.List<User>>(json);

                if (users == null) return;

                foreach (var u in users)
                    _users.Add(u);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        static void LogError(Exception ex)
        {
            File.AppendAllText("error.log",
                $"{DateTime.Now}\n{ex}\n------------------------\n");
        }

        static void ConsoleColorWrite(string msg, ConsoleColor color)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = old;
        }
    }
}
