using AlugueServiceMobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class ConsultarPreAluguelView : ContentPage
    {
        public ConsultarPreAluguelView()
        {
            BackgroundColor = Color.White;

            ConsultaPreAluguelViewModel consultaPreVendaViewModel = new ConsultaPreAluguelViewModel();


            
            Command<Type> navigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await this.Navigation.PushAsync(page);
            });


            var entryIdProduto = new Entry { Placeholder = "Código do produto", Keyboard = Keyboard.Numeric, TextColor = Color.Black };
            entryIdProduto.TextChanged += OnTextChanged;
            var buttonQr = new Button { Text = "QR" };
            var buttonPesquisar = new Button { Text = "Pesquisar" };
            buttonPesquisar.Clicked += async (s, e) =>
            {
                var pagina = new ResultadoConsultaPreAluguelView(consultaPreVendaViewModel.ConsultarPreAluguel((int)Convert.ToInt64(entryIdProduto.Text)));
                await Navigation.PushAsync(pagina);
            };
            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };
            layout.Children.Add(entryIdProduto);
            layout.Children.Add(buttonQr);
            layout.Children.Add(buttonPesquisar);
            Content = new ScrollView { Content = layout };
            buttonQr.Clicked += async (s, e) =>
            {


            };
        }

        private void OnTextChanged(object sender, EventArgs args)
        {
            int restricCount = 6;
            Entry entryIdProduto = sender as Entry;
            string val = entryIdProduto.Text;

            if (val.Length > restricCount)
            {
                val = val.Remove(val.Length - 1);
                entryIdProduto.Text = val;
            }

        }

    }
}
 
