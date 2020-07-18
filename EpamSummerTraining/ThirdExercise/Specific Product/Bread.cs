using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask.ThirdExercise.Specific_Product
{
    public class Bread : Product
    {
        public Bread()
        {
            TypeOfProduct = ProductType.Food;
        }

        public Bread(string name, ProductType typeOfProduct, double cost) 
                : base (name, typeOfProduct, cost) 
        { }

        public static Bread operator + (Bread first, Bread second)
        { 
            var result = GetAdditionOfProducts(first, second);
            return result;
        }

    }
}
