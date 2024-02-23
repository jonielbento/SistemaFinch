using SistemaFinch.Business;
using SistemaFinch.Commons;
using System.Data;

namespace SistemaFinch.Forms
{
    public partial class Produtos : Form
    {
        private readonly SistemaFinchBusines _business;
        private List<ProdutoDb> listProduto;
        private List<FornecedorDb> listFornecedor;
        private int? produtoId;
        private int? fornecedorId;
        public Produtos(SistemaFinchBusines busines)
        {
            InitializeComponent();
            _business = busines;
            AtualizarGrid();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AtualizarGrid(string nome = null)
        {
            (var resultado, listProduto) = _business.GetProduto(nome);
            if (listProduto is null) { dataGridView2.DataSource = null; }
            else { dataGridView2.DataSource = dataGridView2.DataSource = listProduto.Select(x => new { x.Id, x.Nome, x.Fornecedor, x.Quantidade }).ToList(); }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!fornecedorId.HasValue)
            {
                MessageBox.Show("Produto já cadastrado");

            }
            else
            {
                if (produtoId.HasValue)
                {
                    _business.UpdateProduto(produtoId.Value, fornecedorId.Value, textBox2.Text, numericUpDown1.Value.ToString());
                    MessageBox.Show("Produto atualizado");
                }
                else
                {
                    _business.PostProduto(fornecedorId.Value, textBox2.Text, numericUpDown1.Value.ToString());
                    MessageBox.Show("Produto cadastrado");
                }

                if (true)
                {
                    produtoId = null;
                    fornecedorId = null;
                }

                AtualizarGrid();
            }
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
                    produtoId = intId;
                    var produto = listProduto.FirstOrDefault(f => f.Id == intId);

                    if (produto is not null)
                    {
                        fornecedorId = produto.FornecedorId;

                        PreencherComboBox();

                        textBox2.Text = produto.Nome.ToString();
                        comboBox1.Text = produto.Fornecedor.ToString();

                        numericUpDown1.Text = produto.Quantidade.ToString();


                        tabControl1.SelectTab(1);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            }
        }
        private void Produtos_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        public void PreencherComboBox()
        {
            comboBox1.DataSource = null;
           var (resultado, listFornecedor) = _business.GetFornecedor();
            comboBox1.DataSource = listFornecedor.Select(x => new { x.Id, x.Nome }).ToList();
            comboBox1.DisplayMember = "Nome";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PreencherComboBox();

            comboBox1.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            tabControl1.SelectTab(1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow linhaSelecionada = dataGridView2.SelectedRows[0];

                var id = linhaSelecionada.Cells["Id"].Value;

                _business.DeleteProduto(id.ToString());
                AtualizarGrid();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is not null && int.TryParse(comboBox1.SelectedValue.ToString(), out int id))
            {
                fornecedorId = id;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            AtualizarGrid(textBox1.Text);
        }

        private void tabControl1_ContextMenuStripChanged(object sender, EventArgs e)
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
