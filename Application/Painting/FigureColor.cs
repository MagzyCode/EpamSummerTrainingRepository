﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Painting
{
    public enum FigureColor
    {
        NonColor = -1,
        /// <summary>
        /// Прозрачный цвет. Подходит только для плёнки.
        /// </summary>
        Transparent,
        /// <summary>
        /// Первоначальный цвет бумаги.
        /// </summary>
        PaperDefaultColor,
        White,
        Black,
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
        Brown,
        Grey
    }
}
