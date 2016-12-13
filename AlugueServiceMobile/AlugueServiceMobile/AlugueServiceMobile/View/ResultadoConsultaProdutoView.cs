using AlugueServiceMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class ResultadoConsultaProdutoView : ContentPage
    {
        public ResultadoConsultaProdutoView(Produto pProduto)
        {
            BackgroundColor = Color.White;
            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };
            var imageProduto = new Image { Source = pProduto.diretorioImagem,HeightRequest = 250, WidthRequest = 250 };
            if (pProduto.diretorioImagem != null)
            {
                imageProduto.Source = pProduto.diretorioImagem;
                
            }
            else
            {
                imageProduto.Source = "icon.png";

            }
            var labelIdProduto = new Label { Text = "ID do produto: " + pProduto.idProduto , TextColor = Color.Black};
            var labelNomeProduto = new Label { Text = "Nome do produto: " + pProduto.nome, TextColor = Color.Black };
            var labelValorProduto = new Label { Text = "Valor do produto: " + pProduto.valor, TextColor = Color.Black };
            layout.Children.Add(imageProduto);
            layout.Children.Add(labelIdProduto);
            layout.Children.Add(labelNomeProduto);
            Content = new ScrollView { Content = layout };
        }
       
    }

}

