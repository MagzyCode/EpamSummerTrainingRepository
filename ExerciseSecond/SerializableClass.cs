using System;
using System.Reflection;

[assembly: AssemblyVersion("1.1.1.1")]

namespace ExerciseSecond
{
    /// <summary>
    /// Class for checking work of ReferenceTypeSerializer type.
    /// </summary>
    [Serializable]
    public class SerializableClass : ISerialize<SerializableClass>
    {

        public SerializableClass()
        {
            FirstProperty = new Guid().ToString();
            SecondProperty = new Random().Next();
            ThirdProperty = DateTime.Now;
        }

        public string FirstProperty { get; set; }
        public int SecondProperty { get; set; }
        public DateTime ThirdProperty { get; set; }

        /// <summary>
        /// Compare objects by their properties.
        /// </summary>
        /// <param name="obj">The object being compared.</param>
        /// <returns>Returns true if the object.</returns>
        public override bool Equals(object obj)
        {
            return obj is SerializableClass @class &&
                   FirstProperty == @class.FirstProperty &&
                   SecondProperty == @class.SecondProperty &&
                   ThirdProperty.Date == @class.ThirdProperty.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstProperty, SecondProperty, ThirdProperty);
        }
    }
}
