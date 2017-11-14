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

    public class eventManager : Form
    {
        private Button addEvnt;
        private Button chosseFile;
        private IContainer components;
        private string currentID;
        private DataGridView dataGridView1;
        private DataSet dataSetEvent = new DataSet();
        private DataTable dataTableEvents = new DataTable();
        private TextBox dateTimeTxt;
        private Button deleteEvnt;
        private TextBox descriptionTxt;
        private string fileName;
        private bool first = true;
        private const string imageType = ".png";
        private Label label1;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private TextBox titleTxt;
        private const string videoType = ".avi";

        public eventManager()
        {
            this.InitializeComponent();
        }

        private void addEvnt_Click(object sender, EventArgs e)
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

        private void chosseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.fileName = dialog.FileName;
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
                this.currentID = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                this.titleTxt.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                this.dateTimeTxt.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                this.descriptionTxt.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void deleteEvnt_Click(object sender, EventArgs e)
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

        public void deleteFile(string IP)
        {
            try
            {
                TcpClient client = new TcpClient(IP, 1752);
                Console.WriteLine("delete file!!.");
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("deleteEvents");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine("0");
                writer.Flush();
                writer.WriteLine(this.currentID);
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

        private void eventManager_Load(object sender, EventArgs e)
        {
            this.initDatagirdView();
            this.timer1.Start();
        }

        public void initDatagirdView()
        {
            this.dataTableEvents.Columns.Add("ID", typeof(string));
            this.dataTableEvents.Columns.Add("TITLE", typeof(string));
            this.dataTableEvents.Columns.Add("DATETIME", typeof(string));
            this.dataTableEvents.Columns.Add("DESCRIPTION", typeof(string));
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.dataGridView1 = new DataGridView();
            this.titleTxt = new TextBox();
            this.label1 = new Label();
            this.dateTimeTxt = new TextBox();
            this.label2 = new Label();
            this.descriptionTxt = new TextBox();
            this.label3 = new Label();
            this.chosseFile = new Button();
            this.addEvnt = new Button();
            this.deleteEvnt = new Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(12, 0xbd);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new Size(0x38d, 0x128);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.titleTxt.Location = new Point(12, 0x31);
            this.titleTxt.Name = "titleTxt";
            this.titleTxt.Size = new Size(100, 20);
            this.titleTxt.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x33, 0x21);
            this.label1.Name = "label1";
            this.label1.Size = new Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            this.label1.Click += new EventHandler(this.label1_Click);
            this.dateTimeTxt.Location = new Point(0x97, 0x31);
            this.dateTimeTxt.Name = "dateTimeTxt";
            this.dateTimeTxt.Size = new Size(100, 20);
            this.dateTimeTxt.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xae, 0x21);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x3b, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date Time:";
            this.descriptionTxt.Location = new Point(0x12f, 0x31);
            this.descriptionTxt.Multiline = true;
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new Size(0x1c4, 0x86);
            this.descriptionTxt.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(320, 0x21);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x5e, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Event Description:";
            this.chosseFile.Location = new Point(0x2f9, 0x31);
            this.chosseFile.Name = "chosseFile";
            this.chosseFile.Size = new Size(0x4b, 0x17);
            this.chosseFile.TabIndex = 7;
            this.chosseFile.Text = "Choose File";
            this.chosseFile.UseVisualStyleBackColor = true;
            this.chosseFile.Click += new EventHandler(this.chosseFile_Click);
            this.addEvnt.Location = new Point(0x34e, 0x31);
            this.addEvnt.Name = "addEvnt";
            this.addEvnt.Size = new Size(0x4b, 0x17);
            this.addEvnt.TabIndex = 8;
            this.addEvnt.Text = "Add";
            this.addEvnt.UseVisualStyleBackColor = true;
            this.addEvnt.Click += new EventHandler(this.addEvnt_Click);
            this.deleteEvnt.Location = new Point(0x324, 90);
            this.deleteEvnt.Name = "deleteEvnt";
            this.deleteEvnt.Size = new Size(0x4b, 0x17);
            this.deleteEvnt.TabIndex = 9;
            this.deleteEvnt.Text = "Delete";
            this.deleteEvnt.UseVisualStyleBackColor = true;
            this.deleteEvnt.Click += new EventHandler(this.deleteEvnt_Click);
            this.timer1.Interval = 0x3e8;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x3a5, 0x1f1);
            base.Controls.Add(this.deleteEvnt);
            base.Controls.Add(this.addEvnt);
            base.Controls.Add(this.chosseFile);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.descriptionTxt);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.dateTimeTxt);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.titleTxt);
            base.Controls.Add(this.dataGridView1);
            base.Name = "eventManager";
            this.Text = "eventManager";
            base.Load += new EventHandler(this.eventManager_Load);
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void sendFile(string IP)
        {
            if (this.fileName != null)
            {
                try
                {
                    if ((this.currentID == "") || (this.currentID == null))
                    {
                        this.currentID = DateTime.Now.ToString().Replace(" ", null).Replace("/", null).Replace(":", null) + ".png";
                    }
                    Console.WriteLine("File name:" + this.fileName);
                    TcpClient client = new TcpClient(IP, 1752);
                    Console.WriteLine("Connected. Sending file.");
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    byte[] buffer = System.IO.File.ReadAllBytes(this.fileName);
                    writer.WriteLine(buffer.Length.ToString());
                    writer.Flush();
                    writer.WriteLine("addForEvents");
                    writer.Flush();
                    writer.WriteLine(this.toSafeString(this.titleTxt.Text));
                    writer.Flush();
                    writer.WriteLine(this.toSafeString(this.dateTimeTxt.Text));
                    writer.Flush();
                    writer.WriteLine(this.toSafeString(this.descriptionTxt.Text));
                    writer.Flush();
                    writer.WriteLine(this.currentID);
                    writer.Flush();
                    Thread.Sleep(300);
                    Console.WriteLine("Sending file");
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
                foreach (string str2 in client.DownloadString("http://" + IP + ":8080/event/infomation").Split(new string[] { ":" }, StringSplitOptions.None))
                {
                    if (str2 != "")
                    {
                        try
                        {
                            string[] strArray2 = str2.Split(new string[] { " " }, StringSplitOptions.None);
                            string[] values = new string[] { strArray2[0], this.convertToUtf8(this.toNormalString(strArray2[1])), this.convertToUtf8(this.toNormalString(strArray2[2])), this.convertToUtf8(this.toNormalString(strArray2[3])) };
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

