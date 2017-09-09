using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class UserManager
    {
        public static Employee GetEmployee(string email, string password)
        {
            return new ShopAppEntities().Angajat.AsEnumerable().Where(el => (el.Email == email) && (el.Parola == password)).Select(el => new Employee()
            {
                ID = el.ID,
                MagazinID = el.MagazinID,
                Nume = el.Nume,
                Prenume = el.Prenume,
                CNP = (long)el.CNP,
                Email = el.Email,
                Parola = el.Parola,
                DataAngajare = el.DataAngajare,
                Salariu = el.Salariu,
                Functie = el.Functie
            }).FirstOrDefault();
        }

        public static List<string> GetMarkets(int id)
        {
            using (var db = new ShopAppEntities())
            {
                List<string> list = (from m in db.Magazin
                                     join a in db.Angajat on m.ID equals a.MagazinID
                                     where a.ID == id
                                     select a.Magazin.Denumire).ToList();
                return list;
            }
        }

        public static User AuthentificateUser(string email, string password, bool remember)
        {
            Employee employee = GetEmployee(email, password);

            if (employee != null)
            {
                var user = new User();
                user.ID = employee.ID;
                user.Nume = employee.Nume;
                user.Prenume = employee.Prenume;
                user.Email = employee.Email;
                user.Functie = employee.Functie;
                user.Magazine = GetMarkets(user.ID);
                return user;
            }
            else return null;
        }

        public static string Encode(string password)
        {
            TwofishManaged fish = new TwofishManaged();
            fish.Mode = CipherMode.ECB;
            fish.KeySize = 256;
            System.IO.MemoryStream ms = new MemoryStream();
            CryptoStream decStream;
            ICryptoTransform decrypt = fish.CreateDecryptor();
            CryptoStream cryptostream = new CryptoStream(ms, decrypt, CryptoStreamMode.Write);
            byte[] data = Encoding.ASCII.GetBytes(password);
            cryptostream.Write(data, 0, data.Length);
            cryptostream.Close();
            //FileStream fs = new FileStream(filename.Replace(".enc", ""), FileMode.Create);
            //fs.Write(data, 0, data.Length - 1);
            //fs.Close();
            return password;
        }

        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}
