using HW_14.Task2.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HW_14.Task2.serialisation
{
    internal static class StorageSerialisation
    {
        #region JSON
        public static bool JsonSerialisation(Storage storage)
        {
            try
            {
                using (StreamWriter writer = File.CreateText("JSONserialise.json"))
                {
                    string json = JsonSerializer.Serialize(storage);
                    writer.Write(json);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static Storage JsonDeserialisation(string path = "JSONserialise.json")
        {
            try
            {
                string json;
                using (StreamReader reader = new(path))
                {
                    json = reader.ReadToEnd();
                }
                return JsonSerializer.Deserialize<Storage>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region XML
        public static bool XMLSerialisation(Storage storage)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Storage));
                FileStream file = File.Create("XMLserialise.xml");
                xmlSerializer.Serialize(file, storage);
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static Storage XMLDeserialisation(string path = "XMLserialise.xml")
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Storage));
                Storage? storage;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    storage = xmlSerializer.Deserialize(fs) as Storage;
                }
                return storage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region Binnary
        public static bool BinnarySerialisation(Storage storage)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("BINNARYserialise.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, storage);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public static Storage BinnaryDeserialisation(string path = "BINNARYserialise.bin")
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                Storage storage = (Storage)formatter.Deserialize(stream);
                stream.Close();
                return storage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

    }
}
