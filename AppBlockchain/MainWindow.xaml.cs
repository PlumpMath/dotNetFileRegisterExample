using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
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

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            txtLogin.Focus();
            txtLogin.Text     = login;
            txtSenha.Password = senha;
        }

        #region  Text Login
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

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtLogin.Text.Equals(login))
            {
                txtLogin.Text = null;
            }
            if (e.Key.Equals(Key.Enter))
            {
                txtSenha.Focus();
            }
        }
        #endregion

        #region Text Senha
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

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                Acessar();
            }
        }
        #endregion

        #region Acessar
        private void labConfirmar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Acessar();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            Acessar();
        }

        private void Acessar()
        {
            try
            {
                // validar login
                if (txtLogin.Text.Equals(login))
                {
                    MessageBox.Show("Login invalido!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (txtLogin.Text.Equals(null) || txtLogin.Text.Equals(""))
                {
                    MessageBox.Show("Preencha o campo Login", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    // validar senha
                    if (txtSenha.Password.Equals(senha))
                    {
                        MessageBox.Show("Senha inválida", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    else if (txtSenha.Password.Equals(null) || txtSenha.Password.Equals(""))
                    {
                        MessageBox.Show("Preencha o campo Senha", "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    else
                    {
                        // Verificar se existe usuario
                        if (usuarioCadastrado(txtLogin.Text))
                        {
                            // Verificar se a senha esta correta
                            if (senhaCorreta(txtSenha.Password))
                            {
                                // Logar
                                this.Hide();
                                Arquivo arquivo = new Arquivo(txtLogin.Text);
                                if (!(Boolean)arquivo.ShowDialog())
                                {
                                    // Se a rotina Arquivo for fechada
                                    Load(); // Reiniciar tela Login
                                    this.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Senha Incorreta", "Atencão", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário não cadastrado", "Atencão", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // TODO
            }
        }

        private bool usuarioCadastrado(string usuario)
        {
            // TODO
            if (usuario.Equals("usuario"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool senhaCorreta(string senha)
        {
            // TODO
            if (senha.Equals("123"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

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
                Load();
                this.Show();
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
