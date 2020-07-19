using System;

namespace SecondTask.ThirdExercise
{
    /// <summary>
    /// Абстрактный класс, представляющий собой общую сущность всех продуктов.
    /// </summary>
    public abstract class Product
    {
        #region Fields
        /// <summary>
        /// Наименование товара.
        /// </summary>
        private protected string _name;
        /// <summary>
        /// Тип товара.
        /// </summary>
        private protected ProductType _typeOfProduct;
        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private protected double _cost;

        #endregion

        #region Constructors

        public Product()
        { }

        /// <summary>
        /// Инициализирует тип Product на основе наименования, вида и цены соответствующего продукта.
        /// </summary>
        /// <param name="name">Наименование продукта. В случае присвоения null-значения
        /// будет вызвана NullReferenceException с соответствующим сообщением.</param>
        /// <param name="typeOfProduct">Тип продукта. В случае присвоения null-значения
        /// будет вызвана NullReferenceException с соответствующим сообщением.</param>
        /// <param name="cost">Цена продукта. В случае присвоении цене отрицательного
        /// значения будет вызвано исключение Exception с соответствующимм сообщением.</param>
        public Product(string name, ProductType typeOfProduct, double cost)
        {
            Name = name;
            TypeOfProduct = typeOfProduct;
            Cost = cost;
        }

        #endregion Properties

        /// <summary>
        /// Свойство, возвращающее наименование продукта.
        /// </summary>
        public string Name
        {
            get
            {
                return _name.Clone() as string;
            }

            set
            {
                _name = value ?? throw new NullReferenceException("Name не может быть null");
            }
        }

        /// <summary>
        /// Свойство, возвращающее перечисление типа продукта.
        /// </summary>
        public ProductType TypeOfProduct
        {
            get
            {
                return _typeOfProduct;
            }

            set
            {
                _typeOfProduct = value;
            }
        }

        /// <summary>
        /// Свойство, возвращающее стоимость продукт.
        /// </summary>
        public double Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value > 0 ? value : throw new Exception("Значение Cost не может быть отрицательным");
            }
        }

        #region Methods

        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                return this == product;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        /// <summary>
        /// Метод по сложения двух продуктов.
        /// </summary>
        /// <typeparam name="T">Обобщенный параметр, представленный наследником типа Product.</typeparam>
        /// <param name="first">Первый продукт. Класс, производный от Product.</param>
        /// <param name="second">Второй продукт. Класс, производный от Product.</param>
        /// <returns></returns>
        public static T GetAdditionOfProducts<T> (T first, T second) where T : Product, new()
        {
            var average = (first.Cost + second.Cost) / 2.0;
            var result = new T() 
            { 
                Name = first.Name + "-" + second.Name, 
                TypeOfProduct = first.TypeOfProduct, 
                Cost = average
            };
            return result;
        }

        /// <summary>
        /// Метод приведения одного типа товара к другому.
        /// </summary>
        /// <typeparam name="T">Новый тип для преобразования.</typeparam>
        /// <typeparam name="K">Конвертируемый тип.</typeparam>
        /// <param name="product">Конвертируемый тип. Наследний типа Product с пустым конструктором.</param>
        /// <returns></returns>
        public static T GetConvertedProduct<T, K>(K product) 
                where T : Product, new()
                where K : Product, new()
        {
            var result = new T()
            {
                Name = product.Name,
                TypeOfProduct = product.TypeOfProduct,
                Cost = product.Cost
            };
            return result;
        }

        #endregion

        #region Operations

        public static bool operator ==(Product left, Product right)
        {
            if (left.Cost == right.Cost && left.Name == right.Name &&
                        left.TypeOfProduct == right.TypeOfProduct)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Product left, Product right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Преобразвание типа Product к целочисленному виду (перевод в копейки).
        /// </summary>
        /// <param name="product">Конвертируем продукт.</param>
        public static explicit operator int(Product product)
        {
            var result = (int)product.Cost * 100;
            return result;
        }

        /// <summary>
        /// Преобразвание типа Product к вещественному виду.
        /// </summary>
        /// <param name="product">Конвертируемый продукт.</param>
        public static explicit operator double(Product product)
        {
            var result = product.Cost;
            return result;
        }

        #endregion
    }

}






