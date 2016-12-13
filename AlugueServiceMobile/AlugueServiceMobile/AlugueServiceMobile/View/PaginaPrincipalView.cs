using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class PaginaPrincipalView : ContentPage
    {
        public PaginaPrincipalView()
        {
            BackgroundColor = Color.White;

            Command<Type> navigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await this.Navigation.PushAsync(page);
            });

            var buttonPreVenda = new Button { Text = "Pré-Venda", Command = navigateCommand, CommandParameter = typeof(PreVendaView) };
            var buttonProduto = new Button { Text = "Produto", Command = navigateCommand, CommandParameter = typeof(ProdutoView) };
            var logo = new Image { Source = ImageSource.FromFile("LogoAlugueService2.jpg"), HeightRequest = 300 };
            var labelTitulo = new Label { Text = "Menu", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };

            layout.Children.Add(logo);
            layout.Children.Add(labelTitulo);
            layout.Children.Add(buttonPreVenda);
            layout.Children.Add(buttonProduto);
            
            Content = new ScrollView { Content = layout };
        }


    }
}
