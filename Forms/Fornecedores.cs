using SistemaFinch.Business;
using SistemaFinch.Commons;

namespace SistemaFinch.Forms
{
    public partial class Fornecedores : Form
    {
        private readonly SistemaFinchBusines _business;
        private int? fornecedorId = null;
        private List<FornecedorDb> ListFornecedor;
        public Fornecedores(SistemaFinchBusines busines)
        {
            InitializeComponent();
            _business = busines;
            AtualizarGrid();

        }

        private void AtualizarGrid(string nome = null)
        {
           (var resultado,ListFornecedor) = _business.GetFornecedor(nome);
           // if (ListFornecedor is null) { dataGridView2.DataSource = null; }
           if (!resultado.Success) { MessageBox.Show(resultado.Message); }
            dataGridView2.DataSource = ListFornecedor?.Select(x => new { Id = x.Id, Nome = x.Nome, CNPJ = x.CNPJ, Endereco = x.Endereco, Ativo = x.Ativo }).ToList(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dataGridView2.SelectedRows[0];

                var id = linhaSelecionada.Cells["Id"].Value;

                _business.DeleteFornecedor(id.ToString());
                AtualizarGrid();


            }

        }

        private void Fornecedores_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (fornecedorId.HasValue)
            {
                
                _business.UpdateFornecedor(fornecedorId.Value, textBox2.Text, textBox10.Text, textBox8.Text, textBox6.Text, textBox7.Text, textBox9.Text, textBox5.Text, textBox4.Text, checkBox1.Checked);
                MessageBox.Show("Fornecedor atualizado");
            }
            else
            {
                
                var resultado = _business.PostFornecedor(textBox3.Text, textBox2.Text, textBox10.Text, textBox8.Text, textBox6.Text, textBox7.Text, textBox9.Text, textBox5.Text, textBox4.Text, checkBox1.Checked);
                MessageBox.Show("Fornecedor cadastrado");

            }


            fornecedorId = null;
            AtualizarGrid();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                var id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (!int.TryParse(id.ToString(), out int intId))
                {
                    MessageBox.Show("Erro");
                }
                else
                {
                    fornecedorId = intId;
                    var fornecedor = ListFornecedor.FirstOrDefault(f => f.Id == intId);

                    if (fornecedor is not null)
                    {
                        textBox2.Text = fornecedor.Nome.ToString();
                        textBox3.Text = fornecedor.CNPJ.ToString();
                        textBox10.Text = fornecedor.CEP.ToString();
                        textBox4.Text = fornecedor.Rua.ToString();
                        textBox5.Text = fornecedor.Numero.ToString();
                        textBox6.Text = fornecedor.Bairro.ToString();
                        textBox7.Text = fornecedor.Cidade.ToString();
                        textBox8.Text = fornecedor.Estado.ToString();
                        textBox9.Text = fornecedor.Complemento?.ToString() ?? "";
                        checkBox1.Checked = fornecedor.Ativo;

                        tabControl1.SelectTab(1);

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }


        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private async void textBox10_TabIndexChanged(object sender, EventArgs e)
        {



        }

        private async void textBox10_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox10.Text) || textBox10.Text.Length != 8 || !int.TryParse(textBox10.Text, out _))
            {
                MessageBox.Show("CEP inválido. Digite novamente!");
            }
            else
            {
                var endereco = await _business.GetCepAsync(textBox10.Text);

                textBox4.Text = endereco.logradouro ?? "";
                textBox8.Text = endereco.uf ?? "";
                textBox6.Text = endereco.bairro ?? "";
                textBox7.Text = endereco.localidade ?? "";
            }
        }



        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AtualizarGrid(textBox1.Text);
            }
        }
    }
}
