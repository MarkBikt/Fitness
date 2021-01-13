using CodeFitness.BL.Controller;
using CodeFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("CodeFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("EnterGender", culture);
                var gender = Console.ReadLine();
               
                var birthDate = ParseDateTime();

                var weight = ParseDouble(resourceManager.GetString("Weight", culture));

                var height = ParseDouble(resourceManager.GetString("Height", culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(resourceManager.GetString("WhatDoing", culture));
            Console.WriteLine("E - ввести прием пищи");
            
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating(culture);
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
                
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating(CultureInfo culture)
        {
            Console.WriteLine("EnterNameProduct", culture);
            var food = Console.ReadLine();
        
            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
           
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {           
            while (true)
            {
                Console.WriteLine("Введите дату рождения(dd, mm, yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }           
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}а!");
                }
            }
        }
    }
}
