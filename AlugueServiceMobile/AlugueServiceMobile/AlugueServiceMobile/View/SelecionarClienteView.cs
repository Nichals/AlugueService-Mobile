using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AlugueServiceMobile.Model;
using AlugueServiceMobile.ViewModel;

namespace AlugueServiceMobile.View
{
    class SelecionarClienteView : ContentPage
    {

        public SelecionarClienteView()
        {
            var layout = new StackLayout { Padding = 20 };
            this.BackgroundColor = Color.White;
            this.BindingContext = Global.preVendaViewModel;

            var labelTitulo = new Label { Text = "Selecione o cliente", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center };

            #region SearchBar Nome
            var nomeSearch = new SearchBar { Placeholder = "Nome", TextColor = Color.Black, CancelButtonColor = Color.Black, PlaceholderColor = Color.Silver };
            nomeSearch.SearchButtonPressed += (s, e) =>
            {

                var filtro = nomeSearch.Text;

                Global.preVendaViewModel.PesquisaCliente(filtro);



            }; 
            #endregion

            #region ListView de clientes

            ListView listView = new ListView
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

                    Label labelCpf = new Label();
                    labelCpf.TextColor = Color.Black;
                    labelCpf.SetBinding(Label.TextProperty, "cpf");
                    #endregion

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Vertical,
                            Children =
                                {
                                    labelNome,labelCpf
                                }
                        }
                    };
                })
            }; 
            
            listView.SetBinding(ListView.ItemsSourceProperty, "ListaCliente");
            listView.ItemSelected += ListView_ItemSelected;
            #endregion

            layout.Children.Add(nomeSearch);
            layout.Children.Add(listView);
            Content = new ScrollView { Content = layout };
        }



        private async void  ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                Global.preVendaViewModel.Cliente = (e.SelectedItem as Cliente);
                await Navigation.PopModalAsync();
            }
        }
    }
}
