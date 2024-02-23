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
            var (success, user) = business.GetUsuario(textBox1.Text, textBox2.Text);
            if (success)
            {
                MessageBox.Show($"{user} autenticado com sucesso");
                Menu menu = new(user, business);
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
