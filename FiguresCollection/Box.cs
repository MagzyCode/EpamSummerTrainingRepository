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

        #endregion

        #region Constructors

        #endregion

        #region Indexer

        public ISpecificFigure this[int index]
        {
            get
            {
                return Figures[index].Clone() as ISpecificFigure;
            }
        }

        #endregion

        #region Properties

        public List<ISpecificFigure> Figures { get; set; } = new List<ISpecificFigure>(MAX_COUNT_OF_FIGURES);

        public int Count
        {
            get
            {
                return Figures.Count;
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

            foreach (ISpecificFigure item in Figures)
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

            foreach (ISpecificFigure item in Figures)
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

            foreach (ISpecificFigure item in Figures)
            {
                if (item == figure)
                {
                    throw new Exception("Невозможно добавлять аналогичные фигуры в коробку");
                }
            }

            Figures.Add(figure);
        }

        public void RemoveFigure(int index)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }

            Figures.RemoveAt(index);
        }

        public void ReplaceFigure(int index, ISpecificFigure figure)
        {
            Figures[index] = figure ?? throw new NullReferenceException();
        }

        public ISpecificFigure Find(Type figureType, FigureColor color)
        {
            foreach (ISpecificFigure item in Figures)
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
            foreach (ISpecificFigure item in Figures)
            {
                total += item.GetPerimeter();
            }
            return total;
        }

        private double GetTotalArea()
        {
            var total = 0.0;
            foreach (ISpecificFigure item in Figures)
            {
                total += item.GetArea();
            }
            return total;
        }



        #endregion

        

    }
}
