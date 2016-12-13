using AlugueServiceMobile.Model;
using AlugueServiceMobile.ViewModel;
using Xamarin.Forms;

namespace AlugueServiceMobile.View
{
    class LoginView : ContentPage
    {
        

        public LoginView()
        {

            LoginViewModel loginViewModel = new LoginViewModel();

            this.BindingContext = loginViewModel;
            this.BackgroundColor = Color.White;
            var labelUsuario = new Label
            {
                Text = "Usuário",
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black
            };
            var labelSenha = new Label
            {
                Text = "Senha",
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black
            };

            var entryUsuario = new Entry
            {
                Placeholder = "Insira o usuário.",
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text,
                TextColor = Color.Black,
                
            };
            entryUsuario.SetBinding(Entry.TextProperty, "Operador.login");
           
            var entrySenha = new Entry
            {
                Placeholder = "Insira a senha.",
                VerticalOptions = LayoutOptions.Center,
                Keyboard = Keyboard.Text,
                IsPassword = true,
                TextColor = Color.Black
            };
            entrySenha.SetBinding(Entry.TextProperty, "Operador.senha");
            var logo = new Image
            {
                Source = ImageSource.FromFile("LogoAlugueService2.jpg")
            };
            var buttonEntrar = new Button
            {
                Text = "Entrar",
            };

            buttonEntrar.Clicked += (sender, e) =>
            {
                if(entryUsuario.Text != null && entrySenha.Text != null)
                {
                    Operador operador = new Operador(entryUsuario.Text.Trim(), entrySenha.Text.Trim());

                    var tDto = loginViewModel.Entrar(operador);
                    if (tDto.ok)
                    {
                        Navigation.PushAsync(new PaginaPrincipalView());
                    }
                    else
                    {
                        this.DisplayAlert("Erro ao entrar.", tDto.mensagem, "Ok");
                    }
                }
                else
                {
                    this.DisplayAlert("Erro ao entrar.", "Favor preencher todos os campos.", "Ok");
                }

                

            };
            
            var layout = new StackLayout { Padding = 20 };
            layout.Children.Add(logo);
            layout.Children.Add(labelUsuario);
            layout.Children.Add(entryUsuario);
            layout.Children.Add(labelSenha);
            layout.Children.Add(entrySenha);
            layout.Children.Add(buttonEntrar);
            Content = new ScrollView { Content = layout };


        }
    }
}
