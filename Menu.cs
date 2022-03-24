using System;
using System.IO;
namespace OS_Practice1
{
    class Menu
    {

        public static void Delete(string file_path,string folder_path, string zipFile, string targetFolder, string targetFolderfile)
        {
            Console.WriteLine("Удалить файлы? (yes/no): ");
            switch (Console.ReadLine())
            {
                case "yes":
                    if ((Directory.Exists(folder_path) && File.Exists(file_path) && Directory.Exists(targetFolder) && File.Exists(zipFile) && File.Exists(targetFolderfile)) == true)
                    {
                    File.Delete(file_path);
                    Directory.Delete(folder_path);
                    File.Delete(zipFile);
                    File.Delete(targetFolderfile);
                    Directory.Delete(targetFolder);
                        Console.WriteLine("Файлы удалены!");
                    }
                    else Console.WriteLine("Ошибка в удалении файлов!\n Проверьте их наличие!");
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("Введены неправильные данные!");
                    break;
            }
            Console.ReadLine();
        }
        private static void PrintOptions()
        {
            Console.WriteLine("Выберете пункт:");
            Console.WriteLine("1.Информация о дисках");
            Console.WriteLine("2.Файлы");
            Console.WriteLine("3.JSON");
            Console.WriteLine("4.XML");
            Console.WriteLine("5.ZIP архив");
            Console.WriteLine("6.Выход");

        }
        static void Main(string[] args)
        {
            while (true)
            {
                PrintOptions();
                string choice = Console.ReadLine();
                
                
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Drives.Start();
                        break;
                    case "2":
                        Files.Start();
                        break;
                    case "3":
                        JSON.Start();
                        break;
                    case "4":
                        XML.Start();
                        break;
                    case "5":
                        ZIP.Start();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неизвестное значение");
                        break;

                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
