namespace SecondTask.ThirdExercise.Specific_Product
{
    /// <summary>
    /// Класс представляющий собой бытовые товары: часы, канцелярские, спортивными, 
    /// музыкальными товарами, книгами и журналами, мебель, посуда, бытовая техника,
    /// стройматериалы, бытовые химические и сельскохозяйственные товары.
    /// </summary>
    public class HouseholdProduct : Product
    {
        public HouseholdProduct()
        {
            TypeOfProduct = ProductType.NonFood;
        }

        /// <summary>
        /// Инициализция объекта типа HouseholdProduct,
        /// использую наименование и стоимость товара.
        /// </summary>
        /// <param name="name">Наименование товара.</param>
        /// <param name="cost">Стоимость продукта.</param>
        public HouseholdProduct(string name, double cost)
                : base(name, ProductType.NonFood, cost)
        { }

        /// <summary>
        /// Сложение двух одинаковых продутов с сохранением общих полей.
        /// </summary>
        /// <param name="first">Первый продукт.</param>
        /// <param name="second">Второй продукт.</param>
        /// <returns>Возвращает объект типа HouseholdProduct.</returns>
        public static HouseholdProduct operator +(HouseholdProduct first, HouseholdProduct second)
        {
            HouseholdProduct result = GetAdditionOfProducts(first, second);
            return result;
        }

        public static implicit operator BiochemicalProduct(HouseholdProduct product)
        {
            BiochemicalProduct result = GetConvertedProduct<BiochemicalProduct, HouseholdProduct>(product);
            return result;
        }

        public static implicit operator GroceryProduct(HouseholdProduct product)
        {
            GroceryProduct result = GetConvertedProduct<GroceryProduct, HouseholdProduct>(product);
            return result;
        }

        public static implicit operator GastronomicProduct(HouseholdProduct product)
        {
            GastronomicProduct result = GetConvertedProduct<GastronomicProduct, HouseholdProduct>(product);
            return result;
        }
    }
}
