using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class UserInfoView
    {
        public UserRepository UserRepository { get; set; }
        
        public void Show(AppContext db)
        {
            UserRepository = new UserRepository(db);

            while (true)
            {
                Console.WriteLine("+------------- Работа с пользователями ---------------------+");
                Console.WriteLine("Найти пользователя по идентификатору (нажмите 1)");
                Console.WriteLine("Вывести перечень имеющихся пользователей (нажмите 2)");
                Console.WriteLine("Добавить пользователя (нажмите 3)");
                Console.WriteLine("Редактировать данные пользователя (нажмите 4)");
                Console.WriteLine("Удалить пользователя (нажмите 5)\n");

                Console.WriteLine("Возврат в предыдущее меню (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            UserRepository.GetUserByID();
                            break;
                        }
                    case "2":
                        {
                            UserRepository.GetAllUsers();
                            break;
                        }

                    case "3":
                        {
                            UserRepository.AddNewUser();
                            break;
                        }

                    case "4":
                        {
                            UserRepository.UpdateUserData();
                            break;
                        }

                    case "5":
                        {
                            UserRepository.RemoveUser();
                            break;
                        }
                }
            }

        }
    }
}
