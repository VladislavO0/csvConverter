using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvConvert.ViewModel
{
    //базовый класс для оповещения вьюмодели об изменении ее свойств, чтобы не дублироваться в будущем
    internal class BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));// оператор ? для проверки на null
        }
    }
}
