namespace Admin_Manager
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class theater : Form
    {
        private Button button1;
        private Button button2;
        private Button button3;
        private IContainer components;
        private string currentID = "";
        private DataGridView dataGridView1;
        private DataSet dataSetEvent = new DataSet();
        private DataTable dataTableEvents = new DataTable();
        private string fileName = "";
        private bool first = true;
        private const string imageType = ".png";
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private TextBox textClass;
        private TextBox textGenre;
        private TextBox textOther;
        private TextBox textSchedules;
        private TextBox textSeason;
        private TextBox textTitle;
        private System.Windows.Forms.Timer timer1;
        private const string videoType = ".avi";

        public theater()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileName = dialog.FileName;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileName = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((Form1.IP1 != null) && (Form1.IP1 != ""))
            {
                this.sendFile(Form1.IP1);
            }
            if ((Form1.IP2 != null) && (Form1.IP2 != ""))
            {
                this.sendFile(Form1.IP2);
            }
            if ((Form1.IP3 != null) && (Form1.IP3 != ""))
            {
                this.sendFile(Form1.IP3);
            }
            this.timer1.Start();
            this.currentID = null;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ((Form1.IP1 != null) && (Form1.IP1 != ""))
            {
                this.sendFile(Form1.IP1);
            }
            if ((Form1.IP2 != null) && (Form1.IP2 != ""))
            {
                this.sendFile(Form1.IP2);
            }
            if ((Form1.IP3 != null) && (Form1.IP3 != ""))
            {
                this.sendFile(Form1.IP3);
            }
            this.timer1.Start();
            this.currentID = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if ((Form1.IP1 != null) && (Form1.IP1 != ""))
            {
                this.deleteFile(Form1.IP1);
            }
            if ((Form1.IP2 != null) && (Form1.IP2 != ""))
            {
                this.deleteFile(Form1.IP2);
            }
            if ((Form1.IP3 != null) && (Form1.IP3 != ""))
            {
                this.deleteFile(Form1.IP3);
            }
            this.timer1.Start();
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
                this.currentID = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                this.textTitle.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                this.textGenre.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                this.textClass.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                this.textSchedules.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                this.textSeason.Text = this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                this.textOther.Text = this.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        public void deleteFile(string IP)
        {
            try
            {
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine("deleteTheater");
                writer.Flush();
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine(this.currentID);
                writer.Flush();
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine(0);
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

        public void initDatagirdView()
        {
            this.dataTableEvents.Columns.Add("ID", typeof(string));
            this.dataTableEvents.Columns.Add("TITLE", typeof(string));
            this.dataTableEvents.Columns.Add("GENRE", typeof(string));
            this.dataTableEvents.Columns.Add("CLASSIFICATION", typeof(string));
            this.dataTableEvents.Columns.Add("SCHEDULES", typeof(string));
            this.dataTableEvents.Columns.Add("SEASON", typeof(string));
            this.dataTableEvents.Columns.Add("OTHER", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.dataGridView1 = new DataGridView();
            this.button3 = new Button();
            this.button2 = new Button();
            this.button1 = new Button();
            this.textOther = new TextBox();
            this.label7 = new Label();
            this.textSchedules = new TextBox();
            this.label6 = new Label();
            this.textSeason = new TextBox();
            this.label4 = new Label();
            this.textClass = new TextBox();
            this.label3 = new Label();
            this.textGenre = new TextBox();
            this.label2 = new Label();
            this.textTitle = new TextBox();
            this.label1 = new Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(12, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x3f8, 0x19f);
            this.dataGridView1.TabIndex = 0x22;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.button3.Location = new Point(0xab, 0x38);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x31;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click_1);
            this.button2.Location = new Point(90, 0x38);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x30;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click_1);
            this.button1.Location = new Point(9, 0x38);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 0x2f;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click_1);
            this.textOther.Location = new Point(0x2eb, 30);
            this.textOther.Multiline = true;
            this.textOther.Name = "textOther";
            this.textOther.Size = new Size(0x119, 0x68);
            this.textOther.TabIndex = 0x2e;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x2e8, 14);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x21, 13);
            this.label7.TabIndex = 0x2d;
            this.label7.Text = "Other";
            this.textSchedules.Location = new Point(0x191, 30);
            this.textSchedules.Name = "textSchedules";
            this.textSchedules.Size = new Size(0x80, 20);
            this.textSchedules.TabIndex = 0x2c;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x18e, 14);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x39, 13);
            this.label6.TabIndex = 0x2b;
            this.label6.Text = "Schedules";
            this.textSeason.Location = new Point(0x217, 30);
            this.textSeason.Name = "textSeason";
            this.textSeason.Size = new Size(0xce, 20);
            this.textSeason.TabIndex = 0x2a;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x214, 14);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2b, 13);
            this.label4.TabIndex = 0x29;
            this.label4.Text = "Season";
            this.textClass.Location = new Point(0xdd, 30);
            this.textClass.Name = "textClass";
            this.textClass.Size = new Size(0xae, 20);
            this.textClass.TabIndex = 40;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xda, 14);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x44, 13);
            this.label3.TabIndex = 0x27;
            this.label3.Text = "Classification";
            this.textGenre.Location = new Point(0x73, 30);
            this.textGenre.Name = "textGenre";
            this.textGenre.Size = new Size(100, 20);
            this.textGenre.TabIndex = 0x26;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x70, 14);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x24, 13);
            this.label2.TabIndex = 0x25;
            this.label2.Text = "Genre";
            this.textTitle.Location = new Point(9, 30);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new Size(100, 20);
            this.textTitle.TabIndex = 0x24;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1b, 13);
            this.label1.TabIndex = 0x23;
            this.label1.Text = "Title";
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x40e, 0x237);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textOther);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.textSchedules);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.textSeason);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.textClass);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textGenre);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textTitle);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.dataGridView1);
            base.Name = "theater";
            this.Text = "theater";
            base.Load += new EventHandler(this.theater_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void sendFile(string IP)
        {
            if ((this.fileName != null) && (this.fileName != ""))
            {
                try
                {
                    if ((this.currentID == "") || (this.currentID == null))
                    {
                        Console.WriteLine("add new !!!!!!!!!!!!");
                        this.currentID = DateTime.Now.ToString().Replace(" ", null).Replace("/", null).Replace(":", null) + ".png";
                    }
                    string input = this.textTitle.Text + "|cut|" + this.textGenre.Text + "|cut|" + this.textClass.Text + "|cut|" + this.textSchedules.Text + "|cut|" + this.textSeason.Text + "|cut|" + this.textOther.Text;
                    Console.WriteLine("File name:" + this.fileName);
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    byte[] buffer = System.IO.File.ReadAllBytes(this.fileName);
                    writer.WriteLine(buffer.Length.ToString());
                    writer.Flush();
                    writer.WriteLine("addForTheater");
                    writer.Flush();
                    writer.WriteLine(this.toSafeString(input));
                    writer.Flush();
                    writer.WriteLine(this.currentID);
                    writer.Flush();
                    writer.WriteLine(0);
                    writer.Flush();
                    writer.WriteLine(0);
                    writer.Flush();
                    Thread.Sleep(300);
                    Console.WriteLine("Sending file:" + this.fileName);
                    client.Client.SendFile(this.fileName);
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
        }

        private void theater_Load(object sender, EventArgs e)
        {
            this.initDatagirdView();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.dataTableEvents.Rows.Clear();
            if ((Form1.IP1 != null) && (Form1.IP1 != ""))
            {
                this.updateDatagiridview(Form1.IP1);
            }
            else if ((Form1.IP2 != null) && (Form1.IP2 != ""))
            {
                this.updateDatagiridview(Form1.IP2);
            }
            else if ((Form1.IP3 != null) && (Form1.IP3 != ""))
            {
                this.updateDatagiridview(Form1.IP3);
            }
        }

        public string toNormalString(string input) => 
            input.Replace("|enter|", Environment.NewLine).Replace("|space|", " ").Replace("|dotdot|", ":");

        public string toSafeString(string input) => 
            input.Replace(" ", "|space|").Replace(":", "|dotdot|").Replace(Environment.NewLine, "|enter|");

        public void updateDatagiridview(string IP)
        {
            WebClient client = new WebClient();
            try
            {
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/theater/infomation").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0], this.convertToUtf8(this.toNormalString(strArray2[1])), this.convertToUtf8(this.toNormalString(strArray2[2])), this.convertToUtf8(this.toNormalString(strArray2[3])), this.convertToUtf8(this.toNormalString(strArray2[4])), this.convertToUtf8(this.toNormalString(strArray2[5])), this.convertToUtf8(this.toNormalString(strArray2[6])) };
                            this.dataTableEvents.Rows.Add(values);
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
            if (this.first)
            {
                this.dataSetEvent.Tables.Add(this.dataTableEvents);
                this.dataGridView1.DataMember = this.dataTableEvents.TableName;
                this.first = false;
            }
            this.dataGridView1.DataSource = this.dataSetEvent;
        }
    }
}

