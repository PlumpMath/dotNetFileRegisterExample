﻿using System;
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
using Microsoft.Win32;

namespace AppBlockchain
{
    /// <summary>
    /// Lógica interna para Arquivo.xaml
    /// </summary>
    public partial class Arquivo : Window
    {
        string imgPath = "C:/Users/Willie/Documents/AStar/Projetos/dotNetFileRegisterExample/AppBlockchain/img/";

        public Arquivo()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
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
                bitmapFundo.UriSource = new Uri(imgPath + "arquivo.png");
                bitmapFundo.EndInit();
                imgDropArquivo.Source = bitmapFundo;
            }
            catch(System.IO.IOException ex)
            {
                MessageBox.Show("Não foi possivel carregar imagem. Exception: " + ex.Message, "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

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

        // DragAndDrop Arquivo
        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileName"))
            {
                string fileName = (e.Data.GetData("FileName") as string[])[0];
                txtLocalArq.Text = fileName;
            }
        }

        private void imgDropArquivo_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileName"))
            {
                string fileName = (e.Data.GetData("FileName") as string[])[0];
                txtLocalArq.Text = fileName;
            }
        }

        // Procurar Arquivo manualmente
        private void btnFindArq_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog().Equals(true))
            {
                txtLocalArq.Text = dialog.FileName;
            }
        }

        // Text Encontrar Arquivo
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

        
    }
}
