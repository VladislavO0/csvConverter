using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using csvConvert.Model;
using System.ComponentModel;
using csvConvert.ViewModel;



namespace csvConvert
{
    public partial class MainWindow : Window
    {
        private List<CSVData> m_csvData;
        private List<TypeInfo> m_jsonData;
        private BindingList<JoinData> m_Join;

        private string m_csvPath;
        private string m_jsonPath;
        private string m_path;
        private string m_xmlPath;
        private Read m_read;
        private JoinTables m_JoinTables;
        private ConvertToXML m_convert;

        
        public MainWindow()
        {
            InitializeComponent();
            int address = Address.addr;
        }
        
        class Address
        {
            public static int addr;

        }

        private void Click_CsvRead_(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choise csv File | *.csv";
            ofd.ShowDialog();
            m_csvPath = ofd.FileName;
            m_path = System.IO.Path.GetDirectoryName(m_csvPath);

            m_read = new Read() { m_csvPath = m_csvPath };
            try
            {
                m_csvData = m_read.readCSV();
                dgCSV.ItemsSource = m_csvData; // cвязь datagrid c колекцией
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            //получение пути к json файлу
            m_jsonPath = m_path + "\\TypeInfos.json";
            if (System.IO.File.Exists(m_jsonPath))
            {
                m_read.m_jsonPath = m_jsonPath;
                m_jsonData = m_read.readJson();
                if (m_jsonData == null || m_jsonData.Count() == 0) 
                { 
                    JSONRead.Visibility = Visibility.Visible; 
                }
                else
                {                   
                    m_JoinTables = new JoinTables() { m_csvData = m_csvData, m_jsonData = m_jsonData };
                    m_Join = m_JoinTables.join();
                    m_xmlPath = m_path + "\\AllBinding.xml";
                    m_convert = new ConvertToXML() { m_xmlPath = m_xmlPath, m_joinTable = m_Join };
                    m_convert.Serialize();
                    ConvertCSV.Visibility = Visibility.Visible;
                }
            }
            else //если json файл не лежит в папке с csv, открываем вручную
            {
                JSONRead.Visibility = Visibility.Visible;
            }
        }

        private void Click_JsonRead(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choise JSON File | *.json";
            ofd.ShowDialog();

            m_jsonPath = ofd.FileName;
            if (System.IO.File.Exists(m_jsonPath))
            {
                m_read.m_jsonPath = m_jsonPath;
                m_jsonData = m_read.readJson();
                if (m_jsonData.Count == 0)
                {
                    JSONRead.Visibility = Visibility.Visible;
                }
                else
                {
                    m_JoinTables = new JoinTables() { m_csvData = m_csvData, m_jsonData = m_jsonData };
                    m_Join = m_JoinTables.join();
                    m_xmlPath = m_path + "\\AllBinding.xml";
                    m_convert = new ConvertToXML() { m_xmlPath = m_xmlPath, m_joinTable = m_Join };
                    m_convert.Serialize();
                    ConvertCSV.Visibility = Visibility.Visible;
               }
            }
            else //если json файл не лежит в папке с csv, открываем вручную
            {
                JSONRead.Visibility = Visibility.Visible;
            }

            if (m_jsonData != null) { JSONRead.Visibility = Visibility.Hidden; }
        }     
        private void ConvertToXml_Click(object sender, RoutedEventArgs e)
        {
            m_JoinTables = new JoinTables() { m_csvData = m_csvData, m_jsonData = m_jsonData, m_chosenBinding = true};
            m_Join = m_JoinTables.join();
            m_xmlPath = m_path + "\\ChosenBinding.xml";
            m_convert = new ConvertToXML() { m_xmlPath = m_xmlPath, m_joinTable = m_Join};
            m_convert.Serialize();
        }

    }
}
