using HW_10.Task1.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class WordDictionary
    {
        Dictionary<string, string> words;

        public WordDictionary() : this(new Dictionary<string, string>())
        {
        }

        public WordDictionary(Dictionary<string, string> words)
        {
            this.words = words;
        }

        public void AddWords(Dictionary<string, string> words)
        {
            this.words = words;
        }

        public string GetTranslationFor(string word)
        {
            if (word == "")
            {
                return "";
            }
            if (!words.ContainsKey(word))
            {
                throw new NoTranslationInDictionaryException($"{word}");
            }
            return words[word];
        }

    }
}
