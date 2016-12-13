using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class ProdutoView : ContentPage
    {
        public ProdutoView()
        {
            BackgroundColor = Color.White;
            Command<Type> navigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await this.Navigation.PushAsync(page);
            });
            
            var buttonConsultarProduto = new Button { Text = "Consultar",Command = navigateCommand, CommandParameter = typeof(ConsultaProdutoView) };
            var buttonAlterarStatus = new Button { Text = "Alterar Status", Command = navigateCommand, CommandParameter = typeof(AlterarStatusProdutoView) };
            var labelTitulo = new Label { Text = "Produto", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
            var logo = new Image { Source = ImageSource.FromFile("LogoAlugueService2.jpg") };
            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };
            layout.Children.Add(logo);
            layout.Children.Add(labelTitulo);
            layout.Children.Add(buttonConsultarProduto);
            layout.Children.Add(buttonAlterarStatus);
            Content = new ScrollView { Content = layout };
        }
    }
}
