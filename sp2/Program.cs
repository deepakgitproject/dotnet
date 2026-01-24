// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Text.RegularExpressions;
// using System.IO;
// using System.Text.Json;

// namespace MiniSocialMedia
// {
//     // ===================== INTERFACE =====================
//     public interface IPostable
//     {
//         void AddPost(string content);
//         IReadOnlyList<Post> GetPosts();
//     }

//     // ===================== CUSTOM EXCEPTION =====================
//     public class SocialException : Exception
//     {
//         public SocialException(string message) : base(message) { }
//         public SocialException(string message, Exception inner) : base(message, inner) { }
//     }

//     // ===================== GENERIC REPOSITORY =====================
//     public class Repository<T> where T : class
//     {
//         private readonly List<T> _items = new();

//         public void Add(T item) => _items.Add(item);
//         public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
//         public T? Find(Predicate<T> match) => _items.Find(match);
//     }

//     // ===================== POST =====================
//     public class Post
//     {
//         public User Author { get; }
//         public string Content { get; }
//         public DateTime CreatedAt { get; }

//         public Post(User author, string content)
//         {
//             Author = author ?? throw new ArgumentNullException(nameof(author));
//             Content = content;
//             CreatedAt = DateTime.UtcNow;
//         }

//         public override string ToString()
//         {
//             var sb = new StringBuilder();
//             sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
//             sb.AppendLine(Content);

//             var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
//             if (hashtags.Count > 0)
//             {
//                 sb.Append("Tags: ");
//                 sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
//             }

//             return sb.ToString().TrimEnd();
//         }
//     }

//     // ===================== USER =====================
//     public class User : IPostable, IComparable<User>
//     {
//         public string Username { get; init; }
//         public string Email { get; init; }

//         private readonly List<Post> _posts = new();
//         private readonly HashSet<string> _following = new(StringComparer.OrdinalIgnoreCase);

//         public event Action<Post>? OnNewPost;

//         public User(string username, string email)
//         {
//             if (string.IsNullOrWhiteSpace(username))
//                 throw new ArgumentException("Invalid username");

//             if (!Regex.IsMatch(email ?? "", @"^[^@]+@[^@]+\.[^@]+$"))
//                 throw new SocialException("Invalid email format");

//             Username = username.Trim();
//             Email = email.Trim().ToLower();
//         }

//         public void Follow(string username)
//         {
//             if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
//                 throw new SocialException("Cannot follow yourself");

//             _following.Add(username);
//         }

//         public void AddPost(string content)
//         {
//             if (string.IsNullOrWhiteSpace(content))
//                 throw new ArgumentException("Post content cannot be empty");

//             if (content.Length > 280)
//                 throw new SocialException("Post too long (max 280 characters)");

//             var post = new Post(this, content.Trim());
//             _posts.Add(post);
//             OnNewPost?.Invoke(post);
//         }

//         public IReadOnlyList<Post> GetPosts() => _posts.AsReadOnly();

//         public int CompareTo(User? other)
//         {
//             if (other == null) return 1;
//             return string.Compare(Username, other.Username, StringComparison.OrdinalIgnoreCase);
//         }

//         public override string ToString() => "@" + Username;

//         public string GetDisplayName() => $"User: {Username} <{Email}>";
//     }

//     // ===================== EXTENSIONS =====================
//     public static class SocialUtils
//     {
//         public static string FormatTimeAgo(this DateTime dt)
//         {
//             var diff = DateTime.UtcNow - dt;

//             if (diff.TotalSeconds < 60) return "just now";
//             if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
//             if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";

//             return dt.ToString("MMM dd");
//         }
//     }

//     // ===================== PROGRAM =====================
//     class Program
//     {
//         static Repository<User> _users = new();
//         static User? _currentUser = null;
//         static readonly string _dataFile = "social-data.json";

//         static void Main()
//         {
//             Console.Title = "MiniSocial - Console Edition";
//             LoadData();

//             while (true)
//             {
//                 try
//                 {
//                     if (_currentUser == null)
//                         ShowLoginMenu();
//                     else
//                         ShowMainMenu();
//                 }
//                 catch (SocialException ex)
//                 {
//                     WriteColor("Error: " + ex.Message, ConsoleColor.Red);
//                 }
//                 catch (Exception ex)
//                 {
//                     WriteColor("Unexpected error!", ConsoleColor.Red);
//                     LogError(ex);
//                 }

//                 Console.WriteLine("\nPress any key...");
//                 Console.ReadKey();
//                 Console.Clear();
//             }
//         }

//         static void ShowLoginMenu()
//         {
//             Console.WriteLine("1. Register\n2. Login\n3. Exit");
//             var ch = Console.ReadLine();

//             if (ch == "1") Register();
//             else if (ch == "2") Login();
//             else if (ch == "3")
//             {
//                 SaveData();
//                 Environment.Exit(0);
//             }
//         }

//         static void Register()
//         {
//             Console.Write("Username: ");
//             var u = Console.ReadLine();

//             Console.Write("Email: ");
//             var e = Console.ReadLine();

//             if (_users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase)) != null)
//                 throw new SocialException("Username already exists");

//             _users.Add(new User(u!, e!));
//             Console.WriteLine("Registered successfully!");
//         }

//         static void Login()
//         {
//             Console.Write("Username: ");
//             var u = Console.ReadLine();

//             var user = _users.Find(x => x.Username.Equals(u, StringComparison.OrdinalIgnoreCase));
//             if (user == null)
//                 throw new SocialException("User not found");

