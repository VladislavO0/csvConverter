using csvConvert.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;


namespace csvConvert.Model
{
    //класс для считывания csv и json файлов и сохранения в xml
    class Read
    {
        public string m_csvPath { get; set; }
        public string m_jsonPath { get; set; }


        // Чтение данных из CSV файла
        public List<CSVData> readCSV()
        {
            var dataCSV = new List<CSVData>();
            DataTable dt = new DataTable();
            var fileExist = File.Exists(m_csvPath);
            if (!fileExist) //если файл не существует создаем его, иначе будет исключение
            {
                File.CreateText(m_jsonPath).Dispose();
                return new List<CSVData>();
            }
            using (StreamReader st = new StreamReader(m_csvPath))
            {

                st.ReadLine().Split(';');
                while (!st.EndOfStream)
                {
                    string[] csvArr;
                    csvArr = st.ReadLine().Split(';');

                    var dat = new CSVData { M_tag = csvArr[0], M_type = csvArr[1], M_address = csvArr[2] };
                    dataCSV.Add(dat);
                }
            }
            return dataCSV;
        }

        // Чтение данных из Json файла
        public List<TypeInfo> readJson()
        {
            var JD = new JsonData();
            var fileExist = File.Exists(m_jsonPath);
            if (!fileExist) //если файл не существует создаем его, иначе будет исключение
            {
                return new List<TypeInfo>();
            }
            try
            {
                using (FileStream jsonString = new FileStream(m_jsonPath, FileMode.Open))
                {
                    JD = JsonSerializer.Deserialize<JsonData>(jsonString);
                    return JD.TypeInfos;
                }
            }
            catch (Exception ex)
            {
                Console.Write("The file could not be read : ");
                Console.WriteLine(ex.Message);
                return new List<TypeInfo>();
            }
        }
      
    }
}
