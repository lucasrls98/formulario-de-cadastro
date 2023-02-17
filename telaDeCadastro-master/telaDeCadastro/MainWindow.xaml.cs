using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

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

        SqlConnection cn= new SqlConnection("Data Source=AVELL\\SQLEXPRESS;Initial Catalog=dadosCadastro;Integrated security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dt;


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

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cn.Open();
                string strSQL = "Select cpf from tblCadastro where cpf = '" + txtCPF.Text + "'";
                cmd.Connection = cn;
                cmd.CommandText = strSQL;
                dt = cmd.ExecuteReader();
                if (dt.HasRows)
                {
                    MessageBox.Show("CPF já cadastrado", "Ops", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (!dt.IsClosed) { dt.Close(); }
                    cmd.Parameters.Clear();

                    strSQL = "insert into tblCadastro(primeironome, sobrenome, rg, cpf, sexo, escolaridade, profissao, datadenascimento, endereco, telefone)values(@primeironome, @sobrenome, @rg, @cpf, @sexo, @escolaridade, @profissao, @datadenascimento, @endereco, @telefone)"; 
                    cmd.Parameters.Add("@primeironome", SqlDbType.NVarChar).Value = txtPrimeiroNome.Text;                    
                    cmd.Parameters.Add("@sobrenome", SqlDbType.NVarChar).Value = txtSobrenome.Text;
                    cmd.Parameters.Add("@rg", SqlDbType.NVarChar).Value = txtRG.Text;
                    cmd.Parameters.Add("@cpf", SqlDbType.NVarChar).Value = txtCPF.Text;
                    cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = txtSexo.Text;
                    cmd.Parameters.Add("@escolaridade", SqlDbType.NVarChar).Value = txtEscolaridade.Text;
                    cmd.Parameters.Add("@profissao", SqlDbType.NVarChar).Value = txtProfissao.Text;
                    cmd.Parameters.Add("@datadenascimento", SqlDbType.NVarChar).Value = txtDataNascimento.Text;
                    cmd.Parameters.Add("@endereco", SqlDbType.NVarChar).Value = txtEndereco.Text;
                    cmd.Parameters.Add("@telefone", SqlDbType.NVarChar).Value =txtTelefone.Text;





                    cmd.Connection = cn;
                    cmd.CommandText = strSQL;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados cadastrados com sucesso!", "dados cadastrados", MessageBoxButton.OK, MessageBoxImage.Information);

                    cmd.Parameters.Clear();
                    cn.Close(); //fechando conexão do sql

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                cn.Close();
            }
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
