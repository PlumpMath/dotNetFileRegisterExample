using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AppBlockchain
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        string login = "Login";
        string senha = "Senha";
        string imgPath = "C:/Users/Willie/Documents/AStar/Projetos/dotNetFileRegisterExample/AppBlockchain/img/";

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
            bitmapLogotipo.UriSource = new Uri(imgPath + "starlogo.png");
            bitmapLogotipo.EndInit();
            imgLogotipo.Source = bitmapLogotipo;

            // Carregar imagem de fundo
            BitmapImage bitmapFundo = new BitmapImage();
            bitmapFundo.BeginInit();
            bitmapFundo.UriSource = new Uri(imgPath + "fundo.png");
            bitmapFundo.EndInit();
            imgView.Source = bitmapFundo;

            txtLogin.Text = login;
            txtSenha.Password = senha;
            labConfirmar.Focus();
        }

        // Text Login
        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Equals(login))
            {
                txtLogin.Text = null;
            }
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Equals(null) || txtLogin.Text.Equals(""))
            {
                txtLogin.Text = login;
            }
        }

        // Text Senha
        private void txtSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSenha.Password.Equals(senha))
            {
                txtSenha.Password = null;
            }
        }

        private void txtSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSenha.Password.Equals(null) || txtSenha.Password.Equals(""))
            {
                txtSenha.Password = senha;
            }
        }

        // Acessar
        private void labConfirmar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // validar login
                if (txtLogin.Text.Equals(login))
                {
                    MessageBox.Show("Login invalido!");
                }
                else if (txtLogin.Text.Equals(null) || txtLogin.Text.Equals(""))
                {
                    MessageBox.Show("Preencha o campo Login");
                }
                else
                {
                    // validar senha
                    if (txtSenha.Password.Equals(senha))
                    {
                        MessageBox.Show("Senha inválida");
                    }
                    else if (txtSenha.Password.Equals(null) || txtSenha.Password.Equals(""))
                    {
                        MessageBox.Show("Preencha o campo Senha");
                    }
                    else
                    {
                        // Logar
                        this.Hide();
                        Arquivo arquivo = new Arquivo();
                        if (!(Boolean)arquivo.ShowDialog())
                        {
                            // Se a rotina Arquivo for fechada
                            Load(); // Reiniciar tela Login
                            this.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO
            }
        }

        private void labConfirmar_MouseEnter(object sender, MouseEventArgs e)
        {
            labConfirmar.FontWeight = FontWeights.Bold;
        }

        private void labConfirmar_MouseLeave(object sender, MouseEventArgs e)
        {
            labConfirmar.FontWeight = FontWeights.Normal;
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
            this.Hide();
            Cadastro cadastro = new Cadastro();
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

    }

    

}
