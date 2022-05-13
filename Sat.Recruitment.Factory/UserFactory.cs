using Sat.Recruitment.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Factory
{
    public class UserFactory
    {
        //Leer usuarios de txt
        public static List<User> ReadUsersFromFile()
        {
            List<User> _users = new List<User>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            while (!IsFileReady(path))
            {
            }
            StreamReader reader = new StreamReader(path);
            try
            {
                User newUser = new User();

                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    _users.Add(user);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                reader.Close();
            }


            return _users;
        }


        //Grabar Usuarios desde txt
        public static bool SaveUserInFile(User user)
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            bool saved = false;

            while (!IsFileReady(path))
            { }
            StreamWriter writer = new StreamWriter(path, true);
            var line = "\n" + user.Name + "," + user.Email + "," + user.Phone + "," + user.Address + "," + user.UserType + "," + user.Money.ToString().Replace(",", ".");
            try
            {
                writer.WriteAsync(line);
                saved = true;
            }
            catch (Exception ex)
            {

            }
            writer.Close();

            return saved;

        }

        public static bool IsFileReady(string filename)
        {
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
