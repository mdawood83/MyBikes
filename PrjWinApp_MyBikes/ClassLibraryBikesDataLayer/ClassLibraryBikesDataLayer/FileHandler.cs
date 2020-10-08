using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

using ClassLibraryBikesBusLayer;


namespace ClassLibraryBikesDataLayer
{
    public class FileHandler
    {
        public static String binFilePath = @"..\..\data\bike.ser";
        public static String xmlFilePath = @"..\..\data\myBike.xml";

        //***************** BINARY FILE ***************//
        //public static void WriteToBinaryFile(List<Bike> list)
        //{
        //    FileStream fs = new FileStream(binFilePath, FileMode.OpenOrCreate, FileAccess.Write);
        //    BinaryFormatter bf = new BinaryFormatter();

        //    bf.Serialize(fs, list);

        //    fs.Close();
        //}
        //public static List<Bike> ReadFromBinary()
        //{
        //    List<Bike> list = new List<Bike>();
        //    if (File.Exists(binFilePath))
        //    {
        //        FileStream fs = new FileStream(binFilePath, FileMode.Open, FileAccess.Read);
        //        BinaryFormatter bf = new BinaryFormatter();

        //        list = (List<Bike>)bf.Deserialize(fs);

        //        fs.Close();
        //    }
        //    return list;
        //}

        //*********************** XML FILE ********************//
        public static void WriteToXmlFile(List<Bike> list)
        {
            XmlWriter writer = XmlWriter.Create(xmlFilePath);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Bike>));

            serializer.Serialize(writer, list);
            writer.Close();
        }

        public static List<Bike> ReadFromXmlFile()
        {
            List<Bike> list;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Bike>));

            StreamReader reader = new StreamReader(xmlFilePath);

            list = (List<Bike>)xmlSerializer.Deserialize(reader);
            
            reader.Close();
            return list;
        }
    }
}
