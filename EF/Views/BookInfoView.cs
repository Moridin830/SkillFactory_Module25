using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Repositories;

namespace EF
{
    public class BookInfoView
    {
        public BookRepository BookRepository { get; set; }
        public GenreRepository GenreRepository { get; set; }
        public AutorRepository AutorRepository { get; set; }

        public void Show(AppContext db)
        {
            BookRepository = new BookRepository(db);
            GenreRepository = new GenreRepository(db);
            AutorRepository = new AutorRepository(db);

            while (true)
            {
                Console.WriteLine("+--------------- Работа с книгами ---------------------------+");
                Console.WriteLine("Найти книгу по идентификатору (нажмите 1)");
                Console.WriteLine("Вывести перечень имеющихся книг (нажмите 2)");
                Console.WriteLine("Добавить книгу (нажмите 3)");
                Console.WriteLine("Изменить данные книги (нажмите 4)");
                Console.WriteLine("Удалить книгу (нажмите 5)");
                Console.WriteLine("Выдать книгу пользователю (нажмите 6)");
                Console.WriteLine("Добавить новый жанр (нажмите 7)");
                Console.WriteLine("Добавить нового автора (нажмите 8)\n");

                Console.WriteLine("Возврат в предыдущее меню (нажмите 0)");

                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            BookRepository.GetBookByID();
                            break;
                        }
                    case "2":
                        {
                            BookRepository.GetAllBooks();
                            break;
                        }

                    case "3":
                        {
                            BookRepository.AddNewBook();
                            break;
                        }

                    case "4":
                        {
                            BookRepository.UpdateBook();
                            break;
                        }

                    case "5":
                        {
                            BookRepository.RemoveBook();
                            break;
                        }

                    case "6":
                        {
                            BookRepository.IssueBookToUser();
                            break;
                        }
                    case "7":
                        {
                            GenreRepository.AddGenre(db);
                            break;
                        }
                    case "8":
                        {
                            AutorRepository.AddAutor(db);
                            break;
                        }
                }
            }
        }
    }
}
