using SistemaFinch.Business;

namespace SistemaFinch.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SistemaFinchBusines business = new("Data Source=JONIEL;Initial Catalog=JonielDb;Integrated Security=True;User Id=sa;TrustServerCertificate=true;");
            var resultado = business.GetUsuario(textBox1.Text, textBox2.Text);
            if (resultado.Success)
            {
                MessageBox.Show($"{resultado.Message} autenticado com sucesso");
                Menu menu = new(resultado.Message, business);
                Hide();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Não autenticado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
