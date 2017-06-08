using DatabaseModel;
using System.Web;

namespace Licenta
{
    public static class SessionAccessor
    {
        public class Keys
        {
            public const string LoggedUser = "LoggedUser";
        }

        public static User LoggedUser
        {
            get { return GetSessionValue<User>(Keys.LoggedUser); }
            set { SetSessionValue(Keys.LoggedUser, value); }
        }

        private static T GetSessionValue<T>(string code) where T : class
        {
            if (string.IsNullOrWhiteSpace(code))
                return default(T);

            if (HttpContext.Current == null || HttpContext.Current.Session == null)
                return default(T);

            return HttpContext.Current.Session[code] as T;
        }

        private static void SetSessionValue(string code, object value)
        {
            if (string.IsNullOrWhiteSpace(code) || HttpContext.Current == null || HttpContext.Current.Session == null)
                return;

            HttpContext.Current.Session[code] = value;
        }
    }
}