using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        AStar.Model.Transaction[] transactions;
        private string filePath = null;
        static List<String> protocolos = new List<String>();

        public Arquivo(string usuario)
        {
            InitializeComponent();
            this.usuario = new Usuario(usuario); // Carregar dados do usuario
        }
        
        #region Menu_Registrar

        // Menu Arquivo Registrar
        private void labMenuRegistrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LimparArquivo();
            
            labRegistrar.Visibility = Visibility.Visible;
            cnvRegistros.Visibility = Visibility.Visible;

            labValidar.Visibility      = Visibility.Hidden;
            cnvTransactions.Visibility = Visibility.Hidden;
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
            LimparArquivo();

            labValidar.Visibility      = Visibility.Visible;
            cnvTransactions.Visibility = Visibility.Visible;

            labRegistrar.Visibility    = Visibility.Hidden;
            cnvRegistros.Visibility = Visibility.Hidden;
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

        #region DragAndDrop Arquivo
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
        #endregion

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

        #region Chamada API
        private async void labRegistrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (VerificarTxtArquivo())
            {
                if (MessageBox.Show("Registrar Arquivo?", "Atenção!", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.OK)
                {
                    api = new ApiBlockchain();
                    var result = await api.Registrar(usuario.privateKey, usuario.account, usuario.user, usuario.pass, hashArq(filePath), "bitcoin", 1);
                    protocolos.Add(result);
                    ApresentarProtocolos();
                }
            }
        }

        private void labValidar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (VerificarTxtArquivo())
            {
                api = new ApiBlockchain();
                transactions = api.SearchByHash(usuario.privateKey, usuario.account, usuario.user, usuario.pass, usuario.id, hashArq(filePath));
                ApresentarTransactions(transactions);
                /*
                MessageBox.Show("Data: " + transactions.Data);
                MessageBox.Show("Coin: " + transactions.Coin);
                 MessageBox.Show("Data Registro: " + transactions.Blockchaincreationdate.ToString());
                */
            }
        }

        private void ApresentarTransactions(AStar.Model.Transaction[] transactions)
        {
            try
            {
                listaTransactions.Items.Clear();
                if (transactions.Length.Equals(0))
                {
                    listaTransactions.Items.Add("Não existe registro para esse arquivo.");
                }
                else
                {
                    for (int i = 0; i < transactions.Length; i++)
                    {
                        String erro = transactions[i].Errormessage;
                        if (!erro.Equals(null))
                        {
                            listaTransactions.Items.Add(String.Format("Transaction retornou erro[ {0} ]", erro));
                        }
                        else
                        {
                            int id = (int)transactions[i].ID;
                            String Hash = transactions[i].Data.ToString(); // Hash do arquivo
                            String dataEnvioArquivo = transactions[i].Creationdate.ToString(); // Data de envio do arquivo
                            String dataRegistroBlockchain = transactions[i].Blockchaincreationdate.ToString(); // Data de registro na Blockchain
                            String dataConfirmacao = transactions[i].Confirmationdate.ToString(); // Data de registro aceito pela rede
                            String coin = transactions[i].Coin; // Rede

                            listaTransactions.Items.Add(String.Format("Transaction {0} - Registrado na Blockchain[ {1} ] na data [ {2} ]", id, coin, dataRegistroBlockchain));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Erro ao apresentar Transações. Exception: {0}", ex.Message), "Atenção");
            }
        }

        private Boolean VerificarTxtArquivo()
        {
            if(txtLocalArq.Text.Equals(null) || txtLocalArq.Text.Equals("") || txtLocalArq.Text.Equals("..."))
            {
                MessageBox.Show("Arquivo inválido", "Atencão", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }
            else
            {
                return true;
            }
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

        private void btnVerificarProtocolos_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show(String.Format("Existem {0} Protocolos", protocolos.Count.ToString()));
            protocolos.Add("");
            ApresentarProtocolos();
        }

        private void ApresentarProtocolos()
        {
            // Apresentar os protocolos gerados
            listaProtocolos.Items.Clear();
            for(int i=0; i<protocolos.Count; i++)
            {
                listaProtocolos.Items.Add(protocolos[i]);
            }
        }

        private void LimparArquivo()
        {
            txtLocalArq.Text = "...";
            listaProtocolos.Items.Clear();
            listaTransactions.Items.Clear();
        }
        #endregion
    }
}
