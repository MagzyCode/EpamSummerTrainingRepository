using NUnit.Framework;
using FourthTask.ClientPart.LanguageTranslator;

namespace FourthTask.Tests
{
    [TestFixture]
    public class TestTextTranslit
    {
        [TestCase("Миша", Language.Russian, ExpectedResult = "misha")]
        [TestCase("Natalia", Language.English, ExpectedResult = "наталиа")]
        [TestCase("Давай что-то посложнее", Language.Russian, ExpectedResult = "davai chto-to poslojnee")]
        public string ConvertToTranslit_RussianString_TranslitEnglishString(string testString, Language language)
        {
            var result = TranslitTranslater.ConvertToTranslit(testString, language);
            return result;
        }
    }
}