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

    public class cinemaForm : Form
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
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textDirector;
        private TextBox textDuration;
        private TextBox textList;
        private TextBox textOther;
        private TextBox textRoom;
        private TextBox textSchedules;
        private TextBox textTitle;
        private System.Windows.Forms.Timer timer1;
        private const string videoType = ".avi";

        public cinemaForm()
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

        private void button3_Click(object sender, EventArgs e)
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

        private void cinemaForm_Load(object sender, EventArgs e)
        {
            this.initDatagirdView();
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
                this.textDirector.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                this.textList.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                this.textDuration.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                this.textRoom.Text = this.dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
                this.textSchedules.Text = this.dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
                this.textOther.Text = this.dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
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
                writer.WriteLine("deleteCinema");
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
            this.dataTableEvents.Columns.Add("DIRECTOR", typeof(string));
            this.dataTableEvents.Columns.Add("LIST", typeof(string));
            this.dataTableEvents.Columns.Add("DURATION", typeof(string));
            this.dataTableEvents.Columns.Add("ROOM", typeof(string));
            this.dataTableEvents.Columns.Add("SCHEDULES", typeof(string));
            this.dataTableEvents.Columns.Add("OTHER", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.textTitle = new TextBox();
            this.textDirector = new TextBox();
            this.label2 = new Label();
            this.textList = new TextBox();
            this.label3 = new Label();
            this.textDuration = new TextBox();
            this.label4 = new Label();
            this.textSchedules = new TextBox();
            this.label6 = new Label();
            this.textOther = new TextBox();
            this.label7 = new Label();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.dataGridView1 = new DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new Label();
            this.textRoom = new TextBox();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x1a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1b, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            this.textTitle.Location = new Point(15, 0x2a);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new Size(100, 20);
            this.textTitle.TabIndex = 1;
            this.textDirector.Location = new Point(0x79, 0x2a);
            this.textDirector.Name = "textDirector";
            this.textDirector.Size = new Size(100, 20);
            this.textDirector.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x76, 0x1a);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2c, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Director";
            this.textList.Location = new Point(0xe3, 0x2a);
            this.textList.Name = "textList";
            this.textList.Size = new Size(0xae, 20);
            this.textList.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xe0, 0x1a);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "List";
            this.textDuration.Location = new Point(0x197, 0x2a);
            this.textDuration.Name = "textDuration";
            this.textDuration.Size = new Size(100, 20);
            this.textDuration.TabIndex = 7;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x194, 0x1a);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2f, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Duration";
            this.textSchedules.Location = new Point(0x26b, 0x2a);
            this.textSchedules.Name = "textSchedules";
            this.textSchedules.Size = new Size(0x80, 20);
            this.textSchedules.TabIndex = 11;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x268, 0x1a);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Schedules";
            this.textOther.Location = new Point(0x2f1, 0x2a);
            this.textOther.Multiline = true;
            this.textOther.Name = "textOther";
            this.textOther.Size = new Size(0x119, 0x68);
            this.textOther.TabIndex = 13;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(750, 0x1a);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x21, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Other";
            this.button1.Location = new Point(15, 0x44);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 14;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.button2.Location = new Point(0x60, 0x44);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 15;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.button3.Location = new Point(0xb1, 0x44);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x10;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(7, 0x98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x403, 0x163);
            this.dataGridView1.TabIndex = 0x11;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(510, 0x1a);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x23, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Room";
            this.textRoom.Location = new Point(0x201, 0x2a);
            this.textRoom.Name = "textRoom";
            this.textRoom.Size = new Size(100, 20);
            this.textRoom.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x416, 0x207);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textOther);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.textSchedules);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.textRoom);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.textDuration);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.textList);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textDirector);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textTitle);
            base.Controls.Add(this.label1);
            base.Name = "cinemaForm";
            this.Text = "cinemaForm";
            base.Load += new EventHandler(this.cinemaForm_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void label5_Click(object sender, EventArgs e)
        {
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
                    string input = this.textTitle.Text + "|cut|" + this.textDirector.Text + "|cut|" + this.textList.Text + "|cut|" + this.textDuration.Text + "|cut|" + this.textRoom.Text + "|cut|" + this.textSchedules.Text + "|cut|" + this.textOther.Text;
                    Console.WriteLine("File name:" + this.fileName);
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    byte[] buffer = System.IO.File.ReadAllBytes(this.fileName);
                    writer.WriteLine(buffer.Length.ToString());
                    writer.Flush();
                    writer.WriteLine("addForCinema");
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

        private void textRoom_TextChanged(object sender, EventArgs e)
        {
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
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/cinema/infomation").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0], this.convertToUtf8(this.toNormalString(strArray2[1])), this.convertToUtf8(this.toNormalString(strArray2[2])), this.convertToUtf8(this.toNormalString(strArray2[3])), this.convertToUtf8(this.toNormalString(strArray2[4])), this.convertToUtf8(this.toNormalString(strArray2[5])), this.convertToUtf8(this.toNormalString(strArray2[6])), this.convertToUtf8(this.toNormalString(strArray2[7])) };
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

