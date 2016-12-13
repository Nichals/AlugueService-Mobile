using AlugueServiceMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class SelecionarProdutoView : ContentPage
    {
        public SelecionarProdutoView()
        {
            var layout = new StackLayout { Padding = 20 };
            this.BackgroundColor = Color.White;
            this.BindingContext = Global.preVendaViewModel;

            var labelTitulo = new Label { Text = "Selecione o produto", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center };
            var buttonQrCode = new Button { Text = "QR"};
            var searchPesquisa = new SearchBar { Placeholder = "Nome ou id", TextColor = Color.Black, CancelButtonColor = Color.Black, PlaceholderColor = Color.Silver };
            searchPesquisa.SearchButtonPressed += (s, e) =>
            {

                var filtro = searchPesquisa.Text;
                var id = new int();
                if (int.TryParse(filtro,out id))
                {
                    Global.preVendaViewModel.PesquisaProdutoId(id);
                }
                else
                {
                    Global.preVendaViewModel.PesquisaProdutoNome(filtro);
                }

                



            };


            #region ListView de clientes

            ListView listViewProduto = new ListView
            {

                ItemsSource = Global.preVendaViewModel.ListaCliente,
                SeparatorVisibility = SeparatorVisibility.Default,
                SeparatorColor = Color.Black,
                ItemTemplate = new DataTemplate(() =>
                {

                    #region Label
                    Label labelNome = new Label();
                    labelNome.TextColor = Color.Black;
                    labelNome.SetBinding(Label.TextProperty, "nome");

                   

                    Label labelValor = new Label();
                    labelValor.TextColor = Color.Black;
                    labelValor.SetBinding(Label.TextProperty, "valor");
                    #endregion

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Children =
                                {
                                    labelNome,labelValor
                                }
                        }
                    };
                })
            };

            listViewProduto.SetBinding(ListView.ItemsSourceProperty, "ListaProduto");
            listViewProduto.ItemSelected += ListViewProduto_ItemSelected;
            #endregion
            layout.Children.Add(labelTitulo);
            layout.Children.Add(searchPesquisa);
            layout.Children.Add(listViewProduto);
            Content = new ScrollView { Content = layout };
        }



        private async void ListViewProduto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {

                var produtoSelecionado = new Produto();
                produtoSelecionado = (e.SelectedItem as Produto);
                
                
                Global.preVendaViewModel.AdicionarProduto(produtoSelecionado);
                await Navigation.PopModalAsync();


            }
        }

    }
}

