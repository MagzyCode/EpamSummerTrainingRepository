using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ExerciseSecond
{
    /// <summary>
    /// Generic type for serializing any types 
    /// which realize interface ISerialize.
    /// </summary>
    /// <typeparam name="T">Any class, which realize interface ISerialize.</typeparam>
    public class ReferenceTypeSerializer<T> where T : class, ISerialize<T>
    {

        public ReferenceTypeSerializer(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Value of serializable type.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Serialize value to binary format.
        /// </summary>
        /// <param name="path">Path of saved file.</param>
        public void SerializeToBinaryFile(string path = "node.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, Value); 
        }

        /// <summary>
        /// Serialize value to JSON format.
        /// </summary>
        /// <param name="path">Path of saved file.</param>
        public void SerializeToJson(string path = "node.json")
        {
            SaveVersion();
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(stream, Value);
        }

        /// <summary>
        /// Serialize value to Xml format.
        /// </summary>
        /// <param name="path">Path of saved file.</param>
        public void SerializeToXmlFile(string path = "node.xml")
        {
            SaveVersion();
            var xmlFormatter = new XmlSerializer(typeof(T));
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(stream, Value);
        }

        /// <summary>
        /// Deserialize value from binary format.
        /// </summary>
        /// <param name="path">File path with binary information.</param>
        /// <returns>Type value.</returns>
        public static T DeserializeFromBinaryFile(string path = "node.bin")
        {
            if (IsVersionValid())
            {
                var binaryFormatter = new BinaryFormatter();
                T value = null;
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    value = binaryFormatter.Deserialize(stream) as T;
                }  
                return value;
            }
            return null;
        }

        /// <summary>
        /// Deserialize value from Json format.
        /// </summary>
        /// <param name="path">File path with Json information.</param>
        /// <returns>Type value.</returns>
        public static T DeserializeFromJson(string path = "node.json")
        {
            if (IsVersionValid())
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(T));
                T value = null;
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    value = jsonFormatter.ReadObject(stream) as T;
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// Deserialize value from Xml format.
        /// </summary>
        /// <param name="path">File path with Xml information.</param>
        /// <returns>Type value.</returns>
        public static T DeserializeToXmlFile(string path = "node.xml")
        {
            if (IsVersionValid())
            {
                var xmlFormatter = new XmlSerializer(typeof(T));
                T value = null;
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    value = xmlFormatter.Deserialize(stream) as T;
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// Serialize collection to binary format.
        /// </summary>
        /// <param name="collection">Saved collection.</param>
        /// <param name="path">Path of saved file.</param>
        public static void SerializeCollectionToBinary(ICollection<T> collection, string path = "collection.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, collection);
        }

        /// <summary>
        /// Deserialize collection from binary format.
        /// </summary>
        /// <param name="path">File path with binary information.</param>
        /// <returns>Collection value.</returns>
        public static ICollection<T> DeserializeCollectionFromBinary(string path = "collection.bin")
        {
            if (IsVersionValid())
            {
                var binaryFormatter = new BinaryFormatter();
                List<T> value = null;
                using (var stream = new FileStream(path, FileMode.OpenOrCreate)) 
                {
                    value = binaryFormatter.Deserialize(stream) as List<T>;
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// Serialize collection to Json format.
        /// </summary>
        /// <param name="collection">Saved collection.</param>
        /// <param name="path">Path of saved file.</param>
        public static void SerializeCollectionToJson(ICollection<T> collection, string path = "collection.json")
        {
            SaveVersion();
            var list = collection.ToList();
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(stream, list);
        }

        /// <summary>
        /// Deserialize collection from Json format.
        /// </summary>
        /// <param name="path">File path with Json information.</param>
        /// <returns>Collection value.</returns>
        public static ICollection<T> DeserializeCollectionFromJson(string path = "collection.json")
        {
            if (IsVersionValid())
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
                List<T> value = null;
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    value = jsonFormatter.ReadObject(stream) as List<T>;
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// Serialize collection to Xml format.
        /// </summary>
        /// <param name="collection">Saved collection.</param>
        /// <param name="path">Path of saved file.</param>
        public static void SerializeCollectionToXml(ICollection<T> collection, string path = "collection.xml")
        {
            SaveVersion();
            var list = new List<T>(collection);
            var xmlFormatter = new XmlSerializer(typeof(List<T>));
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(stream, list);
        }

        /// <summary>
        /// Deserialize collection from Xml format.
        /// </summary>
        /// <param name="path">File path with Xml information.</param>
        /// <returns>Collection value.</returns>
        public static ICollection<T> DeserializeCollectionFromXml(string path = "collection.xml")
        {
            if (IsVersionValid())
            {
                var xmlFormatter = new XmlSerializer(typeof(List<T>));
                List<T> value = null;
                using (var stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    value = xmlFormatter.Deserialize(stream) as List<T>;
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// Check correct version of type using AssemblyVersion.
        /// </summary>
        /// <param name="pathOfVersion">File this type version.</param>
        /// <returns>Returns true if version is correct.</returns>
        private static bool IsVersionValid(string pathOfVersion = "classVersion.txt")
        {
            using var reader = new StreamReader(pathOfVersion);
            var correctVersion = reader.ReadLine();
            var classVersion = typeof(T).Assembly.GetName().Version.ToString();
            return correctVersion == classVersion;
        }

        /// <summary>
        /// Save version of savedType.
        /// </summary>
        /// <param name="path">File path for saving type version.</param>
        private static void SaveVersion(string path = "classVersion.txt")
        {
            using var writer = new StreamWriter(path);
            var fileVersion = typeof(T).Assembly.GetName().Version;
            writer.WriteLine(fileVersion);
        }

    }
}
