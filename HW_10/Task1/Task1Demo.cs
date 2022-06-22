using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10.Task1
{
    class Task1Demo
    {
        public static void Start()
        {
            try
            {
                WordDictionary dictionary = new(DictionaryReader.Read());
                TextTranslator translator = new(TextReader.Read(), dictionary);
                TextWriter.Write(translator.PerformTranslation());
            }
            catch (exceptions.DictionaryLineException)
            {
                if (DialogExceptionHandler.IncorrectLineHandler())
                {
                    Start();
                }
            }
            catch (exceptions.DictionaryWordDublicateException)
            {
                if (DialogExceptionHandler.WordDublicationHandler())
                {
                    Start();
                }
            }
            catch (exceptions.NoTranslationInDictionaryException e)
            {
                if (DialogExceptionHandler.NoTranslationHandler(e))
                {
                    Start();
                }
            }
        }
    }
}
