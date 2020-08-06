using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseFirst.Collection
{
    public interface IBinaryTreeElement<T> where T : class
    {
        T Left { get; set; }
        T Right { get; set; }
    }
}
