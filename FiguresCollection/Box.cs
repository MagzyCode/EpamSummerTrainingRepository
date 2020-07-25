using Application.Figures;
using Application.Painting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public ISpecificFigure[] Figures { get; set; } = new ISpecificFigure[MAX_COUNT_OF_FIGURES];

        public int Count
        {
            get
            {
                GetLastElementIndex(out int index);
                return index;
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

        public Circle[] GetAllCircles()
        {
            var circles = new Circle[MAX_COUNT_OF_FIGURES];
            var counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Figures[i] is Circle circle)
                {
                    circles[counter++] = circle;
                    RemoveFigure(i);
                }
            }

            var numberOfElements = circles.Length;
            Array.Resize(ref circles, numberOfElements);
            return circles;
        }

        public ISpecificFigure[] GetAllFilmFigures()
        {
            var figures = new ISpecificFigure[MAX_COUNT_OF_FIGURES];
            var counter = 0;
            for (int i = 0; i < Count; i++)
            {
                if (Figures[i].ColorOfFigure == FigureColor.Transparent)
                {
                    figures[counter++] = Figures[i];
                    RemoveFigure(i);
                }
            }
                
            var numberOfElements = figures.Length;
            Array.Resize(ref figures, numberOfElements);
            return figures;
        }

        public void AddFigure(ISpecificFigure figure)
        {
            if (figure == null)
            {
                throw new Exception("Невозможно добавить фигуру");
            }

            foreach (ISpecificFigure item in Figures)
            {
                if (item == figure)
                {
                    throw new Exception("Невозможно добавлять аналогичные фигуры в коробку");
                }
            }

            Figures[Count] = figure;
        }

        public void RemoveFigure(int index)
        {
            if ((index >= MAX_COUNT_OF_FIGURES) || (index < 0))
            {
                throw new IndexOutOfRangeException();
            }
            Array.Copy(Figures, index + 1, Figures, index + 1, Count - index);
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

        private void GetLastElementIndex(out int index)
        {
            index = 0;
            for (int counter = 0; counter < MAX_COUNT_OF_FIGURES; counter++)
            {
                if (Figures[counter] == null)
                {
                    index = counter;
                    return;
                }
            }
        }

        #endregion

        

    }
}
