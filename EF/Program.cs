
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    class Program
    {
        public static MainView mainView;
        static void Main(string[] args)
        {
            MainView mainView = new MainView();
            using (var db = new AppContext())
            {
                mainView.Show(db);
                //var user1 = new User { Name = "Arthur", Email = "Arthurs@mail" };
                //var user2 = new User { Name = "klim", Email = "klims@mail" };

                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.SaveChanges();
            }
        }
    }
}
