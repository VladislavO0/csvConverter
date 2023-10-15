using csvConvert.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace csvConvert.Model
{
    internal class JoinTables
    {
        public List<CSVData> m_csvData { get; set; }
        public List<TypeInfo> m_jsonData { get; set; }
        public bool m_chosenBinding { get; set; } = false;

        public BindingList<JoinData> join()
        {

            List<JoinData> joinTable;
            if (!m_chosenBinding)
            {
                joinTable = (List<JoinData>)(from csv in m_csvData
                                             join json in m_jsonData
                                             on csv.M_type equals json.TypeName
                                             select new JoinData(
                                                 csv.M_tag,
                                                 csv.M_type,
                                                 json.kkey,
                                                 json.vval,
                                                 csv.M_address
                                             )).ToList();
                return new BindingList<JoinData>(joinTable);
            }
            joinTable = (List<JoinData>)(from csv in m_csvData
                                         join json in m_jsonData
                                         on csv.M_type equals json.TypeName
                                         where csv.m_binding == true
                                         select new JoinData(
                                             csv.M_tag,
                                             csv.M_type,
                                             json.kkey,
                                             json.vval,
                                             csv.M_address
                                         )).ToList();
            return new BindingList<JoinData>(joinTable);
        }
        
    }
}
