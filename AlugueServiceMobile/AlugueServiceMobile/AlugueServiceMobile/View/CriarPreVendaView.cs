using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AlugueServiceMobile.Model;
using AlugueServiceMobile.DAL;
using AlugueServiceMobile.DTO;

namespace AlugueServiceMobile.View
{
    class CriarPreVendaView : ContentPage
    {

        public CriarPreVendaView()
        {



            var layout = new StackLayout { Padding = 20 };
            this.BackgroundColor = Color.White;
            this.BindingContext = Global.preVendaViewModel;



            #region Operador

            var labelOperador = new Label { TextColor = Color.Black, Text = "Operador", HorizontalTextAlignment = TextAlignment.Center };
            var labelOperadorNome = new Label { TextColor = Color.Black, Text = "Nome" };
            var labelNomeOperador = new Label { TextColor = Color.Black };
            labelNomeOperador.SetBinding(Label.TextProperty, "Operador.nome");

            #endregion

            #region Cliente

            var labelCliente = new Label { TextColor = Color.Black, Text = "Cliente", HorizontalTextAlignment = TextAlignment.Center };
            var labelClienteNome = new Label { TextColor = Color.Black, Text = "Nome: " };
            var labelNomeCliente = new Label { TextColor = Color.Black };
            labelNomeCliente.SetBinding(Label.TextProperty, "Cliente.nome");
            var buttonCliente = new Button { Text = "Cliente", IsVisible = true };
            buttonCliente.Clicked += async (s, e) => { await Navigation.PushModalAsync(new SelecionarClienteView()); };

            #endregion

            #region Produto

            var labelProduto = new Label { TextColor = Color.Black, Text = "Produto", HorizontalTextAlignment = TextAlignment.Center };
            var buttonAdicionarProduto = new Button { Text = "+" };
            buttonAdicionarProduto.Clicked += async (s, e) => { Global.preVendaViewModel.ListaProduto = new List<Produto>(); await Navigation.PushModalAsync(new SelecionarProdutoView()); };
            var buttonRemoverProduto = new Button { Text = "-" };
            
            var layoutProduto = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { buttonAdicionarProduto, buttonRemoverProduto }
            };



            #region ListViewProduto

            ListView ListViewProduto = new ListView
            {
                ItemsSource = Global.preVendaViewModel.ListaProdutoSelecionado,
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
            
            var scrollViewListViewProduto = new ScrollView { Content = ListViewProduto };
            #endregion

            buttonRemoverProduto.Clicked += (s, e) => { ProdutoDAL.alterarStatusProduto((ListViewProduto.SelectedItem as Produto), 1); Global.preVendaViewModel.RemoverProduto((ListViewProduto.SelectedItem as Produto)); };
            ListViewProduto.SetBinding(ListView.ItemsSourceProperty, "ListaProdutoSelecionado");

            #endregion

            #region DataPrevista

            var labelDataPrevista = new Label { Text = "Data Prevista", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center };
            var datepickerDataPrevista = new DatePicker { Format = "D", MaximumDate = DateTime.Now.AddDays((double)8), MinimumDate = DateTime.Now.AddDays((double)1), BackgroundColor = Color.Black };
            datepickerDataPrevista.SetBinding(DatePicker.DateProperty, "DataPrevista");
            #endregion


            var buttonSalvar = new Button { Text = "Salvar" };
            buttonSalvar.Clicked +=(s,e) =>{
                PreAluguelDTO tDto = Global.preVendaViewModel.Salvar();
                if (tDto.ok)
                {
                    Navigation.PopModalAsync();
                    this.DisplayAlert("Pré-Aluguel", "Cadastrado com sucesso, numero do pré-aluguel: "+tDto.preAluguel.idPreAluguel+".", "Ok");
                }
            };

            layout.Children.Add(labelOperador);
            layout.Children.Add(labelOperadorNome);
            layout.Children.Add(labelNomeOperador);
            layout.Children.Add(labelCliente);
            layout.Children.Add(labelClienteNome);
            layout.Children.Add(labelNomeCliente);
            layout.Children.Add(buttonCliente);
            layout.Children.Add(labelProduto);
            layout.Children.Add(scrollViewListViewProduto);
            layout.Children.Add(layoutProduto);
            layout.Children.Add(labelDataPrevista);
            layout.Children.Add(datepickerDataPrevista);
            layout.Children.Add(buttonSalvar);



            Content = new ScrollView { Content = layout };


        }


    }
}

