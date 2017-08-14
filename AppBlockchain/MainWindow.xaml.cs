using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppBlockchain
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        // Apagar informações nos campos texto
        Boolean apagarTxtLogin = true;
        Boolean apagarTxtSenha = true;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            // Carregar logotipo
            BitmapImage bitmapLogotipo = new BitmapImage();
            bitmapLogotipo.BeginInit();
            bitmapLogotipo.UriSource = new Uri("C:/Users/Willie/Documents/Visual Studio 2017/Projects/WpfAppApiTest/WpfAppApiTest/img/starlogo.png");
            bitmapLogotipo.EndInit();
            imgLogotipo.Source = bitmapLogotipo;

            // Carregar imagem de fundo
            BitmapImage bitmapFundo = new BitmapImage();
            bitmapFundo.BeginInit();
            bitmapFundo.UriSource = new Uri("C:/Users/Willie/Documents/Visual Studio 2017/Projects/WpfAppApiTest/WpfAppApiTest/img/fundo.png");
            bitmapFundo.EndInit();
            imgView.Source = bitmapFundo;
        }


        // Criar Conta
        private void labCriarConta_MouseEnter(object sender, MouseEventArgs e)
        {
            labCriarConta.FontWeight = FontWeights.Bold;
        }

        private void labCriarConta_MouseLeave(object sender, MouseEventArgs e)
        {
            labCriarConta.FontWeight = FontWeights.Normal;
        }

        private void labCriarConta_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Chamar rotina de cadastro
            Cadastro cadastro = new Cadastro();
            this.Hide();
            if (!(Boolean)cadastro.ShowDialog())
            {
                // Se nao realizar o cadastro
                // Retornar para tela de LOGIN
                this.Show();
            }
            else
            {
                // Se realizar o cadastro
                // Logar no sistema
            }
        }
        
        // Acessar
        private void labConfirmar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Acessar sistema
        }

        private void labConfirmar_MouseEnter(object sender, MouseEventArgs e)
        {
            labConfirmar.FontWeight = FontWeights.Bold;
        }

        private void labConfirmar_MouseLeave(object sender, MouseEventArgs e)
        {
            labConfirmar.FontWeight = FontWeights.Normal;
        }


        // Restaurar
        private void labEsqueci_MouseEnter(object sender, MouseEventArgs e)
        {
            labEsqueci.FontWeight = FontWeights.Bold;
            stackPanelEsqueci.Visibility = Visibility.Visible;
        }

        private void labEsqueci_MouseLeave(object sender, MouseEventArgs e)
        {
            labEsqueci.FontWeight = FontWeights.Normal;
            stackPanelEsqueci.Visibility = Visibility.Hidden;
        }

        // Painel Restaurar
        private void stackPanelEsqueci_MouseEnter(object sender, MouseEventArgs e)
        {
            stackPanelEsqueci.Visibility = Visibility.Visible;
        }

        private void stackPanelEsqueci_MouseLeave(object sender, MouseEventArgs e)
        {
            stackPanelEsqueci.Visibility = Visibility.Hidden;
        }

        // Esqueci Login
        private void labEsqueciLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            labEsqueciLogin.FontWeight = FontWeights.Bold;
        }

        private void labEsqueciLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            labEsqueciLogin.FontWeight = FontWeights.Normal;
        }

        // Esqueci Senha
        private void labEsqueciSenha_MouseEnter(object sender, MouseEventArgs e)
        {
            labEsqueciSenha.FontWeight = FontWeights.Bold;
        }

        private void labEsqueciSenha_MouseLeave(object sender, MouseEventArgs e)
        {
            labEsqueciSenha.FontWeight = FontWeights.Normal;
        }

        // Text Login
        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (apagarTxtLogin)
            {
                txtLogin.Text = null;
                apagarTxtLogin = false;
            }
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Equals(null) || txtLogin.Text.Equals(""))
            {
                txtLogin.Text = "Login";
            }
        }

        // Text Senha
        private void txtSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (apagarTxtSenha)
            {
                txtSenha.Password = null;
                apagarTxtSenha = false;
            }
        }

        private void txtSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSenha.Password.Equals(null) || txtSenha.Password.Equals(""))
            {
                txtSenha.Password = "xxxxx";
            }
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TODO ASDF
        }
    }

    

}
