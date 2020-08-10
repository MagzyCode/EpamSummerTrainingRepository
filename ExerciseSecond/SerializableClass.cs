using System;
using System.Reflection;

[assembly: AssemblyVersion("1.1.1.1")]

namespace ExerciseSecond
{
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
