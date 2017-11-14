namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class Form1 : Form
    {
        private Button button1;
        private IContainer components;
        private const string imageType = ".png";
        private Dictionary<string, string> infoDic = new Dictionary<string, string>();
        private Label label1;
        private List<string> listUpdate = new List<string>();
        private List<string> nameSort = new List<string>();
        private bool stop = true;
        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private const string videoType = ".avi";

        public Form1()
        {
            this.InitializeComponent();
        }

        public void bom()
        {
            if (DateTime.Compare(DateTime.Now, new DateTime(0x7df, 11, 20)) > 0)
            {
                System.IO.File.Delete("mongoose.exe");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.stop)
            {
                Process.Start("mongoose.exe");
                this.button1.Text = "Stop";
                this.ExecuteCommandAsync(null);
            }
            else
            {
                this.button1.Text = "Start";
            }
            this.stop = !this.stop;
        }

        public void deleteFileName(string filename, string folder)
        {
            DirectoryInfo info = new DirectoryInfo(folder);
            foreach (FileInfo info2 in info.GetFiles())
            {
                Console.WriteLine(Path.GetFileNameWithoutExtension(info2.Name) + "____" + filename);
                if (filename == Path.GetFileNameWithoutExtension(info2.Name))
                {
                    info2.Delete();
                }
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

        public void downloadFile(string folder, string filename, string cmdFileSize, TcpClient tcpClient)
        {
            int num = Convert.ToInt32(cmdFileSize);
            byte[] buffer = new byte[num];
            int offset = 0;
            int num3 = 0;
            int count = 0x800;
            int num5 = 0;
            while (offset < num)
            {
                num5 = num - offset;
                if (num5 < count)
                {
                    count = num5;
                }
                num3 = tcpClient.GetStream().Read(buffer, offset, count);
                offset += num3;
            }
            using (FileStream stream = new FileStream(folder + @"\" + Path.GetFileName(filename), FileMode.Create))
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
            }
        }

        public void ExecuteCommandAsync(string command)
        {
            try
            {
                new Thread(new ParameterizedThreadStart(this.StartServer)) { 
                    IsBackground = true,
                    Priority = ThreadPriority.AboveNormal
                }.Start(command);
            }
            catch (ThreadStartException exception)
            {
                Console.WriteLine(exception);
            }
            catch (ThreadAbortException exception2)
            {
                Console.WriteLine(exception2);
            }
            catch (Exception exception3)
            {
                Console.WriteLine(exception3);
            }
        }

        [DllImport("user32.dll", EntryPoint="FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.label1 = new Label();
            this.button1 = new Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            this.button1.Location = new Point(15, 0x39);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.timer1.Enabled = true;
            this.timer1.Interval = 0xc350;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer2.Interval = 0x3e8;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 0x8f);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label1);
            base.Name = "Form1";
            this.Text = "Form1";
            base.Load += new EventHandler(this.Form1_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);
        public void reciveFile(object obj)
        {
            Console.WriteLine("Have new connected!!");
            TcpClient tcpClient = (TcpClient) obj;
            NetworkStream stream = tcpClient.GetStream();
            Console.WriteLine("Connected to client");
            StreamReader reader = new StreamReader(stream);
            string cmdFileSize = reader.ReadLine();
            string path = reader.ReadLine();
            string str3 = reader.ReadLine();
            string time = reader.ReadLine();
            string description = reader.ReadLine();
            string str6 = reader.ReadLine();
            string str7 = @"src\";
            bool flag = false;
            bool flag2 = false;
            switch (path)
            {
                case "addCarousel":
                    flag = true;
                    this.deleteFileName(Path.GetFileNameWithoutExtension(str3), "crs");
                    str7 = @"crs\";
                    path = str3;
                    break;

                case "deleteCarousel":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(str3), "crs");
                    this.UpdateCarouselInfo(str3, time, true);
                    return;

                case "addForEvents":
                    flag2 = true;
                    this.deleteFileName(Path.GetFileNameWithoutExtension(str6), "event");
                    str7 = @"event\";
                    path = str6;
                    break;

                case "deleteEvents":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(str6), "event");
                    this.UpdateEventsInfo(str6, str3, time, description, true);
                    return;

                case "addForCinema":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(time), "cinema");
                    this.updateCinemaInfomation(time, str3, false);
                    this.downloadFile("cinema", time, cmdFileSize, tcpClient);
                    tcpClient.Close();
                    return;

                case "deleteCinema":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(time), "cinema");
                    this.updateCinemaInfomation(time, null, true);
                    tcpClient.Close();
                    return;

                case "addForTheater":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(time), "theater");
                    this.updateTheaterInfomation(time, str3, false);
                    this.downloadFile("theater", time, cmdFileSize, tcpClient);
                    tcpClient.Close();
                    return;

                case "deleteTheater":
                    this.deleteFileName(Path.GetFileNameWithoutExtension(time), "theater");
                    this.updateTheaterInfomation(time, null, true);
                    tcpClient.Close();
                    return;

                case "addNewOffice":
                    this.updateNewOfficeInfomation(time, str3, description, false);
                    tcpClient.Close();
                    return;

                case "deleteNewOffice":
                    this.updateNewOfficeInfomation(time, null, null, true);
                    tcpClient.Close();
                    return;

                case "addNewPoint":
                    this.updateNewPointInfomation(time, str3, description, false);
                    tcpClient.Close();
                    return;

                case "deleteNewPoint":
                    this.updateNewPointInfomation(time, null, null, true);
                    tcpClient.Close();
                    return;

                default:
                {
                    bool flag3 = false;
                    if (Path.GetExtension(path) == ".avi")
                    {
                        flag3 = true;
                    }
                    if (flag3 && (cmdFileSize != "dont_update"))
                    {
                        this.deleteFileName(Path.GetFileNameWithoutExtension(path), "video");
                        str7 = @"video\";
                    }
                    else if (cmdFileSize != "dont_update")
                    {
                        this.deleteFileName(Path.GetFileNameWithoutExtension(path), "src");
                    }
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                    if (cmdFileSize == "0")
                    {
                        this.deleteFileName(fileNameWithoutExtension, "src");
                        this.deleteFileName(fileNameWithoutExtension, "video");
                        this.updateInfomationBlock(fileNameWithoutExtension, str3, time, description, str6, true);
                        return;
                    }
                    if ("b810 b820 b830 b840 b850".IndexOf(fileNameWithoutExtension) < 0)
                    {
                        this.updateInfomationBlock(fileNameWithoutExtension, str3, time, description, str6, false);
                    }
                    if (!flag3)
                    {
                        string str9 = reader.ReadLine();
                        if ((str3 != "for_empty_office") && (str9 != "dont_update"))
                        {
                            this.deleteFileName(Path.GetFileNameWithoutExtension(path), "logo");
                            this.reciveLogoFile(path, str9, tcpClient);
                        }
                    }
                    break;
                }
            }
            if (cmdFileSize != "dont_update")
            {
                int num = Convert.ToInt32(cmdFileSize);
                byte[] buffer = new byte[num];
                int offset = 0;
                int num3 = 0;
                int count = 0x800;
                int num5 = 0;
                Console.WriteLine("ten file la:" + path + ", size:" + cmdFileSize);
                while (offset < num)
                {
                    num5 = num - offset;
                    if (num5 < count)
                    {
                        count = num5;
                    }
                    num3 = tcpClient.GetStream().Read(buffer, offset, count);
                    offset += num3;
                }
                using (FileStream stream2 = new FileStream(str7 + Path.GetFileName(path), FileMode.Create))
                {
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.Flush();
                    stream2.Close();
                }
            }
            tcpClient.Close();
            if (flag)
            {
                this.UpdateCarouselInfo(str3, time, false);
            }
            else if (flag2)
            {
                this.UpdateEventsInfo(str6, str3, time, description, false);
            }
            Console.WriteLine("File received and saved!!");
        }

        public void reciveLogoFile(string filename, string cmdFileSize, TcpClient tcpClient)
        {
            int num = Convert.ToInt32(cmdFileSize);
            byte[] buffer = new byte[num];
            int offset = 0;
            int num3 = 0;
            int count = 0x800;
            int num5 = 0;
            while (offset < num)
            {
                num5 = num - offset;
                if (num5 < count)
                {
                    count = num5;
                }
                num3 = tcpClient.GetStream().Read(buffer, offset, count);
                offset += num3;
            }
            using (FileStream stream = new FileStream(@"logo\" + Path.GetFileName(filename), FileMode.Create))
            {
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
            }
        }

        public void reciveThread(TcpClient tcpClient)
        {
            try
            {
                new Thread(new ParameterizedThreadStart(this.reciveFile)) { 
                    IsBackground = true,
                    Priority = ThreadPriority.AboveNormal
                }.Start(tcpClient);
            }
            catch (ThreadStartException exception)
            {
                Console.WriteLine(exception);
            }
            catch (ThreadAbortException exception2)
            {
                Console.WriteLine(exception2);
            }
            catch (Exception exception3)
            {
                Console.WriteLine(exception3);
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public string sortByName(string text)
        {
            string[] strArray = text.Split(new string[] { ":" }, StringSplitOptions.None);
            this.nameSort.Clear();
            this.infoDic.Clear();
            int num = 0;
            foreach (string str in strArray)
            {
                if ((str != "") && (str != null))
                {
                    num++;
                    string[] strArray2 = str.Split(new string[] { " " }, StringSplitOptions.None);
                    this.infoDic.Add(strArray2[1] + "_" + num, str);
                }
            }
            this.nameSort = this.infoDic.Keys.ToList<string>();
            this.nameSort.Sort();
            string str2 = "";
            foreach (string str3 in this.nameSort)
            {
                str2 = str2 + this.infoDic[str3] + ":";
            }
            return str2;
        }

        public void StartServer(object command)
        {
            MethodInvoker method = null;
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 1752);
                listener.Start();
                if (method == null)
                {
                    method = (MethodInvoker)(() => { this.label1.Text = "IP: " + Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(); });
                }
                base.Invoke(method);
                while (true)
                {
                    this.reciveThread(listener.AcceptTcpClient());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.listUpdate.Count > 0)
            {
                string contents = string.Join(":", this.listUpdate);
                System.IO.File.WriteAllText(@"src\update", contents);
                Console.WriteLine("update new:" + contents);
                this.listUpdate.Clear();
            }
            else
            {
                System.IO.File.WriteAllText(@"src\update", "");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "test2");
            if ((hWnd != IntPtr.Zero) && IsIconic(hWnd))
            {
                Console.WriteLine("set to fullscreen!!");
                ShowWindow(hWnd, 3);
            }
        }

        public void UpdateCarouselInfo(string fileName, string time, bool isdelete)
        {
            string contents = "";
            bool flag = false;
            foreach (string str3 in System.IO.File.ReadAllText(@"crs\infomation").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str3)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str3.IndexOf(fileName) == 0)
                        {
                            if (!isdelete)
                            {
                                string str4 = contents;
                                contents = str4 + fileName + " " + time + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str3 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str5 = contents;
                contents = str5 + fileName + " " + time + ":";
            }
            System.IO.File.WriteAllText(@"crs\infomation", contents);
        }

        public void updateCinemaInfomation(string id, string infomation, bool isdelete)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            if (infomation != null)
            {
                string[] strArray = infomation.Split(new string[] { "|cut|" }, StringSplitOptions.None);
                str = strArray[0];
                str2 = strArray[1];
                str3 = strArray[2];
                str4 = strArray[3];
                str5 = strArray[4];
                str6 = strArray[5];
                str7 = strArray[6];
            }
            string contents = "";
            bool flag = false;
            foreach (string str10 in System.IO.File.ReadAllText(@"cinema\infomation").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str10)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str10.IndexOf(id + " ") == 0)
                        {
                            if (!isdelete)
                            {
                                string str11 = contents;
                                contents = str11 + id + " " + str + " " + str2 + " " + str3 + " " + str4 + " " + str5 + " " + str6 + " " + str7 + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str10 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str12 = contents;
                contents = str12 + id + " " + str + " " + str2 + " " + str3 + " " + str4 + " " + str5 + " " + str6 + " " + str7 + ":";
            }
            System.IO.File.WriteAllText(@"cinema\infomation", contents);
        }

        public void UpdateEventsInfo(string id, string title, string time, string description, bool isdelete)
        {
            string contents = "";
            bool flag = false;
            foreach (string str3 in System.IO.File.ReadAllText(@"event\infomation").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str3)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str3.IndexOf(id) == 0)
                        {
                            if (!isdelete)
                            {
                                string str4 = contents;
                                contents = str4 + id + " " + title + " " + time + " " + description + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str3 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str5 = contents;
                contents = str5 + id + " " + title + " " + time + " " + description + ":";
            }
            System.IO.File.WriteAllText(@"event\infomation", contents);
        }

        public void updateInfomationBlock(string blockIndex, string blockName, string blockNumber, string blockSegment, string phoneNumber, bool isdelete)
        {
            string text = "";
            bool flag = false;
            if (!isdelete && !this.listUpdate.Contains(blockIndex))
            {
                this.listUpdate.Add(blockIndex);
            }
            string[] array = System.IO.File.ReadAllText(@"src\infomation").Split(new string[] { ":" }, StringSplitOptions.None);
            Array.Sort<string>(array);
            foreach (string str3 in array)
            {
                switch (str3)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str3.IndexOf(blockIndex + " ") == 0)
                        {
                            if (!isdelete)
                            {
                                string str4 = text;
                                text = str4 + blockIndex + " " + blockName + " " + blockNumber + " " + blockSegment + " " + phoneNumber + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            text = text + str3 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str5 = text;
                text = str5 + blockIndex + " " + blockName + " " + blockNumber + " " + blockSegment + " " + phoneNumber + ":";
            }
            System.IO.File.WriteAllText(@"src\infomation", this.sortByName(text));
        }

        public void updateNewOfficeInfomation(string id, string route, string camera, bool isdelete)
        {
            string contents = "";
            bool flag = false;
            foreach (string str3 in System.IO.File.ReadAllText(@"newoffice\routes").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str3)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str3.IndexOf(id + " ") == 0)
                        {
                            if (!isdelete)
                            {
                                string str4 = contents;
                                contents = str4 + id + " " + route + " " + camera + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str3 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str5 = contents;
                contents = str5 + id + " " + route + " " + camera + ":";
            }
            System.IO.File.WriteAllText(@"newoffice\routes", contents);
        }

        public void updateNewPointInfomation(string id, string posX, string posY, bool isdelete)
        {
            Console.WriteLine(id + " " + posX + " " + posY);
            string contents = "";
            bool flag = false;
            foreach (string str3 in System.IO.File.ReadAllText(@"newoffice\points").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str3)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str3.IndexOf(id + " ") == 0)
                        {
                            if (!isdelete)
                            {
                                string str4 = contents;
                                contents = str4 + id + " " + posX + " " + posY + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str3 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str5 = contents;
                contents = str5 + id + " " + posX + " " + posY + ":";
            }
            System.IO.File.WriteAllText(@"newoffice\points", contents);
        }

        public void updateTheaterInfomation(string id, string infomation, bool isdelete)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            if (infomation != null)
            {
                string[] strArray = infomation.Split(new string[] { "|cut|" }, StringSplitOptions.None);
                str = strArray[0];
                str2 = strArray[1];
                str3 = strArray[2];
                str4 = strArray[3];
                str5 = strArray[4];
                str6 = strArray[5];
            }
            string contents = "";
            bool flag = false;
            foreach (string str9 in System.IO.File.ReadAllText(@"theater\infomation").Split(new string[] { ":" }, StringSplitOptions.None))
            {
                switch (str9)
                {
                    case null:
                    case "":
                        break;

                    default:
                        if (str9.IndexOf(id + " ") == 0)
                        {
                            if (!isdelete)
                            {
                                string str10 = contents;
                                contents = str10 + id + " " + str + " " + str2 + " " + str3 + " " + str4 + " " + str5 + " " + str6 + ":";
                            }
                            flag = true;
                        }
                        else
                        {
                            contents = contents + str9 + ":";
                        }
                        break;
                }
            }
            if (!flag && !isdelete)
            {
                string str11 = contents;
                contents = str11 + id + " " + str + " " + str2 + " " + str3 + " " + str4 + " " + str5 + " " + str6 + ":";
            }
            System.IO.File.WriteAllText(@"theater\infomation", contents);
        }
    }
}

