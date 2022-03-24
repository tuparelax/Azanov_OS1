using System;
using System.IO;

namespace OS_Practice1
{
    class Files
    {
        public static void Start()
        {
            //2.Работа с файлами
            string path = @"D:\urfile.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Введите строку для заполнения файла:");
                string user_s = Console.ReadLine();
                // Создание файл для записи.
                using (StreamWriter sw = File.CreateText(path))
                {
                    Console.WriteLine("Файл создан.\n");
                    sw.WriteLine(user_s);

                }
            }

            // Открытия файл для чтения.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {

                    Console.WriteLine("Чтение файла:");
                    Console.WriteLine(s);
                }

            }
            Console.WriteLine("\nВы хотите удалить файл(1.Да/2.Нет):\n");
            bool final = true;
            while (final)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        File.Delete(path);
                        Console.WriteLine("Файл удален");
                        final = false;
                        break;
                    case "2":
                        Console.WriteLine("Файл сохранен");
                        final = false;
                        break;
                    default:
                        Console.WriteLine("Пожалуйста выберите (1) или (2)");
                        choice = Console.ReadLine();
                        break;

                }
            }
        }
    }
}