using NUnit.Framework;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExerciseSecond.Tests
{
    public class TestReferenceTypeSerializer
    {
        private SerializableClass _value;
        private List<SerializableClass> _list;
        public const int NUMBER_OF_ELEMENTS = 15;

        [SetUp]
        public void Setup()
        {
            _value = new SerializableClass();
            _list = new List<SerializableClass>(NUMBER_OF_ELEMENTS);
            for (int i = 0; i < NUMBER_OF_ELEMENTS; i++)
            {
                _list.Add(new SerializableClass());
            }
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBinarySerialize()
        {
            var serializer = new ReferenceTypeSerializer<SerializableClass>(_value);
            serializer.SerializeToBinaryFile();
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeFromBinaryFile();
            return _value.Equals(result);
        }

        [TestCase(ExpectedResult = true)]
        public bool TestXmlSerialize()
        {
            var serializer = new ReferenceTypeSerializer<SerializableClass>(_value);
            serializer.SerializeToXmlFile();
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeToXmlFile();
            return _value.Equals(result);
        }

        [TestCase(ExpectedResult = true)]
        public bool TestJsonSerializer()
        {
            var serializer = new ReferenceTypeSerializer<SerializableClass>(_value);
            serializer.SerializeToJson();
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeToJson();
            return _value.Equals(result);
        }

        [TestCase(ExpectedResult = true)]
        public bool TestJsonSerializerOfCollection()
        {
            ReferenceTypeSerializer<SerializableClass>.SerializeCollectionToJson(_list);
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeCollectionFromJson();
            return NUMBER_OF_ELEMENTS == result.Count;
        }

        [TestCase(ExpectedResult = true)]
        public bool TestXmlSerializerOfCollection()
        {
            ReferenceTypeSerializer<SerializableClass>.SerializeCollectionToXml(_list);
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeCollectionFromXml();
            return NUMBER_OF_ELEMENTS == result.Count;
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBinarySerializerOfCollection()
        {
            ReferenceTypeSerializer<SerializableClass>.SerializeCollectionToBinary(_list);
            var result = ReferenceTypeSerializer<SerializableClass>.DeserializeCollectionFromBinary();
            return NUMBER_OF_ELEMENTS == result.Count;
        }


    }
}