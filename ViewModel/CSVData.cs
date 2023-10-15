
namespace csvConvert.ViewModel
{

    internal class CSVData : BaseViewModel
    {
        public bool m_binding { get; set; } = false;
        private string m_tag;
        public string M_tag
        {
            get { return m_tag; }
            set
            {
                if (m_tag == value) { return; }
                m_tag = value; OnPropertyChanged(nameof(M_tag));
            }
        }

        private string m_type;
        public string M_type
        {
            get { return m_type; }
            set
            {
                if (m_type == value) { return; }
                m_type = value; OnPropertyChanged(nameof(M_type));
            }
        }
        private string m_address;     
        public string M_address
        {
            get { return m_address; }
            set
            {
                if (m_address == value) 
                { 
                    var isnumeric = int.TryParse(value, out int address);
                    m_address = address.ToString(); 
                }
                else
                { 
                    var isnumeric = int.TryParse(value, out int address);
                    m_address = address.ToString();
                }; 
                OnPropertyChanged(nameof(M_address));
            }
        }                    
    }
}
