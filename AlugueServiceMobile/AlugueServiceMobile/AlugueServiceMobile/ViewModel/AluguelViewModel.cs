using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AlugueServiceMobile.Model;

namespace AlugueServiceMobile.ViewModel
{
    class AluguelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Aluguel aluguel;
        public Aluguel Aluguel
        {
            get { return aluguel; }
            set
            {
                if (aluguel != value)
                {
                    aluguel = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Aluguel"));
                    }
                }
            }
        }

    }
}
