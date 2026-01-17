using System;

namespace MiniSocialMedia
{
    public static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime dt)
        {
            var diff = DateTime.UtcNow - dt;

            if (diff.TotalSeconds < 60) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} h ago";

            return dt.ToString("MMM dd");
        }
    }
}
