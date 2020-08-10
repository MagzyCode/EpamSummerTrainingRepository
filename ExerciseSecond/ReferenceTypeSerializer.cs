using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ExerciseSecond
{
    public class ReferenceTypeSerializer<T> where T : class, ISerialize<T>
    {

        public ReferenceTypeSerializer(T value)
        {
            Value = value;
        }

        public T Value { get; set; }



        public void SerializeToBinaryFile(string path = "node.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, Value); 
        }

        public void SerializeToJson(string path = "node.json")
        {
            SaveVersion();
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(stream, Value);
        }

        public void SerializeToXmlFile(string path = "node.xml")
        {
            SaveVersion();
            var xmlFormatter = new XmlSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(stream, Value);
        }

        public static T DeserializeToBinaryFile(string path = "node.bin")
        {
            if (IsVersionValid())
            {
                var binaryFormatter = new BinaryFormatter();
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                T value = binaryFormatter.Deserialize(stream) as T;
                return value;
            }
            return null;
        }

        public static T DeserializeToJson(string path = "node.json")
        {
            if (IsVersionValid())
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(T));
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                var value = jsonFormatter.ReadObject(stream) as T;
                return value;
            }
            return null;
        }

        public static T DeserializeToXmlFile(string path = "node.xml")
        {
            if (IsVersionValid())
            {
                var xmlFormatter = new XmlSerializer(typeof(T));
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                var value = xmlFormatter.Deserialize(stream) as T;
                return value;
            }
            return null;
        }

        public static void SerializeCollectionToBinary(ICollection<T> collection, string path = "collection.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, collection);
        }

        public static ICollection<T> DeserializeCollectionFromBinary(string path = "collection.bin")
        {
            if (IsVersionValid())
            {
                var binaryFormatter = new BinaryFormatter();
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                var value = binaryFormatter.Deserialize(stream) as ICollection<T>;
                return value;
            }
            return null;
        }

        public static void SerializeCollectionToJson(ICollection<T> collection, string path = "collection.json")
        {
            SaveVersion();
            var list = collection.ToList();
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(stream, list);
        }

        public static ICollection<T> DeserializeCollectionFromJson(string path = "collection.json")
        {
            if (IsVersionValid())
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                var value = jsonFormatter.ReadObject(stream) as ICollection<T>;
                return value;
            }
            return null;
        }

        public static void SerializeCollectionToXml(ICollection<T> collection, string path = "collection.xml")
        {
            SaveVersion();
            var list = new List<T>(collection);
            var xmlFormatter = new XmlSerializer(typeof(List<T>));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(stream, list);
        }

        public static ICollection<T> DeserializeCollectionFromXml(string path = "collection.xml")
        {
            if (IsVersionValid())
            {
                var xmlFormatter = new XmlSerializer(typeof(List<T>));
                using var stream = new FileStream(path, FileMode.OpenOrCreate);
                var value = xmlFormatter.Deserialize(stream) as List<T>;
                return value;
            }
            return null;
        }

        private static bool IsVersionValid(string pathOfVersion = "classVersion.txt")
        {
            using var reader = new StreamReader(pathOfVersion);
            var correctVersion = reader.ReadLine();
            var classVersion = typeof(T).Assembly.GetName().Version.ToString();
            return correctVersion == classVersion;
        }

        private static void SaveVersion(string path = "classVersion.txt")
        {
            using var writer = new StreamWriter(path);
            var fileVersion = typeof(T).Assembly.GetName().Version;
            writer.WriteLine(fileVersion);
        }

    }
}
