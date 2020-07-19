namespace SecondTask.ThirdExercise.Specific_Product
{
    /// <summary>
    /// Класс, представляющий продукты продукты, требующие 
    /// перед употреблением дополнительной кулинарной обработки.
    /// </summary>
    public class GroceryProduct : Product
    {
        public GroceryProduct()
        {
            TypeOfProduct = ProductType.Food;
        }

        /// <summary>
        /// Инициализция объекта типа HouseholdProduct,
        /// использую наименование и стоимость товара.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="cost">Стоимость продукта.</param>
        public GroceryProduct(string name, double cost) 
                : base (name, ProductType.Food, cost) 
        { }

        /// <summary>
        /// Сложение двух одинаковых продутов с сохранением общих полей.
        /// </summary>
        /// <param name="first">Первый продукт.</param>
        /// <param name="second">Второй продукт.</param>
        /// <returns>Возвращает объект типа GroceryProduct.</returns>
        public static GroceryProduct operator + (GroceryProduct first, GroceryProduct second)
        {
            GroceryProduct result = GetAdditionOfProducts(first, second);
            return result;
        }

        public static implicit operator BiochemicalProduct(GroceryProduct product)
        {
            BiochemicalProduct result = GetConvertedProduct<BiochemicalProduct, GroceryProduct>(product);
            return result;
        }

        public static implicit operator HouseholdProduct(GroceryProduct product)
        {
            HouseholdProduct result = GetConvertedProduct<HouseholdProduct, GroceryProduct>(product);
            return result;
        }

        public static implicit operator GastronomicProduct(GroceryProduct product)
        {
            GastronomicProduct result = GetConvertedProduct<GastronomicProduct, GroceryProduct>(product);
            return result;
        }

    }
}
