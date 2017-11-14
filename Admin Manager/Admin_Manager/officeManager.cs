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

    public class officeManager : Form
    {
        private Button button2;
        private Button button3;
        private IContainer components;
        private string currentID = "";
        private DataGridView dataGridView1;
        private DataSet dataSetEvent = new DataSet();
        private DataTable dataTableEvents = new DataTable();
        private bool first = true;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBlock;
        private TextBox textCamera;
        private TextBox textFloor;
        private TextBox textIndex;
        private TextBox textRoute;
        private System.Windows.Forms.Timer timer1;

        public officeManager()
        {
            this.InitializeComponent();
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
                this.textBlock.Text = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                this.textFloor.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                this.textIndex.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                this.textRoute.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                this.textCamera.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        public void deleteFile(string IP)
        {
            try
            {
                this.currentID = "b" + this.textBlock.Text + this.textFloor.Text + this.textIndex.Text;
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine(0);
                writer.Flush();
                writer.WriteLine("deleteNewOffice");
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
            this.dataTableEvents.Columns.Add("BLOCK", typeof(string));
            this.dataTableEvents.Columns.Add("FLOOR", typeof(string));
            this.dataTableEvents.Columns.Add("INDEX", typeof(string));
            this.dataTableEvents.Columns.Add("ROUTE", typeof(string));
            this.dataTableEvents.Columns.Add("CAMERA", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.button3 = new Button();
            this.button2 = new Button();
            this.textIndex = new TextBox();
            this.label3 = new Label();
            this.textFloor = new TextBox();
            this.label2 = new Label();
            this.textBlock = new TextBox();
            this.label1 = new Label();
            this.textCamera = new TextBox();
            this.label4 = new Label();
            this.textRoute = new TextBox();
            this.label5 = new Label();
            this.dataGridView1 = new DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.button3.Location = new Point(0x60, 0x36);
            this.button3.Name = "button3";
            this.button3.Size = new Size(0x4b, 0x17);
            this.button3.TabIndex = 0x3a;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(this.button3_Click);
            this.button2.Location = new Point(15, 0x36);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 0x39;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.button2_Click);
            this.textIndex.Location = new Point(0xe3, 0x1c);
            this.textIndex.Name = "textIndex";
            this.textIndex.Size = new Size(0x79, 20);
            this.textIndex.TabIndex = 0x37;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xe0, 12);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x21, 13);
            this.label3.TabIndex = 0x36;
            this.label3.Text = "Index";
            this.textFloor.Location = new Point(0x79, 0x1c);
            this.textFloor.Name = "textFloor";
            this.textFloor.Size = new Size(100, 20);
            this.textFloor.TabIndex = 0x35;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x76, 12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(30, 13);
            this.label2.TabIndex = 0x34;
            this.label2.Text = "Floor";
            this.textBlock.Location = new Point(15, 0x1c);
            this.textBlock.Name = "textBlock";
            this.textBlock.Size = new Size(100, 20);
            this.textBlock.TabIndex = 0x33;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x22, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Block";
            this.textCamera.Location = new Point(0x34d, 0x1c);
            this.textCamera.Name = "textCamera";
            this.textCamera.Size = new Size(0xae, 20);
            this.textCamera.TabIndex = 0x3e;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x34a, 12);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x2b, 13);
            this.label4.TabIndex = 0x3d;
            this.label4.Text = "Camera";
            this.textRoute.Location = new Point(0x162, 0x1c);
            this.textRoute.Name = "textRoute";
            this.textRoute.Size = new Size(0x1e5, 20);
            this.textRoute.TabIndex = 60;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x15f, 12);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x24, 13);
            this.label5.TabIndex = 0x3b;
            this.label5.Text = "Route";
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(15, 0x53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x3ec, 0x1be);
            this.dataGridView1.TabIndex = 0x3f;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x407, 0x215);
            base.Controls.Add(this.dataGridView1);
            base.Controls.Add(this.textCamera);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.textRoute);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.textIndex);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.textFloor);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.textBlock);
            base.Controls.Add(this.label1);
            base.Name = "officeManager";
            this.Text = "officeManager";
            base.Load += new EventHandler(this.officeManager_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void officeManager_Load(object sender, EventArgs e)
        {
            this.initDatagirdView();
            this.timer1.Start();
        }

        public void sendFile(string IP)
        {
            if ((this.textRoute.Text != null) && (this.textRoute.Text != ""))
            {
                try
                {
                    Console.WriteLine("add new !!!!!!!!!!!!");
                    this.currentID = "b" + this.textBlock.Text + this.textFloor.Text + this.textIndex.Text;
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.WriteLine(0);
                    writer.Flush();
                    writer.WriteLine("addNewOffice");
                    writer.Flush();
                    writer.WriteLine(this.textRoute.Text);
                    writer.Flush();
                    writer.WriteLine(this.currentID);
                    writer.Flush();
                    writer.WriteLine(this.textCamera.Text);
                    writer.Flush();
                    writer.WriteLine(0);
                    writer.Flush();
                    Thread.Sleep(300);
                    Console.WriteLine("finished add new office!");
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
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/newoffice/routes").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string str3 = strArray2[0];
                            string[] values = new string[] { str3[1].ToString(), str3[2].ToString(), str3.Substring(3), strArray2[1], strArray2[2] };
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

