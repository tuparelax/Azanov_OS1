using System;
using System.IO;
using System.IO.Compression;


namespace OS_Practice1
{
    class ZIP
    {
        public static void Start()
        {


            Console.WriteLine("Быберите директорию(Пример: C или D):");
            string dir = Console.ReadLine();
            Console.WriteLine("Название папку:");
            string folder = Console.ReadLine();
            string folder_path = $"{dir}://{folder}"; // исходная папка
            
            Console.WriteLine("Название файл:");
            string file = Console.ReadLine();
            string file_path = $"{dir}://{folder}/{file}.txt";
           
            string zipFile = $"{dir}://{folder}.zip"; // сжатый файл
            string targetFolder = $"D://unpack_{folder}/"; // папка, куда распаковывается файл
            string targetFolderfile = $"D://unpack_{folder}/{file}.txt";



            Console.WriteLine("\nВы хотите создать или использовать существующую папку с файлом?(1.Cоздать/2.Использовать):\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    var myFold = Directory.CreateDirectory(folder_path);
                    var myFile = File.Create(file_path);
                    myFile.Close();
                    ZipFile.CreateFromDirectory(folder_path, zipFile);
                    Console.WriteLine($"Папка {folder_path} архивирована в файл {zipFile}");
                    ZipFile.ExtractToDirectory(zipFile, targetFolder);
                    Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
                    Menu.Delete(file_path,folder_path, zipFile, targetFolder, targetFolderfile);
                    break;
                case "2":
                    ZipFile.CreateFromDirectory(folder_path, zipFile);
                    Console.WriteLine($"Папка {folder_path} архивирована в файл {zipFile}");
                    ZipFile.ExtractToDirectory(zipFile, targetFolder);
                    Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
                    Menu.Delete(file_path, folder_path, zipFile, targetFolder, targetFolderfile);
                    break;
                default:
                    Console.WriteLine("Пожалуйста выберите (1) или (2)");
                    choice = Console.ReadLine();
                    break;

            }
        }
    }
}