namespace Application.Painting
{
    public enum FigureMaterial
    {
        /// <summary>
        /// Устанавливается в случае того, когда при создании фигуры
        /// нам не важен материал, т.к. цвет уже установлен.
        /// </summary>
        NonMaterial = -1,
        /// <summary>
        /// Бумага.
        /// </summary>
        Paper,
        /// <summary>
        /// Плёнка.
        /// </summary>
        Film
    }
}
