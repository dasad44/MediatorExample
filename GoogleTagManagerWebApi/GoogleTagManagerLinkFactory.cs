namespace GoogleTagManagerWebApp.Models
{
    public interface IGoogleTagManagerLinkFactory
    {
        string Get(string? id, string? eventName);
    }

    public class GoogleTagManagerLinkFactory : IGoogleTagManagerLinkFactory
    {
        public string Get(string? id, string eventName)
        {
            var result = $"/g/collect?" +
                         $"v=2" +
                         $"&en={eventName}" +
                         $"&tid={id ?? "G-1234"}" +
                         $"&cid=123.456" +
                         $"&dl=https%3A%2F%2Fexample.com%2F";

            return result;
        }
    }
}