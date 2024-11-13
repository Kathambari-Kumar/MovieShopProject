using System.Text.Json;
namespace MovieShop.Extensions

{
    public static class SessionExtention
    {
        public static void set<T>(this ISession session,string key,T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value=session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
