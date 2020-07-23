using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FiguresCollection
{
    public class Box
    {
        #region Fields

        public const int MAX_COUNT_OF_FIGURES = 20;
        private List<ISpecificFigure> _figures = new List<ISpecificFigure>(MAX_COUNT_OF_FIGURES);

        #endregion

        #region Constructors

        #endregion

        #region Indexer

        public ISpecificFigure this[int index]
        {
            get
            {
                return _figures[index].Clone() as ISpecificFigure;
            }
        }

        #endregion

        #region Properties

        public List<ISpecificFigure> Figures
        {
            get
            {
                return _figures;
            }

            set
            {
                _figures = value;
            }
        }

        public int Count
        {
            get
            {
                return _figures.Count;
            }
        }

        public double TotalPerimeter
        {
            get
            {
                return GetTotalPerimeter();
            }
        }

        public double TotalArea
        {
            get
            {
                return GetTotalArea();
            }
        }

        #endregion

        #region Methods

        public List<ISpecificFigure> GetAllCircles()
        {
            List<ISpecificFigure> figures = new List<ISpecificFigure>();

            foreach (ISpecificFigure item in _figures)
            {
                if (item.GetType() == typeof(Circle))
                {
                    var figure = item.Clone() as ISpecificFigure;
                    figures.Add(figure);
                }
            }
            return figures;
        }

        public List<ISpecificFigure> GetAllFilmFigures()
        {
            List<ISpecificFigure> figures = new List<ISpecificFigure>();

            foreach (ISpecificFigure item in _figures)
            {
                if (item.ColorOfFigure == FigureColor.Transparent)
                {
                    var figure = item.Clone() as ISpecificFigure;
                    figures.Add(figure);
                }
            }
            return figures;
        }

        public void AddFigure(ISpecificFigure figure)
        {
            if (figure == null)
            {
                throw new Exception("Значение фигуры не может быть null");
            }

            foreach (ISpecificFigure item in _figures)
            {
                if (item == figure)
                {
                    throw new Exception("Невозможно добавлять аналогичные фигуры в коробку");
                }
            }

            _figures.Add(figure);
        }

        public void RemoveFigure(int index)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }

            _figures.RemoveAt(index);
        }

        public void ReplaceFigure(int index, ISpecificFigure figure)
        {
            _figures[index] = figure ?? throw new NullReferenceException();
        }

        public ISpecificFigure Find(Type figureType, FigureColor color)
        {
            foreach (ISpecificFigure item in _figures)
            {
                if ((item.GetType() == figureType) && (item.ColorOfFigure == color))
                {
                    return item;
                }
            }
            return null;
        }

        private double GetTotalPerimeter()
        {
            var total = 0.0;
            foreach (ISpecificFigure item in _figures)
            {
                total += item.GetPerimeter();
            }
            return total;
        }

        private double GetTotalArea()
        {
            var total = 0.0;
            foreach (ISpecificFigure item in _figures)
            {
                total += item.GetArea();
            }
            return total;
        }



        #endregion

        

    }
}
