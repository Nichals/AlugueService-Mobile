using AlugueServiceMobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class PreVendaView : ContentPage
    {
        public PreVendaView()
        {
            BackgroundColor = Color.White;
            Command<Type> navigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await this.Navigation.PushAsync(page);
            });

            var labelTitulo = new Label { Text = "Pré-Venda", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var buttonCriarPreVenda = new Button { Text = "Criar Pré-venda" };
            buttonCriarPreVenda.Clicked += ButtonCriarPreVenda_Clicked;
            var buttonConsultarPreVenda = new Button { Text = "Consultar", Command = navigateCommand, CommandParameter = typeof(ConsultarPreAluguelView) };
            var logo = new Image { Source = ImageSource.FromFile("LogoAlugueService2.jpg") };

            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };
            layout.Children.Add(logo);
            layout.Children.Add(labelTitulo);
            layout.Children.Add(buttonCriarPreVenda);
            layout.Children.Add(buttonConsultarPreVenda);

            Content = new ScrollView { Content = layout };
        }

        private async void ButtonCriarPreVenda_Clicked(object sender, EventArgs e)
        {
            Global.preVendaViewModel = new PreVendaViewModel();
            
            await Navigation.PushModalAsync(new CriarPreVendaView());
        }
    }
}
