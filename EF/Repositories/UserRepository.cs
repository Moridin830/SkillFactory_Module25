using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Helpers;

namespace EF
{
    public class UserRepository
    {
        private AppContext db;

        public UserRepository(AppContext db)
        {
            this.db = db;
        }

        public void GetUserByID()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) пользователя:");
            
            int id;
            bool result = int.TryParse(stringId, out id);
            
            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }
            
            User user = GetUser(id);
            if (user.Id == 0)
            {
                AlertMessage.Show("Пользователь с таким идентификатором в базе отсутствует.");
                return;
            }
            
            ShowUserData(user);
        }

        public void GetAllUsers()
        {
            var users = db.Users.ToList();
            if (users.Count == 0)
            {
                AlertMessage.Show("В базе отсутствуют пользователи.");
                return;
            }

            int currentUser = 1;
            foreach (var user in users)
            {
                Console.WriteLine("+------------------------ Пользователь #{currentUser}------------------------+", currentUser);
                ShowUserData(user);
                currentUser++;
            }
        }

        public void ShowUserData(User user)
        {
            Console.WriteLine("Информация о пользователе:");
            Console.WriteLine("Идентификатор: {0}", user.Id);
            Console.WriteLine("Имя: {0}", user.Name);
            Console.WriteLine("Email: {0}", user.Email);
        }

        private User GetUser(int id)
        {
            var usersQuery =
            from user in db.Users
            where user.Id == id
            select user;

            User foundUser = usersQuery.FirstOrDefault() ?? new User();

            return foundUser;
        }

        public User GetUser()
        {

            var stringId = QuestionMessage.Question("Введите идентификатор (id) пользователя:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return GetUser();
            }

            User user = GetUser(id);
            return user;
        }
        public void UpdateUserData()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) пользователя:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            User user = GetUser(id);
            if (user.Id == 0)
            {
                AlertMessage.Show("Пользователь с таким идентификатором в базе отсутствует.");
                return;
            }

            user.Name = QuestionMessage.Question("Введите имя пользователя:");

            Console.Write("EMail:");
            user.Email = QuestionMessage.Question("Введите EMail пользователя:");

            db.Users.Add(user);
            db.SaveChanges();
            SuccessMessage.Show("Данные успешно обновлены!");
        }

        public void AddNewUser()
        {
            User user = new User();
            
            user.Name = QuestionMessage.Question("Введите имя пользователя:");

            user.Email = QuestionMessage.Question("Введите EMail пользователя:");

            db.Users.Add(user);
            db.SaveChanges();

            SuccessMessage.Show("Пользователь успешно добавлен.");
        }

        public void RemoveUser()
        {
            var stringId = QuestionMessage.Question("Введите идентификатор (id) пользователя:");

            int id;
            bool result = int.TryParse(stringId, out id);

            if (!result)
            {
                AlertMessage.Show("Введено некорректное значение!");
                return;
            }

            User user = GetUser(id);
            if (user.Id == 0)
            {
                AlertMessage.Show("Пользователь с таким идентификатором в базе отсутствует.");
                return;
            }

            db.Users.Remove(user);
            db.SaveChanges();

            SuccessMessage.Show("Пользователь успешно удален.");
        }
    }
}
