using SecondTask.ThirdExercise.Specific_Product.Radiation_level_of_the_product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask.ThirdExercise.Specific_Product
{
    /// <summary>
    /// Класс представляющий собой биохические товары: нефтепродукты,
    /// краски, корма и удобрения и т.д.
    /// </summary>
    public class BiochemicalProduct : Product
    {
        public BiochemicalProduct()
        {
            TypeOfProduct = ProductType.NonFood;
        }

        /// <summary>
        /// Инициализция объекта типа BiochemicalProduct,
        /// использую наименование, тип и стоимость товара.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="cost">Стоимость продукта.</param>
        public BiochemicalProduct(string name, double cost, RadiationGroup levelOfRadiation = RadiationGroup.E)
                : base(name, ProductType.NonFood, cost)
        {
            LevelOfRadiation = levelOfRadiation;
        }

        /// <summary>
        /// Свойство, возвращающее уровень радиации продукта.
        /// </summary>
        public RadiationGroup LevelOfRadiation { get; set; }

        /// <summary>
        /// Сложение двух одинаковых товар с сохранением общих полей.
        /// </summary>
        /// <param name="first">Первый товар.</param>
        /// <param name="second">Второй товар.</param>
        /// <returns>
        /// Возвращает объект типа BiochemicalProduct.
        /// </returns>
        public static BiochemicalProduct operator +(BiochemicalProduct first, BiochemicalProduct second)
        {
            BiochemicalProduct result = GetAdditionOfProducts(first, second);
            return result;
        }

        public static implicit operator GastronomicProduct(BiochemicalProduct product)
        {
            GastronomicProduct result = GetConvertedProduct<GastronomicProduct, BiochemicalProduct>(product);
            return result;
        }

        public static implicit operator HouseholdProduct(BiochemicalProduct product)
        {
            HouseholdProduct result = GetConvertedProduct<HouseholdProduct, BiochemicalProduct>(product);
            return result;
        }

        public static implicit operator GroceryProduct(BiochemicalProduct product)
        {
            GroceryProduct result = GetConvertedProduct<GroceryProduct, BiochemicalProduct>(product);
            return result;
        }
    }
}
