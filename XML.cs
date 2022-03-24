using System;
using System.IO;
using System.Xml.Linq;

namespace OS_Practice1
{
    static class XML
    {
        const string Path = @"D:\urfile.xml";

        private static void GenerateXml()
        {

            XDocument xdoc = new XDocument();
           
            XElement compElement = new XElement("company");
            XAttribute compNameAttr = new XAttribute("name", "SCP_Foundation");
            compElement.Add(compNameAttr);

            XElement employee1 = new XElement("employee");
            employee1.Add(new XElement("id", 1));
            employee1.Add(new XElement("firstName", "John"));
            employee1.Add(new XElement("lastName", "Wick"));
            employee1.Add(new XElement("age", 58));
            employee1.Add(new XElement("photo", "https://www.synapsenews.com/wp-content/uploads/2016/02/johnwick2-1024x562.jpg"));

            XElement employee2 = new XElement("employee");
            employee2.Add(new XElement("id", 137));
            employee2.Add(new XElement("firstName", "Rick"));
            employee2.Add(new XElement("lastName", "Sanchez"));
            employee2.Add(new XElement("age", 70));
            employee2.Add(new XElement("photo", "https://media2.phoenixnewtimes.com/phx/imager/u/original/10613550/christopher-lloyd-back-to-the-future-rick-and-morty-donald-trump.jpg"));

            XElement employee3 = new XElement("employee");
            employee3.Add(new XElement("id", 3));
            employee3.Add(new XElement("firstName", "Miron"));
            employee3.Add(new XElement("lastName", "Fedorov"));
            employee3.Add(new XElement("age", 37));
            employee3.Add(new XElement("photo", "https://upload.wikimedia.org/wikipedia/commons/7/7c/Oxxxymiron._Reebok.png"));

            XElement employees = new XElement("employees");
            employees.Add(employee1, employee2, employee3);
            compElement.Add(employees);

            xdoc.Add(compElement);
            xdoc.Save(Path);
        }


        public static void Start()
        {
            GenerateXml();

            XDocument xdoc = XDocument.Load(Path);
            Console.WriteLine("Готовый XML:\n");
            Console.WriteLine(xdoc + "\n");

            Console.WriteLine("Введите информацию о новом сотруднике:");
            XElement newEmployee = new XElement("employee");
            Console.Write("Идентификатор сотрудника: ");
            newEmployee.Add(new XElement("id", Convert.ToInt32(Console.ReadLine())));
            Console.Write("Имя сотрудника: ");
            newEmployee.Add(new XElement("firstName", Console.ReadLine()));
            Console.Write("Фамилия сотрудника: ");
            newEmployee.Add(new XElement("lastName", Console.ReadLine()));
            Console.Write("Возраст сотрудника: ");
            newEmployee.Add(new XElement("age", Convert.ToInt32(Console.ReadLine())));
            Console.Write("Фото URL: ");
            newEmployee.Add(new XElement("photo", Console.ReadLine()));

            XElement root = xdoc.Element("company");
            XElement empl = root.Element("employees");
            empl.Add(newEmployee);
            xdoc.Save(Path);

            Console.WriteLine("\nРедактированный XML:\n");
            Console.WriteLine(xdoc + "\n");
            Console.WriteLine("\nВы хотите удалить файл(1.Да/2.Нет):\n");
            bool final = true;
            while (final)
            {
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        File.Delete(Path);
                        Console.WriteLine("Файл удален");
                        final = false;
                        break;
                    case "2":
                        Console.WriteLine("Файл сохранен");
                        final = false;
                        break;
                    default:
                        Console.WriteLine("Пожалуйста выберите (1) или (2)");
                        break;

                }
            }
            
        }
    }
}








