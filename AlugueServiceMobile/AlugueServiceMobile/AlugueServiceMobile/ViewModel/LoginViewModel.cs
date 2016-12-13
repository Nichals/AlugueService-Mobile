using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AlugueServiceMobile.View;
using System.ComponentModel;
using AlugueServiceMobile.Model;
using PropertyChanged;
using AlugueServiceMobile.DAL;
using AlugueServiceMobile.DTO;

namespace AlugueServiceMobile.ViewModel
{
    [ImplementPropertyChanged]
    class LoginViewModel : INotifyPropertyChanged
    {

        Operador operador;


        public LoginViewModel()
        {
            this.operador = new Operador();
        }

        public Operador Operador
        {
            get { return operador; }
            set
            {
                if (operador != value)
                {
                    Operador = value;


                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OperadorDTO Entrar(Operador pOperador)
        {
            var tDto = OperadorDAL.autenticar(pOperador);
            if (tDto.ok)
            {
                Global.operador = tDto.operador;

                return tDto;
                //                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new PaginaPrincipalView()));
            }
            else { return tDto; }
        }


    }
}
