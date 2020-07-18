using SecondTask.FirstExercise;
using SecondTask.ThirdExercise.Specific_Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask.ThirdExercise
{
    public class Product
    {
        #region Fields
        /// <summary>
        /// Наименование товара
        /// </summary>
        private protected string _name;
        /// <summary>
        /// Тип товара
        /// </summary>
        private protected ProductType _typeOfProduct;
        /// <summary>
        /// Стоимость товара
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
        /// будет вызвана NullReferenceException с соответствующим сообщением</param>
        /// <param name="cost">Цена продукта. В случае присвоении цене отрицательного
        /// значения будет вызвано исключение Exception с соответствующимм сообзением</param>
        public Product(string name, ProductType typeOfProduct, double cost)
        {
            _name = name ?? throw new NullReferenceException("Значение name не может быть null");
            _typeOfProduct = typeOfProduct;
            _cost = cost > 0 ? cost : throw new Exception("Значение cost не может быть отрицательным");
        }

        #endregion Properties

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

        public ProductType TypeOfProduct
        {
            get
            {
                return _typeOfProduct;
            }

            set
            {
                // _typeOfProduct = GetType().Name;
                _typeOfProduct = value;
            }
        }

        public double Cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value > 0 ? value : throw new Exception();
            }
        }

        #region Methods
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

        public static explicit operator int(Product product)
        {
            var result = (int)product.Cost * 100;
            return result;
        }

        public static explicit operator double(Product product)
        {
            var result = product.Cost;
            return result;
        }


        #endregion
    }

}






