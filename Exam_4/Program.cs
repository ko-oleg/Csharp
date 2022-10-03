using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Encodings.Web;
using System.Text.Json;
using Exam_4.Class;

namespace Exam_4
{
    class Program
    {
        public static string _path = "../../../Data/Index.json";
        static void Main(string[] args)
        {
            try
            {
                List<Cat> cats = new List<Cat>();
                CreatCat(cats);
                ChooseAction(cats);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так");
                throw;
            }
        }

        public static void CreatCat(List<Cat> cats)
        {
            Console.WriteLine("Введите имя кота");
            string catName = Console.ReadLine();
            Console.WriteLine("Введите возраст кота");
            int catAge = Int32.Parse(Console.ReadLine());
            cats.Add(new Cat(cats.Count + 1,catName,catAge));
            PrintCat(cats);
            Serialize(cats);
        }

        public static void PrintCat(List<Cat> cats)
        {
            Console.WriteLine("| номер\t | имя\t\t | возраст\t | здоровье\t | настроение\t | сытость\t | средний уровень\t |");
            if (cats.Count == 0)
            {
                Console.WriteLine("Список пуст");
                CreatCat(cats);
            }
            else
            {
                foreach (Cat i in cats.OrderBy(a => -a.AverageLevel))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void ChooseAction(List<Cat>cats) 
        {
            Console.WriteLine("Выберите действие: \n1: покормить \n2: поигарть \n3: к ветеринару \n4: завести нового питомца \n5: начать новый день");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Cat cat1 = ChooseCat(cats);
                    if (cat1.Action == ' ')
                    {
                        cat1.Eat();
                        PrintCat(cats);
                    }
                    else
                    {
                        Console.WriteLine($"Вы уже играли с {cat1.Name}, {cat1.Age} лет");
                    }
                    break;
                case 2:
                    Cat cat2 = ChooseCat(cats);
                    if (cat2.Action == ' ')
                    {
                        cat2.Eat();
                        PrintCat(cats);
                    }
                    else
                    {
                        Console.WriteLine($"Вы уже играли с {cat2.Name}, {cat2.Age} лет");
                    }
                    break;
                case 3:
                    Cat cat3 = ChooseCat(cats);
                    if (cat3.Action == ' ')
                    {
                        cat3.Eat();
                        PrintCat(cats);
                    }
                    else
                    {
                        Console.WriteLine($"Вы уже играли с {cat3.Name}, {cat3.Age} лет");
                    }
                    break;
                case 4:
                    CreatCat(cats);
                    break;
                case 5:
                    foreach (var cat in cats)
                    {
                        cat.NewDay();
                    }
                    PrintCat(cats);
                    break;
            }
            ChooseAction(cats);
        }

        public static Cat ChooseCat(List<Cat> cats)
        {
            Console.WriteLine("Выберите Id кота");
            PrintCat(cats);
            int catNum = Int32.Parse(Console.ReadLine());
            Cat cat = cats.Find((x) => x.Id ==catNum);
            return cat;
        }

        // public static List<Cat> GetCats()
        // {
        //     var json = File.ReadAllText(_path);
        //     List<Cat> cats = JsonSerializer.Deserialize <List<Cat>>(json);
        //     return cats;
        // }

        public static void Serialize(List<Cat> cats)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            string outData = JsonSerializer.Serialize(cats,options);
            File.WriteAllText(_path,outData);
        }
       
    }
    
}