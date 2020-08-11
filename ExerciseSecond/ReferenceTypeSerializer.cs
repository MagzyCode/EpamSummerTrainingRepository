using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ExerciseSecond
{
    /// <summary>
    /// The generic type for serialization 
    /// of any reference types. 
    /// which realize interface ISerialize.
    /// </summary>
    /// <typeparam name="T">Any class that inherits an interface ISerialize.</typeparam>
    public class ReferenceTypeSerializer<T> where T : class, ISerialize<T>
    {

        public ReferenceTypeSerializer(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Value of the serializable type.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Serializing the value to binary format.
        /// </summary>
        /// <param name="path">Path to the saved file.</param>
        public void SerializeToBinaryFile(string path = "node.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, Value); 
        }

        /// <summary>
        /// Serializing the value to JSON format.
        /// </summary>
        /// <param name="path">Path to the saved file.</param>
        public void SerializeToJson(string path = "node.json")
        {
            SaveVersion();
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            jsonFormatter.WriteObject(stream, Value);
        }

        /// <summary>
        /// Serializing the value to XML format.
        /// </summary>
        /// <param name="path">Path to the saved file.</param>
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
        /// Deserializing a binary file to a reference type.
        /// </summary>
        /// <param name="path">Path to the binary file.</param>
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
        /// Deserializing a JSON file to a reference type..
        /// </summary>
        /// <param name="path">Path to the JSON file.</param>
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
        /// Deserializing a XML file to a reference type..
        /// </summary>
        /// <param name="path">Path to the XML file.</param>
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
        /// Serializing a collection of reference 
        /// types to binary format.
        /// </summary>
        /// <param name="collection">Serializable collection.</param>
        /// <param name="path">Path to the saved file.</param>
        public static void SerializeCollectionToBinary(ICollection<T> collection, string path = "collection.bin")
        {
            SaveVersion();
            var binaryFormatter = new BinaryFormatter();
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(stream, collection);
        }

        /// <summary>
        /// Deserializing a collection of reference 
        /// types in binary format.
        /// </summary>
        /// <param name="path">Path to the binary file.</param>
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
        /// Serializing a collection of reference 
        /// types to JSON format.
        /// </summary>
        /// <param name="collection">Serializable collection.</param>
        /// <param name="path">Path to the saved file..</param>
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
        /// Deserializing a collection of reference 
        /// types in JSON format.
        /// </summary>
        /// <param name="path">Path to the JSON file.</param>
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
        /// Serializing a collection of reference 
        /// types to XML format.
        /// </summary>
        /// <param name="collection">Serializable collection.</param>
        /// <param name="path">Path to the saved file.</param>
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
        /// Deserializing a collection of reference 
        /// types in XML format.
        /// </summary>
        /// <param name="path">Path to the XML file.</param>
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
        /// Checking the type version after deserialization.
        /// </summary>
        /// <param name="pathOfVersion">File with saving the type version.</param>
        /// <returns>Returns true if the version.</returns>
        private static bool IsVersionValid(string pathOfVersion = "classVersion.txt")
        {
            using var reader = new StreamReader(pathOfVersion);
            var correctVersion = reader.ReadLine();
            var classVersion = typeof(T).Assembly.GetName().Version.ToString();
            return correctVersion == classVersion;
        }

        /// <summary>
        /// Saving version of the type.
        /// </summary>
        /// <param name="path">File with the saved version of the</param>
        private static void SaveVersion(string path = "classVersion.txt")
        {
            using var writer = new StreamWriter(path);
            var fileVersion = typeof(T).Assembly.GetName().Version;
            writer.WriteLine(fileVersion);
        }

    }
}
