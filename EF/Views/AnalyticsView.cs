using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Repositories;

namespace EF.Views
{
    public class AnalyticsView
    {
        public AnalitycsRepository AnalitycsRepository { get; set; }

        public void Show(AppContext db)
        {
            AnalitycsRepository = new AnalitycsRepository(db);
            while (true)
            {
                Console.WriteLine("+--------------- Работа с книгами ---------------------------+");
                Console.WriteLine("Получение списка книг определенного жанра и вышедших между определенными годами (нажмите 1)");
                Console.WriteLine("Получение количества книг определенного автора в библиотеке (нажмите 2)");
                Console.WriteLine("Получение количества книг определенного жанра в библиотеке (нажмите 3)");
                Console.WriteLine("Определить, есть ли книга определенного автора и с определенным названием в библиотеке (нажмите 4)");
                Console.WriteLine("Определить, есть ли определенная книга на руках у пользователя (нажмите 5)");
                Console.WriteLine("Получение количества книг на руках у пользователя (нажмите 6)");
                Console.WriteLine("Получение последней вышедшей книги (нажмите 7)");
                Console.WriteLine("Получение списка всех книг, отсортированного в алфавитном порядке по названию (нажмите 8)");
                Console.WriteLine("Получение списка всех книг, отсортированного в порядке убывания года их выхода (нажмите 9)\n");

                Console.WriteLine("Возврат в предыдущее меню (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            AnalitycsRepository.ListBooksOverPeriod();
                            break;
                        }
                    case "2":
                        {
                            AnalitycsRepository.GetBooksCountForAutor();
                            break;
                        }

                    case "3":
                        {
                            AnalitycsRepository.GetBooksCountForGenre();
                            break;
                        }

                    case "4":
                        {
                            AnalitycsRepository.ThereIsABookInTheLibrary();
                            break;
                        }

                    case "5":
                        {
                            AnalitycsRepository.UserHasBook();
                            break;
                        }

                    case "6":
                        {
                            AnalitycsRepository.NumberOfBooksUser();
                            break;
                        }
                    case "7":
                        {
                            AnalitycsRepository.LatestPublishedBook();
                            break;
                        }

                    case "8":
                        {
                            AnalitycsRepository.GetBooksTitleAscending();
                            break;
                        }

                    case "9":
                        {
                            AnalitycsRepository.GetBooksReleaseYearADescending();
                            break;
                        }
                }
            }
        }
    }
}
