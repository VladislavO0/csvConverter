using System.Collections.Generic;
using System.Linq;

using System.Xml.Serialization;

namespace csvConvert.Model
{

    //для хранения данных связанных таблиц
    
    public class JoinData
    {
        [XmlArray("root")]
        private Dictionary<string, int> m_typeData = new Dictionary<string, int>()
            {
                {"bool", 1},
                {"int", 4},
                {"double", 8},
                {"double}", 8}
            };

        [XmlArray("root")]
        public List<Item> m_items;
        public class Item
        {
            [XmlAttribute("Binding")] public string binding = "Introduced";
            [XmlElement("node-path")] public string m_tag { get; set; }
            [XmlElement("address")] public int m_offset { get; set; }

        }
        public JoinData (string group, string type, List<string> tag, List<string> offset, string address)
        {
            m_items = new List<Item>();
           
            var isnumeric = int.TryParse(address,out int addr); //для организации смещения относительно адреса

            for (int i = 0; i < tag.Count(); ++i)
            {
                m_items.Add(new Item(){ m_tag = group + "." + tag[i], m_offset = addr });
                addr += m_typeData[offset[i]];               
            }
        }

        public JoinData() { } // для сериализации

    }
}
