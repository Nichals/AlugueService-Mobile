using AlugueServiceMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class ResultadoConsultaPreAluguelView : ContentPage
    {
        public ResultadoConsultaPreAluguelView(PreAluguel pPreAluguel)
        {
            BackgroundColor = Color.White;
            var layout = new StackLayout { VerticalOptions = LayoutOptions.Center, Padding = 20 };
           
            var labelIdProduto = new Label { Text = "ID do pré-aluguel: " + pPreAluguel.idPreAluguel, TextColor = Color.Black };
            var labelNomeProduto = new Label { Text = "Nome do cliente: " + pPreAluguel.cliente.nome, TextColor = Color.Black };
            var labelValorProduto = new Label { Text = "Valor do pré-aluguel: " + pPreAluguel.valorAluguel, TextColor = Color.Black };
            
            layout.Children.Add(labelIdProduto);
            layout.Children.Add(labelNomeProduto);
            Content = new ScrollView { Content = layout };
        }
    }
}
