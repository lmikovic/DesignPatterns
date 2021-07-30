using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Prototype
{
    class Program
    {
        /// <summary>
        /// The prototype design pattern is a design pattern that is used to instantiate a class by copying, or cloning, the properties of an existing object.
        /// The new object is an exact copy of the prototype but permits modification without altering the original.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var stormCommander = new Commander();
            var infantry = new Infantry();


            var stormCommander2 = stormCommander.Clone() as Commander;
            var infantry2 = infantry.Clone() as Infantry;


            if (stormCommander2 != null)
                Console.WriteLine("Firepower: {0}, Armor: {1}", stormCommander2.FirePower, stormCommander2.Armor);

            if (infantry2 != null)
                Console.WriteLine("Firepower: {0}, Armor: {1}", infantry2.FirePower, infantry2.Armor);
        }
    }

    public abstract class StormTrooper : ICloneable
    {
        public int FirePower { get; set; }
        public int Armor { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class Commander : StormTrooper
    {
        public Commander()
        {
            Armor = 15;
            FirePower = 20;
        }
    }

    public class Infantry : StormTrooper
    {
        public Infantry()
        {
            FirePower = 10;
            Armor = 9;
        }
    }

    //Instead of using Clone method (MemberwiseClone creates a shallow copy), we can use extension method
    public static class ExtensionMethods
    {
        //Requires classes to have [Serializable] annotation
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        //Requires classes to have parameterless constructor
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }

        public static T DeepCopyJson<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
