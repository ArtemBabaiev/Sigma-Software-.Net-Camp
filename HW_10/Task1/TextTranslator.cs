using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class TextTranslator
    {
        string text;
        WordDictionary dictionary;

        public TextTranslator(string text, WordDictionary dictionary)
        {
            this.text = text;
            this.dictionary = dictionary;
        }

        public string PerformTranslation()
        {
            //масив слів, за допомогою яких відбуватимется пошук у словнику і обмін
            string[] wordsForSearch = StringManipulator.TransformAllToLower(StringManipulator.SplitTextBy(text, " "));

            for (int i = 0; i < wordsForSearch.Length; i++)
            {
                //обираємо саме слово без розділових знаків
                string word = Regex.Match(wordsForSearch[i], @"([A-Za-zА-Яа-яІіЇї])+").Value;
                try
                {
                    //метод GetTranslationFor ігнорує порожні стрічки
                    string translation = dictionary.GetTranslationFor(word);
                    wordsForSearch[i] = Regex.Replace(wordsForSearch[i], word, translation);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return String.Join(' ', CorrectRegistries(StringManipulator.SplitTextBy(text), wordsForSearch));
        }

        //метод передбачає чергування регістрів у слові
        private string[] CorrectRegistries(string[] original, string[] translated)
        {
            
            for (int i = 0; i < translated.Length; i++)
            {
                if (translated[i] == "")
                {
                    continue;
                }
                int smallerSize;
                StringBuilder stringBuilder = new(translated[i]);
                if (translated[i].Length > original[i].Length)
                {
                    smallerSize = original[i].Length;
                }
                else
                {
                    smallerSize = translated[i].Length;
                }
                for (int j = 0; j < smallerSize; j++)
                {
                    if (char.IsUpper(original[i][j]))
                    {
                        stringBuilder[j] = char.ToUpper(translated[i][j]);
                    }
                    else
                    {
                        stringBuilder[j] = char.ToLower(translated[i][j]);
                    }
                }
                translated[i] = stringBuilder.ToString();
            }
            return translated;
        }

    }
}
