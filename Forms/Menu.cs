using SistemaFinch.Business;

namespace SistemaFinch.Forms
{
    public partial class Menu : Form
    {
        public SistemaFinchBusines _business { get; set; }
        public Menu(string usuario, SistemaFinchBusines business)
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Usuário: " + usuario;
            _business = business;
            this.IsMdiContainer = true;
            Login login = new();
            login.Close();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private async void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Fornecedores formFornecedores = new(_business)
            {
                MdiParent = this
            };

            formFornecedores.Show();


        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtos formProdutos = new(_business)
            {
                MdiParent = this
            };
            formProdutos.PreencherComboBox();
            formProdutos.Show();

        }
    }
}
