using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniSocialMedia
{
    public class Post
    {
        public User Author{get;}
        public string Content{get;}
        public DateTime CreatedAt{get;}

        public Post(User author, string content)
        {
            if(author == null )
                throw new ArgumentNullException(nameof(author));

            Author = author;
            Content =content;
            CreatedAt = DateTime.UtcNow;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Author} • {CreatedAt:MMM dd HH:mm}");
            sb.AppendLine(Content);

            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count > 0)
            {
                sb.Append("Tags: ");
                sb.AppendJoin(", ", hashtags.Cast<Match>().Select(m => m.Value));
            }

            return sb.ToString().TrimEnd();
    }
}
}