//             _currentUser = user;
//             _currentUser.OnNewPost += p =>
//                 WriteColor($"[Notification] {p.Author} posted a new post!", ConsoleColor.Yellow);

//             Console.WriteLine("Login successful!");
//         }

//         static void ShowMainMenu()
//         {
//             Console.WriteLine($"Logged in as {_currentUser}");
//             Console.WriteLine("1. Post\n2. View my posts\n3. List users\n4. Logout");

//             var ch = Console.ReadLine();

//             if (ch == "1") PostMessage();
//             else if (ch == "2") ShowPosts(_currentUser!.GetPosts());
//             else if (ch == "3") ListUsers();
//             else if (ch == "4") _currentUser = null;
//         }

//         static void PostMessage()
//         {
//             Console.Write("Post: ");
//             var text = Console.ReadLine();
//             if (!string.IsNullOrWhiteSpace(text))
//                 _currentUser!.AddPost(text);
//         }

//         static void ShowPosts(IEnumerable<Post> posts)
//         {
//             if (!posts.Any())
//             {
//                 Console.WriteLine("No posts.");
//                 return;
//             }

//             foreach (var p in posts.OrderByDescending(p => p.CreatedAt))
//             {
//                 Console.WriteLine(p);
//                 Console.WriteLine($"({p.CreatedAt.FormatTimeAgo()})");
//                 Console.WriteLine("--------------------------");
//             }
//         }

//         static void ListUsers()
//         {
//             foreach (var u in _users.GetAll().OrderBy(x => x))
//                 Console.WriteLine(u.GetDisplayName());
//         }

//         static void SaveData()
//         {
//             var json = JsonSerializer.Serialize(_users.GetAll());
//             File.WriteAllText(_dataFile, json);
//         }

//         static void LoadData()
//         {
//             if (!File.Exists(_dataFile)) return;

//             var json = File.ReadAllText(_dataFile);
//             var users = JsonSerializer.Deserialize<List<User>>(json);
//             if (users == null) return;

//             foreach (var u in users)
//                 _users.Add(u);
//         }

//         static void LogError(Exception ex)
//         {
//             File.AppendAllText("error.log", $"{DateTime.Now}\n{ex}\n------\n");
//         }

//         static void WriteColor(string msg, ConsoleColor color)
//         {
//             var old = Console.ForegroundColor;
//             Console.ForegroundColor = color;
//             Console.WriteLine(msg);
//             Console.ForegroundColor = old;
//         }
//     }
// }


// using System;
// class program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>{};
//         List<int>numbers2 = new List<int>{};
//         List<int>numbers3 = new List<int>{};
//         int count1 =0;
//         int count2 =0;
//         int count3 =0;
//         for (int i = 1; i <= 100; i++)
//         {
//             if(i %2 == 0)
//             {
//                 numbers.Add(i);
//                 count1++;
//             }
//             else if(i %3 == 0)
//             {
//                 numbers2.Add(i);
//                 count2++;
//             }
//             else
//             {
//                 numbers3.Add(i);
//                 count3++;
//             }
//         }
//         Console.WriteLine($"Total numbers divisible by 2: {count1}");
//         Console.WriteLine($"Total numbers divisible by 3: {count2}");
//         Console.WriteLine($"Total numbers not divisible by 2 or 3: {count3}");
//         Console.WriteLine("-----");

//         foreach(int num in numbers)
//         {
//             Console.WriteLine($"divisible by 2:{num}");
//         }
//         Console.WriteLine("-----");
//         foreach(int num in numbers2)
//         {
//             Console.WriteLine($"divisible by 3:{num}");
//         }
//         Console.WriteLine("-----");
//         foreach(int num in numbers3)
//         {
//             Console.WriteLine($"not divisible by 2 or 3:{num}");
//         }
//     }
// }



// using System;

// interface IGear
// {
//     void Gear1Test();
//     void Gear2Test();
//     void Gear3Test();
//     void Gear4Test();
//     void Gear5Test();
// }
// class MyCar : IGear
// {
//     public void Gear1Test()
//     {
//         Console.WriteLine("Gear 1 is working");
//     }
//     public void Gear2Test()
//     {
//         Console.WriteLine("Gear 2 is working");
//     }
//     public void Gear3Test()
//     {
//         Console.WriteLine("Gear 3 is working");
//     }
//     public void Gear4Test()
//     {
//         Console.WriteLine("Gear 4 is working");
//     }
//     public void Gear5Test()
//     {
//         Console.WriteLine("Gear 5 is working");
//     }
// }

// class program
// {
//     static void Main()
//     {
//         MyCar car = new MyCar();
//         car.Gear1Test();
//         car.Gear2Test();
//         car.Gear3Test();
//         car.Gear4Test();
//         car.Gear5Test();
//     }
// }


// using System;
// delegate void mathop(int a, int b);

// class operation
// {
//     public void Add(int a, int b)
//     {
//         Console.WriteLine($"Addition: {a + b}");
//     }
//     public void Subtract(int a, int b)
//     {
//         Console.WriteLine($"Subtraction: {a - b}");
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         // delegate delegateInstance;
//         operation op = new operation();
//         mathop deligate = null;
//         deligate = op.Add;
//         deligate(10, 5);
//         deligate = op.Subtract;
//         deligate(10, 5);
//         // mathop deladd = new mathop(op.Add);
//         // mathop delsub = new mathop(op.Subtract);



//     }
// }


