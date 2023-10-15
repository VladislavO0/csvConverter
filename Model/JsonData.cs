using System.Collections.Generic;

namespace csvConvert.Model
{
    public class JsonData
    {
        public List<TypeInfo> TypeInfos { get; set; }
    }
    public class TypeInfo
    {
        public string TypeName { get; set; }
        public Dictionary<string, string> Propertys { get; set; }
        public class Proper
        { 
            public string key { get; set; }
            public string value { get; set; }
        }
        public List<string> kkey {get; set;}
        public List<string> vval { get; set; }

        public TypeInfo(string typeName, Dictionary<string, string> Propertys)
        {
            TypeName = typeName;
            kkey = new List<string>();
            vval = new List<string>();
            foreach (var dict in Propertys)
            {
                kkey.Add(dict.Key);
                vval.Add(dict.Value);
            }
        }
    }
}
