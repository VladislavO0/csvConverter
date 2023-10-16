using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace csvConvert.Model
{ 
    internal class ConvertToXML
    {
        public bool AllXml {get; set;} = true;
        public string m_xmlPath { get; set; }
        public BindingList<JoinData> m_joinTable { get; set; }

        class Item
        {
            public string tag { get; set; }
            public string ofset { get; set; }
        }

        public void Serialize()
        {
            if (System.IO.Path.GetExtension(m_xmlPath) == ".xml")
            {
                //Сериализация объектов
                XmlSerializer xml = new XmlSerializer(typeof(BindingList<JoinData>));
                FileInfo fileInfo = new FileInfo(m_xmlPath);

                if (fileInfo.Exists)
                {// если файл существует - удалить
                    File.Delete(m_xmlPath);
                }
                using (FileStream fs = new FileStream(m_xmlPath, FileMode.OpenOrCreate))
                {
                     xml.Serialize(fs, m_joinTable);

                    Console.WriteLine("Object has been serialized");

                }
            }

        }
    }
}
