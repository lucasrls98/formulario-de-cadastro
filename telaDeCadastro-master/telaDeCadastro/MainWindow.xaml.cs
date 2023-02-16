using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace telaDeCadastro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
                
        public MainWindow()
        {                   
            InitializeComponent();
        }

        private void addButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstEnderecos.Items.Add(txtEndereco.Text);
            }
            catch 
            {
                MessageBox.Show("Por favor, informe um endereço para adicionar!");
            }
        }

        private void deleteButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            { //logica para remover o item da posicao selecionada 
                lstEnderecos.Items.RemoveAt(lstEnderecos.Items.IndexOf(lstEnderecos.SelectedItem));
            }
            catch
            {
                MessageBox.Show("Por favor, selecione um endereço para remover!");
            }
        }

        private void addButtonTel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lstTelefones.Items.Add(txtTelefone.Text);
            }
            catch
            {
                MessageBox.Show("Por favor, insira um número de telefone!");
            }
        }
        private void deleteButtonTel_Click(object sender, RoutedEventArgs e)
        {
            try
            { //logica para remover o item da posicao selecionada 
                lstTelefones.Items.RemoveAt(lstTelefones.Items.IndexOf(lstTelefones.SelectedItem));
            }
            catch
            {
                MessageBox.Show("Por favor, selecione um endereço para remover!");
            }
        }

    }
}
