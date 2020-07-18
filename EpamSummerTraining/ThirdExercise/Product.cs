using System;
using System.Collections.Generic;
using System.Text;

namespace SecondTask.ThirdExercise
{
    public abstract class Product
    {
        #region Fields
        /// <summary>
        /// Наименование товара
        /// </summary>
        private string _name;
        /// <summary>
        /// Тип товара
        /// </summary>
        private string _typeOfProduct;
        /// <summary>
        /// Стоимость товара
        /// </summary>
        private double _cost;

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
        public Product(string name, string typeOfProduct, double cost)
        {
            _name = name ?? throw new NullReferenceException("Значение name не может быть null");
            _typeOfProduct = typeOfProduct ?? throw new NullReferenceException("TypeOfProduct не может быть null");
            _cost = cost > 0 ? cost : throw new Exception("Значение cost не может быть отрицательным");
        }

        #endregion Properties

        public string NameOfProduct
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

        public string TypeOfProduct
        {
            get
            {
                return _typeOfProduct.Clone() as string;
            }

            set
            {
                _typeOfProduct = value ?? throw new NullReferenceException("TypeOfProduct не может быть null");
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

        #endregion

        #region Operations

        //public abstract Product operator +(Product first, Product second);
        //{
        //    if (first.GetType() == second.GetType())
        //    {
        //        var result = new Product()
        //        {
        //            // NameOfProduct = $"{first.NameOfProduct}-{second.NameOfProduct}";
        //        }
        //    }
        //}

        #endregion




        
    }
}
