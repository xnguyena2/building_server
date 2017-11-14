namespace Admin_Manager
{
    using Admin_Manager.Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Login : Form
    {
        private Button button1;
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;

        public Login()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text != "")
            {
                if ((this.textBox1.Text == "admin") && (this.textBox2.Text == "admin"))
                {
                    Form1.IP1 = this.textBox3.Text;
                    Form1.IP2 = this.textBox4.Text;
                    Form1.IP3 = this.textBox5.Text;
                    Form1 form = new Form1();
                    form.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
                    base.Hide();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Wrong User name or Password!!");
                }
            }
            else
            {
                MessageBox.Show("IP can not empty!!");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.textBox3 = new TextBox();
            this.button1 = new Button();
            this.textBox4 = new TextBox();
            this.label4 = new Label();
            this.textBox5 = new TextBox();
            this.label5 = new Label();
            base.SuspendLayout();
            this.textBox1.Location = new Point(0x6c, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(0xc0, 20);
            this.textBox1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(90, 0x10);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new Size(80, 0x10);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            this.textBox2.Location = new Point(0x6c, 0x2e);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(0xc0, 20);
            this.textBox2.TabIndex = 3;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x4c, 0x4f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1a, 0x10);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP:";
            this.textBox3.Location = new Point(0x6c, 0x4a);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(0xc0, 20);
            this.textBox3.TabIndex = 5;
            this.button1.BackgroundImage = Resources.gray_login_extra_thin_button_hi1;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Location = new Point(0xb1, 0xa4);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x7b, 0x2d);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox4.Location = new Point(0x6c, 100);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(0xc0, 20);
            this.textBox4.TabIndex = 8;
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label4.Location = new Point(0x4c, 0x69);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1a, 0x10);
            this.label4.TabIndex = 7;
            this.label4.Text = "IP:";
            this.textBox5.Location = new Point(0x6c, 0x7e);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Size(0xc0, 20);
            this.textBox5.TabIndex = 10;
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label5.Location = new Point(0x4c, 0x83);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x1a, 0x10);
            this.label5.TabIndex = 9;
            this.label5.Text = "IP:";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(330, 0xe1);
            base.Controls.Add(this.textBox5);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.textBox4);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.textBox1);
            base.Name = "Login";
            this.Text = "Login";
            base.Load += new EventHandler(this.Login_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Show();
        }
    }
}

