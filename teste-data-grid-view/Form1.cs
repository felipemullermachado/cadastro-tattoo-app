using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace teste_data_grid_view
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            tbID.Clear();
            tbNome.Clear();
            tbIdeia.Clear();
            tbLocal.Clear();
            tbValor.Clear();
            tbData.Clear();
            tbTamanho.Clear();
        }

        private MySqlConnectionStringBuilder conexaoBanco()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "tattoo";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;
            return conexaoBD;
        }

        private void atualizaGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM pedido";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgPedido.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgPedido.Rows[0].Clone();
                    row.Cells[0].Value = reader.GetInt32(0);
                    row.Cells[1].Value = reader.GetString(1);
                    row.Cells[2].Value = reader.GetString(2);
                    row.Cells[3].Value = reader.GetString(3);
                    row.Cells[4].Value = reader.GetString(4);
                    row.Cells[5].Value = reader.GetString(5);
                    row.Cells[6].Value = reader.GetString(6);
                    row.Cells[7].Value = reader.GetString(7);
                    dgPedido.Rows.Add(row);
                }

                realizaConexaoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar a conexão com o Banco de Dados");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO pedido (nomePedido, ideiaPedido, localPedido, tamanhoPedido, dataPedido, valorPedido, statusPedido)" +
                "VALUES('" + tbNome.Text + "', '" + tbIdeia.Text + "', '" + tbLocal.Text + "', '" + tbTamanho.Text + "', '" + tbData.Text + "', " + Convert.ToInt32(tbValor.Text) + ", '" + tbStatus.SelectedItem + "')";
                comandoMySql.ExecuteNonQuery();

                realizaConexaoBD.Close();
                MessageBox.Show("Pedido inserido com sucesso");
                atualizaGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível inserir o pedido no Banco de Dados");
                Console.WriteLine(ex.Message);
            }
        }

        private void tbValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "DELETE from pedido WHERE idPedido = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexaoBD.Close();
                MessageBox.Show("Pedido excluído com sucesso");
                atualizaGrid();
                limparCampos();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o pedido!");
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE pedido SET nomePedido = '" + tbNome.Text + "', " +
                    "ideiaPedido = '" + tbIdeia.Text + "', " +
                    "localPedido = '" + tbLocal.Text + "', " +
                    "tamanhoPedido = '" + tbTamanho.Text + "', " +
                    "dataPedido = '" + tbData.Text + "', " +
                    "statusPedido = '" + tbStatus.SelectedItem + "', " +
                    "valorPedido = " + Convert.ToInt32(tbValor.Text) +
                    " WHERE idPedido = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexaoBD.Close();
                MessageBox.Show("Pedido alterado com sucesso");
                atualizaGrid();
                limparCampos();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível alterar o pedido!");
                Console.WriteLine(ex.Message);
            }
        }

        private void dgPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPedido.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgPedido.CurrentRow.Selected = true;
                tbID.Text = dgPedido.Rows[e.RowIndex].Cells["colID"].FormattedValue.ToString();
                tbNome.Text = dgPedido.Rows[e.RowIndex].Cells["colNome"].FormattedValue.ToString();
                tbIdeia.Text = dgPedido.Rows[e.RowIndex].Cells["colIdeia"].FormattedValue.ToString();
                tbLocal.Text = dgPedido.Rows[e.RowIndex].Cells["colLocal"].FormattedValue.ToString();
                tbTamanho.Text = dgPedido.Rows[e.RowIndex].Cells["colTamanho"].FormattedValue.ToString();
                tbData.Text = dgPedido.Rows[e.RowIndex].Cells["colData"].FormattedValue.ToString();
                tbValor.Text = dgPedido.Rows[e.RowIndex].Cells["colValor"].FormattedValue.ToString();
                tbStatus.SelectedItem = dgPedido.Rows[e.RowIndex].Cells["colStatus"].FormattedValue.ToString();
            }
        }
    }
}
