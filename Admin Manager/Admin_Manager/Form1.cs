namespace Admin_Manager
{
    using Admin_Manager.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private Button button1;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private CheckBox checkBox1;
        private IContainer components;
        private DataGridView dataGridView1;
        private DataSet dataSetCarousel = new DataSet();
        private DataSet dataSetMasterBlock = new DataSet();
        private DataSet dataSetNormalBlock = new DataSet();
        private DataTable dataTableCarousel = new DataTable();
        private DataTable dataTableMasterBlock = new DataTable();
        private DataTable dataTableNormalBlock = new DataTable();
        private bool debug = true;
        private string fileName;
        private string fileNameCarousel;
        private string fileNameLogo;
        private bool first = true;
        private bool firstTimeforCarousel = true;
        private const string imageType = ".png";
        public static string IP1;
        public static string IP2;
        public static string IP3;
        private bool isShowMaster = true;
        private Label label1;
        private Label label10;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox nameBlock;
        private Label NumB8;
        private TextBox numberBlock;
        private Label numberBlockqq;
        private Label numNomalBlock;
        private List<string> officeNameString = new List<string>();
        private TextBox phoneNumber;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private TextBox segment;
        private bool showInfoOfCarousel;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private System.Windows.Forms.Timer timer1;
        private const string videoType = ".avi";

        public Form1()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((IP1 != null) && (IP1 != ""))
            {
                this.sendFile(IP1);
            }
            if ((IP2 != null) && (IP2 != ""))
            {
                this.sendFile(IP2);
            }
            if ((IP3 != null) && (IP3 != ""))
            {
                this.sendFile(IP3);
            }
            this.timer1.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addNewPointForm form = new addNewPointForm();
            form.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
            base.Hide();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            theater theater = new theater();
            theater.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
            base.Hide();
            theater.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cinemaForm form = new cinemaForm();
            form.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
            base.Hide();
            form.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            officeManager manager = new officeManager();
            manager.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
            base.Hide();
            manager.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileName = dialog.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((IP1 != null) && (IP1 != ""))
            {
                this.deleteFile(IP1);
            }
            if ((IP2 != null) && (IP2 != ""))
            {
                this.deleteFile(IP2);
            }
            if ((IP3 != null) && (IP3 != ""))
            {
                this.deleteFile(IP3);
            }
            this.timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileNameCarousel = dialog.FileName;
                this.textBox4.Text = Path.GetFileNameWithoutExtension(this.fileNameCarousel).Trim() + ".png";
                this.textBox5.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((IP1 != null) && (IP1 != ""))
            {
                this.sendCarouselFile(IP1);
            }
            if ((IP2 != null) && (IP2 != ""))
            {
                this.sendCarouselFile(IP2);
            }
            if ((IP3 != null) && (IP3 != ""))
            {
                this.sendCarouselFile(IP3);
            }
            this.timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((IP1 != null) && (IP1 != ""))
            {
                this.deleteCarouselFile(IP1);
            }
            if ((IP2 != null) && (IP2 != ""))
            {
                this.deleteCarouselFile(IP2);
            }
            if ((IP3 != null) && (IP3 != ""))
            {
                this.deleteCarouselFile(IP3);
            }
            this.timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileNameCarousel = dialog.FileName;
                this.textBox5.Text = "0";
                this.textBox5.Enabled = false;
                this.textBox4.Text = Path.GetFileNameWithoutExtension(this.fileNameCarousel).Trim() + ".avi";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            eventManager manager = new eventManager();
            manager.FormClosed += new FormClosedEventHandler(this.otherForm_FormClosed);
            base.Hide();
            manager.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileNameLogo = dialog.FileName;
            }
        }

        public string convertToUtf8(string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
                if (this.showInfoOfCarousel)
                {
                    this.textBox4.Text = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                    this.textBox5.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                }
                else
                {
                    this.textBox2.Text = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                    this.textBox3.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                    this.textBox1.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    this.nameBlock.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    this.numberBlock.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    this.segment.Text = this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                    this.phoneNumber.Text = this.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void deleteCarouselFile(string IP)
        {
            try
            {
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("deleteCarousel");
                writer.Flush();
                writer.WriteLine("deleteCarousel");
                writer.Flush();
                writer.WriteLine(this.textBox4.Text);
                writer.Flush();
                writer.WriteLine(this.textBox5.Text);
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
        }

        public void deleteFile(string IP)
        {
            try
            {
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine(("b" + this.textBox2.Text + this.textBox3.Text + this.textBox1.Text + Path.GetExtension(this.fileName)).Trim());
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
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

        public void enableEditCarousel(bool enable)
        {
            if (enable)
            {
                this.button4.Enabled = true;
                this.button7.Enabled = true;
                this.button6.Enabled = true;
                this.button5.Enabled = true;
                this.textBox4.Enabled = true;
                this.textBox5.Enabled = true;
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button3.Enabled = false;
                this.button9.Enabled = false;
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox3.Enabled = false;
                this.nameBlock.Enabled = false;
                this.numberBlock.Enabled = false;
            }
            else
            {
                this.button4.Enabled = false;
                this.button7.Enabled = false;
                this.button6.Enabled = false;
                this.button5.Enabled = false;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.button1.Enabled = true;
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button9.Enabled = true;
                this.textBox1.Enabled = true;
                this.textBox2.Enabled = true;
                this.textBox3.Enabled = true;
                this.nameBlock.Enabled = true;
                this.numberBlock.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.enableEditCarousel(false);
            this.initDatagirdView();
            this.timer1.Start();
        }

        public void initDatagirdView()
        {
            this.dataTableMasterBlock.Columns.Add("BLOCK", typeof(string));
            this.dataTableMasterBlock.Columns.Add("FLOOR", typeof(string));
            this.dataTableMasterBlock.Columns.Add("INDEX", typeof(string));
            this.dataTableMasterBlock.Columns.Add("NAME", typeof(string));
            this.dataTableMasterBlock.Columns.Add("NUMBER", typeof(string));
            this.dataTableMasterBlock.Columns.Add("SEGMENT", typeof(string));
            this.dataTableMasterBlock.Columns.Add("PHONENUMBER", typeof(string));
            this.dataTableNormalBlock.Columns.Add("BLOCK", typeof(string));
            this.dataTableNormalBlock.Columns.Add("FLOOR", typeof(string));
            this.dataTableNormalBlock.Columns.Add("INDEX", typeof(string));
            this.dataTableNormalBlock.Columns.Add("NAME", typeof(string));
            this.dataTableNormalBlock.Columns.Add("NUMBER", typeof(string));
            this.dataTableNormalBlock.Columns.Add("SEGMENT", typeof(string));
            this.dataTableNormalBlock.Columns.Add("PHONENUMBER", typeof(string));
            this.dataTableCarousel.Columns.Add("NAME", typeof(string));
            this.dataTableCarousel.Columns.Add("TIMES_DISPLAY", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.button1 = new Button();
            this.NumB8 = new Label();
            this.numNomalBlock = new Label();
            this.dataGridView1 = new DataGridView();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.textBox3 = new TextBox();
            this.button2 = new Button();
            this.button3 = new Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new Label();
            this.numberBlockqq = new Label();
            this.nameBlock = new TextBox();
            this.numberBlock = new TextBox();
            this.label7 = new Label();
            this.textBox4 = new TextBox();
            this.label8 = new Label();
            this.textBox5 = new TextBox();
            this.button4 = new Button();
            this.button5 = new Button();
            this.button6 = new Button();
            this.button7 = new Button();
            this.segment = new TextBox();
            this.label9 = new Label();
            this.button8 = new Button();
            this.phoneNumber = new TextBox();
            this.label10 = new Label();
            this.button9 = new Button();
            this.checkBox1 = new CheckBox();
            this.button10 = new Button();
            this.button11 = new Button();
            this.button12 = new Button();
            this.button13 = new Button();
            this.pictureBox6 = new PictureBox();
            this.pictureBox5 = new PictureBox();
            this.pictureBox4 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox1 = new PictureBox();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            ((ISupportInitialize) this.pictureBox6).BeginInit();
            ((ISupportInitialize) this.pictureBox5).BeginInit();
            ((ISupportInitialize) this.pictureBox4).BeginInit();
            ((ISupportInitialize) this.pictureBox3).BeginInit();
            ((ISupportInitialize) this.pictureBox2).BeginInit();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            base.SuspendLayout();
            this.button1.Location = new Point(0x4b2, 0xf1);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.NumB8.AutoSize = true;
            this.NumB8.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.NumB8.Location = new Point(0x18c, 0x77);
            this.NumB8.Name = "NumB8";
            this.NumB8.Size = new Size(30, 0x1f);
            this.NumB8.TabIndex = 5;
            this.NumB8.Text = "0";
            this.NumB8.TextAlign = ContentAlignment.MiddleCenter;
            this.numNomalBlock.AutoSize = true;
            this.numNomalBlock.Font = new Font("Microsoft Sans Serif", 20.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.numNomalBlock.Location = new Point(0x2f6, 0x77);
            this.numNomalBlock.Name = "numNomalBlock";
            this.numNomalBlock.Size = new Size(30, 0x1f);
            this.numNomalBlock.TabIndex = 7;
            this.numNomalBlock.Text = "0";
            this.numNomalBlock.TextAlign = ContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(0xf4, 0x157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x45a, 280);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label2.Location = new Point(0x474, 0x77);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x13, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "0";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label3.Location = new Point(0x474, 0xa1);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x13, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "0";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1f5, 0xe3);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x21, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Index";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x110, 0xe2);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x22, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Block";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x187, 0xe3);
            this.label6.Name = "label6";
            this.label6.Size = new Size(30, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Floor";
            this.textBox1.Location = new Point(0x1d7, 0xf3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 20);
            this.textBox1.TabIndex = 15;
            this.textBox2.Location = new Point(0xef, 0xf3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(100, 20);
            this.textBox2.TabIndex = 0x10;
            this.textBox3.Location = new Point(0x162, 0xf3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Size(100, 20);
            this.textBox3.TabIndex = 0x11;
            this.button2.Location = new Point(0x42a, 240);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x12;
            this.button2.Text = "Choose File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Location = new Point(0x503, 0xf1);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x13;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x279, 0xe1);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x23, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            this.numberBlockqq.AutoSize = true;
            this.numberBlockqq.Location = new Point(0x2f5, 0xe1);
            this.numberBlockqq.Name = "numberBlockqq";
            this.numberBlockqq.Size = new Size(0x2c, 13);
            this.numberBlockqq.TabIndex = 0x15;
            this.numberBlockqq.Text = "Number";
            this.nameBlock.Location = new Point(600, 0xf3);
            this.nameBlock.Name = "nameBlock";
            this.nameBlock.Size = new Size(100, 20);
            this.nameBlock.TabIndex = 0x16;
            this.nameBlock.KeyPress += new KeyPressEventHandler(this.nameBlock_KeyPress);
            this.numberBlock.Location = new Point(730, 0xf3);
            this.numberBlock.Name = "numberBlock";
            this.numberBlock.Size = new Size(100, 20);
            this.numberBlock.TabIndex = 0x17;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x110, 0x113);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x23, 13);
            this.label7.TabIndex = 0x18;
            this.label7.Text = "Name";
            this.textBox4.Location = new Point(0xef, 0x123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Size(100, 20);
            this.textBox4.TabIndex = 0x19;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(370, 0x113);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x43, 13);
            this.label8.TabIndex = 0x1a;
            this.label8.Text = "Time Display";
            this.textBox5.Location = new Point(0x162, 0x123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Size(100, 20);
            this.textBox5.TabIndex = 0x1b;
            this.button4.Location = new Point(0x1d7, 0x120);
            this.button4.Name = "button4";
            this.button4.Size = new Size(0x4b, 0x17);
            this.button4.TabIndex = 0x1c;
            this.button4.Text = "Image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new EventHandler(this.button4_Click);
            this.button5.Location = new Point(0x292, 0x120);
            this.button5.Name = "button5";
            this.button5.Size = new Size(0x4b, 0x17);
            this.button5.TabIndex = 0x1d;
            this.button5.Text = "Add";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new EventHandler(this.button5_Click);
            this.button6.Location = new Point(740, 0x120);
            this.button6.Name = "button6";
            this.button6.Size = new Size(0x4b, 0x17);
            this.button6.TabIndex = 30;
            this.button6.Text = "Delete";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new EventHandler(this.button6_Click);
            this.button7.Location = new Point(0x236, 0x120);
            this.button7.Name = "button7";
            this.button7.Size = new Size(0x4b, 0x17);
            this.button7.TabIndex = 0x1f;
            this.button7.Text = "Video";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new EventHandler(this.button7_Click);
            this.segment.Location = new Point(850, 0xf3);
            this.segment.Name = "segment";
            this.segment.Size = new Size(100, 20);
            this.segment.TabIndex = 0x20;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x369, 0xe2);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x31, 13);
            this.label9.TabIndex = 0x21;
            this.label9.Text = "Segment";
            this.button8.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic, GraphicsUnit.Point, 0);
            this.button8.Location = new Point(1, 0x81);
            this.button8.Name = "button8";
            this.button8.Size = new Size(220, 0x34);
            this.button8.TabIndex = 0x22;
            this.button8.Text = "Add Events";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new EventHandler(this.button8_Click);
            this.phoneNumber.Location = new Point(960, 0xf3);
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new Size(100, 20);
            this.phoneNumber.TabIndex = 0x23;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x3df, 0xe1);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x26, 13);
            this.label10.TabIndex = 0x24;
            this.label10.Text = "Phone";
            this.button9.Location = new Point(0x478, 0xf1);
            this.button9.Name = "button9";
            this.button9.Size = new Size(0x34, 0x17);
            this.button9.TabIndex = 0x25;
            this.button9.Text = "Info";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new EventHandler(this.button9_Click);
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new Point(0x42a, 0x113);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new Size(0x65, 0x11);
            this.checkBox1.TabIndex = 0x26;
            this.checkBox1.Text = "For empty office";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.button10.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic);
            this.button10.Location = new Point(1, 180);
            this.button10.Name = "button10";
            this.button10.Size = new Size(220, 0x3a);
            this.button10.TabIndex = 0x27;
            this.button10.Text = "Add New Point";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new EventHandler(this.button10_Click);
            this.button11.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic);
            this.button11.Location = new Point(1, 0xec);
            this.button11.Name = "button11";
            this.button11.Size = new Size(220, 0x38);
            this.button11.TabIndex = 40;
            this.button11.Text = "Add Theater";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new EventHandler(this.button11_Click);
            this.button12.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic);
            this.button12.Location = new Point(1, 0x123);
            this.button12.Name = "button12";
            this.button12.Size = new Size(220, 0x37);
            this.button12.TabIndex = 0x29;
            this.button12.Text = "Add Cinema";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new EventHandler(this.button12_Click);
            this.button13.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Italic);
            this.button13.Location = new Point(1, 0x157);
            this.button13.Name = "button13";
            this.button13.Size = new Size(220, 0x39);
            this.button13.TabIndex = 0x2a;
            this.button13.Text = "Add Route";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new EventHandler(this.button13_Click);
            this.pictureBox6.Image = Resources.caroulsel;
            this.pictureBox6.Location = new Point(0x3b7, 0x59);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new Size(230, 0x7d);
            this.pictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new EventHandler(this.pictureBox6_Click);
            this.pictureBox5.Image = Resources.addblock;
            this.pictureBox5.Location = new Point(600, 0x59);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new Size(230, 0x7d);
            this.pictureBox5.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new EventHandler(this.pictureBox5_Click);
            this.pictureBox4.Image = Resources.addblock8;
            this.pictureBox4.Location = new Point(0xf4, 0x58);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(230, 0x7d);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new EventHandler(this.pictureBox4_Click);
            this.pictureBox3.Image = Resources.padding;
            this.pictureBox3.Location = new Point(1, 0x81);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(220, 0x1fa);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox2.Image = Resources.changepassword;
            this.pictureBox2.Location = new Point(1, 0x4f);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(220, 0x35);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
            this.pictureBox1.Image = Resources.admin_bar;
            this.pictureBox1.Location = new Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(0x4fc, 80);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x55a, 0x27b);
            base.Controls.Add(this.button13);
            base.Controls.Add(this.button12);
            base.Controls.Add(this.button11);
            base.Controls.Add(this.button10);
            base.Controls.Add(this.checkBox1);
            base.Controls.Add(this.button9);
            base.Controls.Add(this.label10);
            base.Controls.Add(this.phoneNumber);
            base.Controls.Add(this.button8);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.segment);
            base.Controls.Add(this.button7);
            base.Controls.Add(this.button6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.textBox5);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.textBox4);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.numberBlock);
            base.Controls.Add(this.nameBlock);
            base.Controls.Add(this.numberBlockqq);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.textBox3);
            base.Controls.Add(this.textBox2);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.pictureBox6);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.numNomalBlock);
            base.Controls.Add(this.pictureBox5);
            base.Controls.Add(this.NumB8);
            base.Controls.Add(this.pictureBox4);
            base.Controls.Add(this.pictureBox3);
            base.Controls.Add(this.pictureBox2);
            base.Controls.Add(this.pictureBox1);
            base.Controls.Add(this.button1);
            base.Name = "Form1";
            this.Text = "Admin Page";
            base.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            ((ISupportInitialize) this.pictureBox6).EndInit();
            ((ISupportInitialize) this.pictureBox5).EndInit();
            ((ISupportInitialize) this.pictureBox4).EndInit();
            ((ISupportInitialize) this.pictureBox3).EndInit();
            ((ISupportInitialize) this.pictureBox2).EndInit();
            ((ISupportInitialize) this.pictureBox1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void nameBlock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((IP1 != null) && (IP1 != ""))
                {
                    this.sendFile(IP1);
                }
                if ((IP2 != null) && (IP2 != ""))
                {
                    this.sendFile(IP2);
                }
                if ((IP3 != null) && (IP3 != ""))
                {
                    this.sendFile(IP3);
                }
                this.timer1.Start();
            }
        }

        private void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.enableEditCarousel(false);
            this.showInfoOfCarousel = false;
            this.isShowMaster = true;
            this.dataGridView1.DataSource = this.dataSetMasterBlock;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.enableEditCarousel(false);
            this.showInfoOfCarousel = false;
            this.isShowMaster = false;
            this.dataGridView1.DataSource = this.dataSetNormalBlock;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.enableEditCarousel(true);
            this.showInfoOfCarousel = true;
            this.dataGridView1.DataSource = this.dataSetCarousel;
        }

        public void sendCarouselFile(string IP)
        {
            if (this.fileNameCarousel != null)
            {
                try
                {
                    Console.WriteLine("File name:" + this.fileNameCarousel);
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    byte[] buffer = System.IO.File.ReadAllBytes(this.fileNameCarousel);
                    writer.WriteLine(buffer.Length.ToString());
                    writer.Flush();
                    writer.WriteLine("addCarousel");
                    writer.Flush();
                    writer.WriteLine(this.textBox4.Text);
                    writer.Flush();
                    writer.WriteLine(this.textBox5.Text);
                    writer.Flush();
                    writer.WriteLine("0");
                    writer.Flush();
                    writer.WriteLine("0");
                    writer.Flush();
                    Thread.Sleep(300);
                    Console.WriteLine("Sending file");
                    client.Client.SendFile(this.fileNameCarousel);
                }
                catch (Exception exception)
                {
                    Console.Write(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Choose image first!!");
            }
        }

        public void sendFile(string IP)
        {
            bool flag = false;
            if ((this.fileName != null) && (Path.GetExtension(this.fileName) == ".avi"))
            {
                flag = true;
            }
            if (((this.fileName != null) && (((this.fileNameLogo != null) || this.checkBox1.Checked) || flag)) || this.officeNameString.Contains("b" + this.textBox2.Text + this.textBox3.Text + this.textBox1.Text))
            {
                try
                {
                    if (this.fileName == null)
                    {
                        this.fileName = "dont_update.png";
                    }
                    Console.WriteLine("File name:" + this.fileName);
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    if (this.fileName == "dont_update.png")
                    {
                        writer.WriteLine("dont_update");
                    }
                    else
                    {
                        writer.WriteLine(System.IO.File.ReadAllBytes(this.fileName).Length.ToString());
                    }
                    writer.Flush();
                    writer.WriteLine(("b" + this.textBox2.Text + this.textBox3.Text + this.textBox1.Text + Path.GetExtension(this.fileName)).Trim());
                    writer.Flush();
                    if (!this.checkBox1.Checked)
                    {
                        writer.WriteLine(this.toSafeString(this.nameBlock.Text));
                    }
                    else
                    {
                        writer.WriteLine("for_empty_office");
                    }
                    writer.Flush();
                    writer.WriteLine(this.numberBlock.Text);
                    writer.Flush();
                    writer.WriteLine(this.segment.Text);
                    writer.Flush();
                    writer.WriteLine(this.toSafeString(this.phoneNumber.Text));
                    writer.Flush();
                    if (!flag)
                    {
                        if (this.checkBox1.Checked)
                        {
                            writer.WriteLine(0);
                        }
                        else if (this.fileNameLogo == null)
                        {
                            writer.WriteLine("dont_update");
                        }
                        else
                        {
                            writer.WriteLine(System.IO.File.ReadAllBytes(this.fileNameLogo).Length.ToString());
                        }
                        writer.Flush();
                    }
                    if (!this.checkBox1.Checked && !flag)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine("Sending logo file");
                        if (this.fileNameLogo != null)
                        {
                            client.Client.SendFile(this.fileNameLogo);
                        }
                    }
                    Thread.Sleep(500);
                    Console.WriteLine("Sending 3d file");
                    if (this.fileName != "dont_update.png")
                    {
                        client.Client.SendFile(this.fileName);
                    }
                }
                catch (Exception exception)
                {
                    Console.Write(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Choose icon file first!!");
            }
            if (!this.debug)
            {
                this.fileNameLogo = null;
                this.fileName = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if ((IP1 != null) && (IP1 != ""))
            {
                this.updateInfo(IP1);
            }
            else if ((IP2 != null) && (IP2 != ""))
            {
                this.updateInfo(IP2);
            }
            else if ((IP3 != null) && (IP3 != ""))
            {
                this.updateInfo(IP3);
            }
            this.dataTableNormalBlock.Rows.Clear();
            this.dataTableMasterBlock.Rows.Clear();
            this.dataTableCarousel.Rows.Clear();
            if ((IP1 != null) && (IP1 != ""))
            {
                this.updateDatagiridviewCarousel(IP1);
            }
            else if ((IP2 != null) && (IP2 != ""))
            {
                this.updateDatagiridviewCarousel(IP2);
            }
            else if ((IP3 != null) && (IP3 != ""))
            {
                this.updateDatagiridviewCarousel(IP3);
            }
        }

        public string toNormalString(string input) => 
            input.Replace("|enter|", Environment.NewLine).Replace("|space|", " ").Replace("|dotdot|", ":");

        public string toSafeString(string input) => 
            input.Replace(" ", "|space|").Replace(":", "|dotdot|").Replace(Environment.NewLine, "|enter|");

        public void updateDatagiridview(string IP)
        {
            this.officeNameString.Clear();
            WebClient client = new WebClient();
            try
            {
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/src/infomation").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0][1].ToString(), strArray2[0][2].ToString(), strArray2[0].Substring(3), this.convertToUtf8(this.toNormalString(strArray2[1])), strArray2[2], strArray2[3], this.toNormalString(strArray2[4]) };
                            if (strArray2[0][1] == '8')
                            {
                                this.dataTableMasterBlock.Rows.Add(values);
                            }
                            else
                            {
                                this.dataTableNormalBlock.Rows.Add(values);
                            }
                            this.officeNameString.Add(strArray2[0]);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                this.NumB8.Text = this.dataTableMasterBlock.Rows.Count.ToString();
                this.numNomalBlock.Text = this.dataTableNormalBlock.Rows.Count.ToString();
            }
            catch (WebException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Can't get infomation from server!!");
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
            if (this.first)
            {
                this.dataSetMasterBlock.Tables.Add(this.dataTableMasterBlock);
                this.dataSetNormalBlock.Tables.Add(this.dataTableNormalBlock);
                this.dataGridView1.DataMember = this.dataTableMasterBlock.TableName;
                this.first = false;
            }
            if (this.showInfoOfCarousel)
            {
                this.dataGridView1.DataSource = this.dataSetCarousel;
            }
            else if (this.isShowMaster)
            {
                this.dataGridView1.DataSource = this.dataSetMasterBlock;
            }
            else
            {
                this.dataGridView1.DataSource = this.dataSetNormalBlock;
            }
        }

        public void updateDatagiridviewCarousel(string IP)
        {
            WebClient client = new WebClient();
            try
            {
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/crs/infomation").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0], strArray2[1] };
                            this.dataTableCarousel.Rows.Add(values);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (WebException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Can't get infomation from server!!");
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
            if (this.firstTimeforCarousel)
            {
                this.dataSetCarousel.Tables.Add(this.dataTableCarousel);
                this.firstTimeforCarousel = false;
            }
            this.updateDatagiridview(IP);
        }

        public void updateInfo(string IP)
        {
            string input = string.Empty;
            WebClient client = new WebClient();
            try
            {
                input = client.DownloadString("http://" + IP + ":8080/crs/infomation");
                int count = Regex.Matches(input, ":").Count;
                int num2 = Regex.Matches(input, " 0:").Count;
                this.label2.Text = (count - num2).ToString();
                this.label3.Text = num2.ToString();
            }
            catch (WebException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (SocketException)
            {
                MessageBox.Show("Can't connect to server. Please check IP or Server for sure it has alredy run!!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Can't get infomation from server!!");
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
        }
    }
}

