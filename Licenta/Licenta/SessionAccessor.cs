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

        public static int getUserRole()
        {
            switch (SessionAccessor.LoggedUser.Functie)
            {
                case "Furnizor":
                    return 0;
                case "Angajat":
                    return 1;
                case "Manager magazin":
                    return 2;
                case "Sef magazin":
                    return 3;
                case "Admin":
                    return 10;
                default:
                    return -1;
            }
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