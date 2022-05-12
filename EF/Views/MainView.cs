using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class MainView
    {
        public UserInfoView UserInfoView { get; set; }
        public BookInfoView BookInfoView { get; set; }
        public MainView()
        {
            UserInfoView = new();
            BookInfoView = new();
        }
        public void Show(AppContext db)
        {
            while (true)
            {
                Console.WriteLine("+------------------- Добро пожаловать! ----------------------+");
                Console.WriteLine("Работа с книгами (нажмите 1)");
                Console.WriteLine("Работа с пользователями (нажмите 2)");
                Console.WriteLine("Выйти (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            BookInfoView.Show(db);
                            break;
                        }
                    case "2":
                        {
                            UserInfoView.Show(db);
                            break;
                        }
                }
            }

        }
    }
}
