using System;

namespace SecondTask.ThirdExercise.Specific_Product
{
    /// <summary>
    /// Класс, представляющий товары, готовые к употреблению без 
    /// кулинарной обработки, или с повышенными вкусовыми свойствами.
    /// </summary>
    public class GastronomicProduct : Product
    {
        private double _nutritionalValue;

        public GastronomicProduct()
        {
            TypeOfProduct = ProductType.Food;
        }

        /// <summary>
        /// Инициализция объекта типа BiochemicalProduct,
        /// использую наименование, тип и стоимость товара.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="cost">Стоимость продукта.</param>
        /// <param name="nutritionalValue">Пищевая ценность.</param>
        public GastronomicProduct(string name, double cost, double nutritionalValue = 0)
                : base(name, ProductType.NonFood, cost)
        {
            NutritionalValue = nutritionalValue;
        }

        /// <summary>
        /// Свойство, возвращающее пищевую ценность продукта.
        /// При попытке присвоения отрицательного значения
        /// вызывается исключение Exception.
        /// </summary>
        public double NutritionalValue
        {
            get
            {
                return _nutritionalValue;
            }

            set
            {
                _nutritionalValue = value >= 0
                        ? value
                        : throw new Exception("Пищевая ценность не может быть отрицательность");
            }
        }

        public static GastronomicProduct operator +(GastronomicProduct first, GastronomicProduct second)
        {
            GastronomicProduct result = GetAdditionOfProducts(first, second);
            return result;
        }

        public static implicit operator BiochemicalProduct(GastronomicProduct product)
        {
            BiochemicalProduct result = GetConvertedProduct<BiochemicalProduct, GastronomicProduct>(product);
            return result;
        }

        public static implicit operator HouseholdProduct(GastronomicProduct product)
        {
            HouseholdProduct result = GetConvertedProduct<HouseholdProduct, GastronomicProduct>(product);
            return result;
        }

        public static implicit operator GroceryProduct(GastronomicProduct product)
        {
            GroceryProduct result = GetConvertedProduct<GroceryProduct, GastronomicProduct>(product);
            return result;
        }
    }
}
