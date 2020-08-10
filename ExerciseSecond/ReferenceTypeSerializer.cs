using System;
using System.Globalization;
using System.IO;

namespace ExerciseSecond
{
    public class ReferenceTypeSerializer<T> where T : class, ISerialize<T>
    {
        private T _value;

        public void SerializeToBinaryFile(string path)
        {

        }

        public void SerializeToJSON(string path)
        {

        }

        public void SerializeToXmlFile(string path)
        {

        }

        public T DeserializeToBinaryFile(string path)
        {
            return null;
        }

        public T DeserializeToJSON(string path)
        {
            return null;
        }

        public T DeserializeToXmlFile(string path)
        {
            return null;
        }

    }
}
