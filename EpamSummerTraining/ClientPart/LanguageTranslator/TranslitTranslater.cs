using System;
using System.Collections.Generic;
using System.Text;

namespace FourthTask.ClientPart.LanguageTranslator
{
    public static class TranslitTranslater
    {
        //public static readonly Dictionary<string, string> englishTranslit = new Dictionary<string, string>()
        //{
        //    {"а", "a"},
        //    {"б", "b"},
        //    {"в", "v"},
        //    {"г", "g"},
        //    {"д", "d"},
        //    {"е", "e"},
        //    {"ё", "e"},
        //    {"ж", "j"},
        //    {"з", "z"},
        //    {"и", "i"},
        //    {"й", "i"},
        //    {"к", "k"},
        //    {"л", "l"},
        //    {"м", "m"},
        //    {"н", "n"},
        //    {"о", "o"},
        //    {"п", "p"},
        //    {"р", "r"},
        //    {"с", "s"},
        //    {"т", "t"},
        //    {"у", "u"},
        //    {"ф", "f"},
        //    {"х", "h"},
        //    {"ц", "c"},
        //    {"ч", "ch"},
        //    {"ш", "sh"},
        //    {"щ", "sc"},
        //    {"ъ", ""},
        //    {"ы", "y"},
        //    {"ь", ""},
        //    {"э", "e"},
        //    {"ю", "iu"},
        //    {"я", "ia"},
        //};

        //public static readonly Dictionary<string, string> russianTranslit = new Dictionary<string, string>()
        //{
        //    {"a", "а"},
        //    {"b", "б"},
        //    {"c", "к"},
        //    {"d", "д"},
        //    {"e", "и"},
        //    {"f", "ф"},
        //    {"g", "дж"},
        //    {"h", "х"},
        //    {"i", "ай"},
        //    {"j", "дж"},
        //    {"k", "к"},
        //    {"l", "л"},
        //    {"m", "м"},
        //    {"m", "н"},
        //    {"o", "о"},
        //    {"p", "п"},
        //    {"q", "кью"},
        //    {"r", "р"},
        //    {"s", "с"},
        //    {"t", "т"},
        //    {"u", "ю"},
        //    {"v", "в"},
        //    {"w", "уи"},
        //    {"x", "х"},
        //    {"y", "уай"},
        //    {"z", "з"},
        //};

        public static string ToEnglishTranslit(char letter) => letter switch
        {
            'а' => "a",
            'б' => "b",
            'в' => "v",
            'г' => "g",
            'д' => "d",
            'е' => "e",
            'ё' => "e",
            'ж' => "j",
            'з' => "z",
            'и' => "i",
            'й' => "i",
            'к' => "k",
            'л' => "l",
            'м' => "m",
            'н' => "n",
            'о' => "o",
            'п' => "p",
            'р' => "r",
            'с' => "s",
            'т' => "t",
            'у' => "u",
            'ф' => "f",
            'х' => "h",
            'ц' => "c",
            'ч' => "ch",
            'ш' => "sh",
            'щ' => "sc",
            'ы' => "y",
            'э' => "e",
            'ю' => "iu",
            'я' => "ia",
            _ => letter.ToString()
        };

        public static string ToRussianTranslit(char letter) => letter switch
        {
            'a' => "а",
            'b' => "б",
            'c' => "к",
            'd' => "д",
            'e' => "и",
            'f' => "ф",
            'g' => "дж",
            'h' => "х",
            'i' => "и",
            'j' => "дж",
            'k' => "к",
            'l' => "л",
            'm' => "м",
            'n' => "н",
            'o' => "о",
            'p' => "п",
            'q' => "кью",
            'r' => "р",
            's' => "с",
            't' => "т",
            'u' => "ю",
            'v' => "в",
            'w' => "уи",
            'x' => "х",
            'y' => "уай",
            'z' => "з",
            _ => letter.ToString()
        };

        public static string ConvertToTranslit(string message, Language language)
        {
            var lowerMessage = message.ToLower();
            var translitMessage = new StringBuilder();
            for (int counter = 0; counter < lowerMessage.Length; counter++)
            {
                var letter = GetTranslitLetter(lowerMessage[counter], language);
                translitMessage.Append(letter);
            }

            var result = translitMessage.ToString();
            return result.ToString();
        }

        private static string GetTranslitLetter(char letter, Language language) => language switch
        {
            Language.English => ToRussianTranslit(letter),
            Language.Russian => ToEnglishTranslit(letter),
            _ => throw new Exception()
        };
    }
}
