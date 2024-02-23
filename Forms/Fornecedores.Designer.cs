namespace SistemaFinch.Forms
{
    partial class Fornecedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView2 = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            label10 = new Label();
            textBox10 = new TextBox();
            label9 = new Label();
            textBox9 = new TextBox();
            label8 = new Label();
            textBox8 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            checkBox1 = new CheckBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(630, 335);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView2);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(622, 307);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Consulta";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(35, 44);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RightToLeft = RightToLeft.No;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(542, 212);
            dataGridView2.TabIndex = 7;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 10F);
            button2.Location = new Point(504, 262);
            button2.Name = "button2";
            button2.Size = new Size(73, 28);
            button2.TabIndex = 3;
            button2.Text = "Novo";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(35, 262);
            button1.Name = "button1";
            button1.Size = new Size(73, 28);
            button1.TabIndex = 2;
            button1.Text = "Excluir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(106, 7);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 1;
            label1.Text = "Pesquisar";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(176, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 23);
            textBox1.TabIndex = 0;
            textBox1.Enter += textBox1_Enter;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(textBox10);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(textBox9);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(textBox8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(textBox6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(textBox3);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(619, 307);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cadastro";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.Location = new Point(271, 76);
            label10.Name = "label10";
            label10.Size = new Size(33, 19);
            label10.TabIndex = 22;
            label10.Text = "CEP";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(309, 76);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(89, 23);
            textBox10.TabIndex = 21;
            textBox10.TabIndexChanged += textBox10_TabIndexChanged;
            textBox10.Leave += textBox10_Leave;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(179, 170);
            label9.Name = "label9";
            label9.Size = new Size(96, 19);
            label9.TabIndex = 20;
            label9.Text = "Complemento";
            label9.Click += label9_Click;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(281, 167);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(117, 23);
            textBox9.TabIndex = 19;
            textBox9.TextChanged += textBox9_TextChanged_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(78, 167);
            label8.Name = "label8";
            label8.Size = new Size(50, 19);
            label8.TabIndex = 18;
            label8.Text = "Estado";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(135, 166);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(41, 23);
            textBox8.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(258, 141);
            label7.Name = "label7";
            label7.Size = new Size(51, 19);
            label7.TabIndex = 16;
            label7.Text = "Cidade";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(310, 138);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(88, 23);
            textBox7.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(78, 137);
            label6.Name = "label6";
            label6.Size = new Size(45, 19);
            label6.TabIndex = 14;
            label6.Text = "Bairro";
            label6.Click += label6_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(135, 137);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(117, 23);
            textBox6.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(309, 110);
            label5.Name = "label5";
            label5.Size = new Size(25, 19);
            label5.TabIndex = 12;
            label5.Text = "Nº";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(340, 109);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(58, 23);
            textBox5.TabIndex = 11;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(135, 202);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(54, 19);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "Ativo";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(48, 109);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 9;
            label4.Text = "Logradouro";
            label4.Click += label4_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(135, 108);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(153, 23);
            textBox4.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(83, 76);
            label3.Name = "label3";
            label3.Size = new Size(40, 19);
            label3.TabIndex = 7;
            label3.Text = "CNPJ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(135, 75);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(127, 23);
            textBox3.TabIndex = 6;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 10F);
            button3.Location = new Point(384, 211);
            button3.Name = "button3";
            button3.Size = new Size(73, 28);
            button3.TabIndex = 5;
            button3.Text = "Salvar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10F);
            button4.Location = new Point(23, 211);
            button4.Name = "button4";
            button4.Size = new Size(73, 28);
            button4.TabIndex = 4;
            button4.Text = "Cancelar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(83, 47);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 2;
            label2.Text = "Nome";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(263, 23);
            textBox2.TabIndex = 1;
            // 
            // Fornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(628, 332);
            Controls.Add(tabControl1);
            Name = "Fornecedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fornecedores";
            Load += Fornecedores_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private TextBox textBox1;
        private TabPage tabPage2;
        private TextBox textBox2;
        private Button button1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
        private CheckBox checkBox1;
        private Label label4;
        private TextBox textBox4;
        private Label label3;
        private TextBox textBox3;
        private Label label6;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox5;
        private Label label9;
        private TextBox textBox9;
        private Label label8;
        private TextBox textBox8;
        private Label label7;
        private TextBox textBox7;
        private Label label10;
        private TextBox textBox10;
        private DataGridView dataGridView2;
    }
}