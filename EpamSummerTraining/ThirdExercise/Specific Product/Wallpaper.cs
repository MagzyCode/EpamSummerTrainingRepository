using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SecondTask.ThirdExercise.Specific_Product
{
    public class Wallpaper : Product
    {
        public Wallpaper()
        {
            TypeOfProduct = ProductType.Food;
        }

        public Wallpaper(string name, ProductType typeOfProduct, double cost)
                : base(name, typeOfProduct, cost)
        { }

        public static Wallpaper operator +(Wallpaper first, Wallpaper second)
        {
            var i = GetConvertedProduct<Bread, Wallpaper>(first);
            var result = GetAdditionOfProducts(first, second);
            return result;
        }
    }
}
