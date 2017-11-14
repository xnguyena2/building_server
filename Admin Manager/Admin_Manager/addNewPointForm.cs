namespace Admin_Manager
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Windows.Forms;

    public class addNewPointForm : Form
    {
        private TextBox block;
        private Button button1;
        private Button button2;
        private IContainer components;
        private string currentPointID = "";
        private DataGridView dataGridView1;
        private DataSet dataSetEvent = new DataSet();
        private DataTable dataTableEvents = new DataTable();
        private bool first = true;
        private TextBox floor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox namePoint;
        private TextBox posX;
        private TextBox posY;
        private System.Windows.Forms.Timer timer1;

        public addNewPointForm()
        {
            this.InitializeComponent();
        }

        private void addNewPointForm_Load(object sender, EventArgs e)
        {
            this.initDatagirdView();
            this.timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
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
            this.currentPointID = null;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = this.dataGridView1.CurrentCell.RowIndex;
                this.block.Text = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                this.floor.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                this.namePoint.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                this.posX.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                this.posY.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        public void deleteFile(string IP)
        {
            try
            {
                this.currentPointID = "b" + this.block.Text + this.floor.Text + this.namePoint.Text;
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("deleteNewPoint");
                writer.Flush();
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine(this.currentPointID);
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
            this.dataTableEvents.Columns.Add("BLOCK", typeof(string));
            this.dataTableEvents.Columns.Add("FLOOR", typeof(string));
            this.dataTableEvents.Columns.Add("NAME", typeof(string));
            this.dataTableEvents.Columns.Add("X", typeof(string));
            this.dataTableEvents.Columns.Add("Y", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.block = new TextBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.floor = new TextBox();
            this.namePoint = new TextBox();
            this.posX = new TextBox();
            this.posY = new TextBox();
            this.button1 = new Button();
            this.dataGridView1 = new DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new Button();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1f, 0x27);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Block:";
            this.block.Location = new Point(0x47, 0x24);
            this.block.Name = "block";
            this.block.Size = new Size(0x55, 20);
            this.block.TabIndex = 1;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xb7, 0x27);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Floor:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x141, 0x27);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name:";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1d8, 0x27);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x11, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "X:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x264, 0x27);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x11, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Y:";
            this.floor.Location = new Point(0xd7, 0x24);
            this.floor.Name = "floor";
            this.floor.Size = new Size(100, 20);
            this.floor.TabIndex = 6;
            this.namePoint.Location = new Point(0x16a, 0x24);
            this.namePoint.Name = "namePoint";
            this.namePoint.Size = new Size(100, 20);
            this.namePoint.TabIndex = 7;
            this.posX.Location = new Point(0x1ec, 0x24);
            this.posX.Name = "posX";
            this.posX.Size = new Size(100, 20);
            this.posX.TabIndex = 8;
            this.posY.Location = new Point(0x278, 0x24);
            this.posY.Name = "posY";
            this.posY.Size = new Size(100, 20);
            this.posY.TabIndex = 9;
            this.button1.Location = new Point(0x2ef, 0x22);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 10;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(12, 0x5d);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x38a, 0x148);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.button2.Location = new Point(0x34b, 0x22);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 12;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(930, 0x1b1);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.posY);
            base.Controls.Add(this.posX);
            base.Controls.Add(this.namePoint);
            base.Controls.Add(this.floor);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.block);
            base.Controls.Add(this.label1);
            base.Name = "addNewPointForm";
            this.Text = "addNewPointForm";
            base.Load += new EventHandler(this.addNewPointForm_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void sendFile(string IP)
        {
            try
            {
                this.currentPointID = "b" + this.block.Text + this.floor.Text + this.namePoint.Text;
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("Connected. Sending file.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine("addNewPoint");
                writer.Flush();
                writer.WriteLine(this.posX.Text);
                writer.Flush();
                writer.WriteLine(this.currentPointID);
                writer.Flush();
                writer.WriteLine(this.posY.Text);
                writer.Flush();
                writer.WriteLine(0);
                writer.Flush();
                Thread.Sleep(300);
                Console.WriteLine("Sending file");
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
            }
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

        public void updateDatagiridview(string IP)
        {
            WebClient client = new WebClient();
            try
            {
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/newoffice/points").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0][1].ToString(), strArray2[0][2].ToString(), strArray2[0].Substring(3), strArray2[1], strArray2[2] };
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

