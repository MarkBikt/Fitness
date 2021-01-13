using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Калории на 1 грамм
        /// </summary>
        //private double CaloriesOneGramm { get { return Calories / 100.0; } }
        /// <summary>
        /// Белки на 1 грамм
        /// </summary>
        //private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        /// <summary>
        /// Жиры на 1 грамм
        /// </summary>
        //private double FatsOneGramm { get { return Fats / 100.0; } }
        /// <summary>
        /// Углеводы на 1 грамм
        /// </summary>
        //private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: Проверка

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;          
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
