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
using System.Windows.Shapes;

namespace AppBlockchain
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        string imgPath = "C:/Users/Willie/Documents/AStar/Projetos/dotNetFileRegisterExample/AppBlockchain/img/";

        public Cadastro()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            // Carregar logotipo
            BitmapImage bitmapLogotipo = new BitmapImage();
            bitmapLogotipo.BeginInit();
            bitmapLogotipo.UriSource = new Uri(imgPath + "starlogo.png");
            bitmapLogotipo.EndInit();
            imgLogotipo.Source = bitmapLogotipo;

            // Carregar imagem de fundo
            BitmapImage bitmapFundo = new BitmapImage();
            bitmapFundo.BeginInit();
            bitmapFundo.UriSource = new Uri(imgPath + "fundo.png");
            bitmapFundo.EndInit();
            imgFundo.Source = bitmapFundo;

            //labSenha.Visibility = Visibility.Visible;
        }

        // Nome
        private void txtNome_GotFocus(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            if(nome.Equals("Nome Completo"))
            {
                txtNome.Text = null;
            }
        }

        private void txtNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text.Equals("") || txtNome.Text.Equals(null))
            {
                txtNome.Text = "Nome Completo";
            }
        }

        // Usuario
        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Equals("Usuário"))
            {
                txtUsuario.Text = null;
            }
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtUsuario.Text.Equals("") || txtUsuario.Text.Equals(null))
            {
                txtUsuario.Text = "Usuário";
            }
        }

        // E-mail
        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Equals("E-Mail"))
            {
                txtEmail.Text = null;
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Equals("") || txtEmail.Text.Equals(null))
            {
                txtEmail.Text = "E-Mail";
            }
        }

        // Senha
        private void labSenha_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labSenha.Visibility = Visibility.Hidden;
            pwbSenha.Focus();
        }

        private void pwbSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            labSenha.Visibility = Visibility.Hidden;
        }

        private void pwbSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwbSenha.Password.Equals("") || pwbSenha.Password.Equals(null))
            {
                labSenha.Visibility = Visibility.Visible;
            }
        }

        // Confirmar Senha
        private void labConfirmSenha_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labConfirmSenha.Visibility = Visibility.Hidden;
            pwbConfirmSenha.Focus();
        }

        private void pwbConfirmSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            labConfirmSenha.Visibility = Visibility.Hidden;
        }

        private void pwbConfirmSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if(pwbConfirmSenha.Password.Equals("") || pwbConfirmSenha.Password.Equals(null))
            {
                labConfirmSenha.Visibility = Visibility.Visible;
            }
        }

        // Botao Criar Conta
        private void btnCriarConta_Click(object sender, RoutedEventArgs e)
        {
            // Todo
            this.Close();
            Arquivo arquivo = new Arquivo();
            arquivo.ShowDialog();
        }
    }
}
