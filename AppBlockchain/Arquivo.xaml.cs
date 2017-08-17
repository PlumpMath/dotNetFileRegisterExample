using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;

namespace AppBlockchain
{
    /// <summary>
    /// Lógica interna para Arquivo.xaml
    /// </summary>
    public partial class Arquivo : Window
    {
        ApiBlockchain api;
        Usuario usuario;
        AStar.Model.Transaction transaction;



        private string filePath = null;



        public Arquivo(string usuario)
        {
            InitializeComponent();
            this.usuario = new Usuario(usuario); // Carregar dados do usuario
        }


        #region Menu_Registrar

        // Menu Arquivo Registrar
        private void labMenuRegistrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labRegistrar.Visibility = Visibility.Visible;
            labValidar.Visibility = Visibility.Hidden;
        }

        private void labMenuRegistrar_MouseLeave(object sender, MouseEventArgs e)
        {
            labMenuRegistrar.FontWeight = FontWeights.Normal;
        }

        private void labMenuRegistrar_MouseEnter(object sender, MouseEventArgs e)
        {
            labMenuRegistrar.FontWeight = FontWeights.Bold;
        }

        #endregion

        #region Menu_Validar

        // Menu Arquivo Validar
        private void labMenuValidar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            labRegistrar.Visibility = Visibility.Hidden;
            labValidar.Visibility = Visibility.Visible;
        }

        private void labMenuValidar_MouseEnter(object sender, MouseEventArgs e)
        {
            labMenuValidar.FontWeight = FontWeights.Bold;
        }

        private void labMenuValidar_MouseLeave(object sender, MouseEventArgs e)
        {
            labMenuValidar.FontWeight = FontWeights.Normal;
        }

        #endregion

        // DragAndDrop Arquivo
        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            GetPath(e);
        }

        private void imgDropArquivo_Drop(object sender, DragEventArgs e)
        {
            GetPath(e);
        }

        private void GetPath(DragEventArgs e)
        {

            if (e.Data.GetDataPresent("FileName"))
            {
                string fileName = (e.Data.GetData("FileName") as string[])[0];
                txtLocalArq.Text = fileName;
                filePath = fileName;
            }
        }

        // Procurar Arquivo manualmente
        private void btnFindArq_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog().Equals(true))
            {
                txtLocalArq.Text = dialog.FileName;
                filePath = txtLocalArq.Text;
            }
        }

        // Text local Arquivo
        private void txtLocalArq_GotFocus(object sender, RoutedEventArgs e)
        {
            txtLocalArq.Text = null;
        }

        // Registrar
        private void labRegistrar_MouseEnter(object sender, MouseEventArgs e)
        {
            labRegistrar.FontWeight = FontWeights.Bold;
        }

        private void labRegistrar_MouseLeave(object sender, MouseEventArgs e)
        {
            labRegistrar.FontWeight = FontWeights.Normal;
        }

        // Validar
        private void labValidar_MouseEnter(object sender, MouseEventArgs e)
        {
            labValidar.FontWeight = FontWeights.Bold;
        }

        private void labValidar_MouseLeave(object sender, MouseEventArgs e)
        {
            labValidar.FontWeight = FontWeights.Normal;
        }


        // ______________
        // Chamada API...
        // --------------
        private async void labRegistrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            api = new ApiBlockchain();
            var result = await api.Registrar(usuario.privateKey, usuario.account, usuario.user, usuario.pass, hashArq(filePath), "bitcoin", 1);
        }

        private void labValidar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            api = new ApiBlockchain();
            transaction = api.SearchByHash(usuario.privateKey, usuario.account, usuario.user, usuario.pass, usuario.id, hashArq(filePath));
            MessageBox.Show("Hash: " + transaction.GetHashCode().ToString());
        }

        private string hashArq(string arquivo)
        {
            Stream stream = null;
            try
            {
                SHA256 mySHA256 = SHA256Managed.Create();
                stream = new FileStream(arquivo, FileMode.Open);
                stream.Position = 0;
                byte[] hashValue = mySHA256.ComputeHash(stream);
                //hashValue = mySHA256.ComputeHash(hashValue);???
                string hash = BitConverter.ToString(hashValue).Replace("-", String.Empty);
                return hash;
            }
            finally
            {
                stream.Close();
            }

        }
    }
}
