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
        string nome           = "Nome Completo";
        string usuario        = "Usuário";
        string email          = "E-Mail";
        string senha          = null;
        string confirmarSenha = null;

        public Cadastro()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            txtNome.Text             = nome;
            txtUsuario.Text          = usuario;
            txtEmail.Text            = email;
            pwbSenha.Password        = senha;
            pwbConfirmSenha.Password = confirmarSenha;

        }

        // Nome
        private void txtNome_GotFocus(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text;
            if(nome.Equals(nome))
            {
                txtNome.Text = null;
            }
        }

        private void txtNome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text.Equals("") || txtNome.Text.Equals(null))
            {
                txtNome.Text = nome;
            }
        }

        // Usuario
        private void txtUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtUsuario.Text.Equals(usuario))
            {
                txtUsuario.Text = null;
            }
        }

        private void txtUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtUsuario.Text.Equals("") || txtUsuario.Text.Equals(null))
            {
                txtUsuario.Text = usuario;
            }
        }

        // E-mail
        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Equals(email))
            {
                txtEmail.Text = null;
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if(txtEmail.Text.Equals("") || txtEmail.Text.Equals(null))
            {
                txtEmail.Text = email;
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
            if (validarCampos())
            {
                // Fechar tela de cadastro e Logar
                // Obs. Tela login ainda executando em segundo plano

                this.Close();
                Arquivo arquivo = new Arquivo(txtUsuario.Text);
                arquivo.ShowDialog();
            }
        }

        private Boolean validarCampos()
        {
            try
            {
                // Nome
                if (txtNome.Text.Equals(nome))
                {
                    MessageBox.Show("Nome inválido");
                }
                else if (txtNome.Text.Equals(null) || txtNome.Text.Equals(null))
                {
                    MessageBox.Show("Preencha o campo Nome");
                }
                else
                {
                    // Usuario
                    if (txtUsuario.Text.Equals(usuario))
                    {
                        MessageBox.Show("Usuário inválido");
                    }
                    else if (txtUsuario.Text.Equals(null) || txtUsuario.Text.Equals(null))
                    {
                        MessageBox.Show("Preencha o campo Usuário");
                    }
                    else
                    {
                        // E-Mail
                        if (txtEmail.Text.Equals(email))
                        {
                            MessageBox.Show("E-Mail inválido");
                        }
                        else if (txtEmail.Text.Equals(null) || txtEmail.Text.Equals(""))
                        {
                            MessageBox.Show("Preencha o campo E-Mail");
                        }
                        else
                        {
                            // Senha
                            if (pwbSenha.Password.Equals(senha))
                            {
                                MessageBox.Show("Senha inválida");
                            }
                            else if (pwbSenha.Password.Equals(null) || pwbSenha.Password.Equals(""))
                            {
                                MessageBox.Show("Preencha o campo Senha");
                            }
                            else
                            {
                                // Confirmar Senha
                                if (pwbConfirmSenha.Password.Equals(confirmarSenha))
                                {
                                    MessageBox.Show("Senha inválida");
                                }
                                else if (pwbConfirmSenha.Password.Equals(null) || pwbConfirmSenha.Password.Equals(""))
                                {
                                    MessageBox.Show("Preencha o campo Confirmar Senha");
                                }
                                else if (!pwbConfirmSenha.Password.Equals(pwbSenha.Password))
                                {
                                    MessageBox.Show("Senhas diferentes");
                                    pwbSenha.Password = senha;
                                    pwbConfirmSenha.Password = confirmarSenha;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
