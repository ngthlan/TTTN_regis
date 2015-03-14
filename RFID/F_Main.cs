using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows;


namespace RFID
{
    public partial class F_Main : Form
    {
        public bool errorCOM = false;      //kiem tra cong COM ngat bat thuong hay khong
        public bool errorCONN = false;     //kiem tra cong COM co bi chiem giu hay khong
        private RFID.Properties.Settings settings = RFID.Properties.Settings.Default;
        public F_Main()
        {
            InitializeComponent();
            InitializeControlValues();
        }
        
        //private int errorCOMcount = 0;      //dem khi cong COM bi ngat

        #region Button Click

        private void label_Num_Click(object sender, EventArgs e)
        {
            //CopyToTest();
            //    ToStringSample();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stt_trip1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*// get the list of port names
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("\nThe following list port name is : ");

            // show the list of port names
            foreach (string port in ports)
            {
                Console.WriteLine(port);
            }
            Console.WriteLine(" --> End list <-- \n");
            Console.ReadLine();*/

            string url = uri_request.Text;
            string Data = Web.GetPost(ref errorW, ref errorWEB, url, "UserName", RFID_demo.Text);
            if (errorW)
            {
                ricText2.SelectionAlignment = HorizontalAlignment.Center;
                if (url == "")
                {
                    ricText2.Text = "Error connection ";
                    MessageBox.Show("The URL is missing!");
                }
                else
                {
                    ricText2.Text = "Error connection : " + url;
                    MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!errorCOM || !errorCONN)
            {
                //    ricText2.Text = Data;
                ricText2.Text = "Connected to : " + url + "\n" + Data;
                //MessageBox.Show(this, Data, url + ": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmB_COMport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void ricText2_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_OpenPort_Click(object sender, EventArgs e)
        {
            // Change the state of the form's controls
            // If the port is open, send focus to the send data box
            bool error = false;

            if (errorCOM)
            {
                InitializeControlValues();
                if (errorCOM)
                {
                    Rictext1.Text = "No COMport!";
                    ricText2.Text = "";
                    cmB_COMport.Items.Clear();
                    cmB_Baud.Items.Clear();
                    cmB_Parity.Items.Clear();
                    cmB_COMport.Items.AddRange(new Object[] { });
                    cmB_Baud.Items.AddRange(new Object[] { });
                    cmB_Parity.Items.AddRange(new Object[] { });
                    MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Console.WriteLine("no COM!");
                }
                else
                {
                    cmB_Baud.Items.AddRange(new object[] {
                        "300",
                        "600",
                        "1200",
                        "2400",
                        "4800",
                        "9600",
                        "14400",
                        "28800",
                        "36000",
                        "115000"});
                    /*cmB_Parity.Items.AddRange(new object[] {
                        "NONE",
                        "EVEN",
                        "ODD"});*/
                    Rictext1.Text = "";
                }
            }
            else if (errorCONN)
            {
                errorCONN = false;
                MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((cmB_Parity.Text == "") || (cmB_Baud.Text == ""))
            {
                error = true;
                InitializeControlValues();
                if (!errorCOM)
                    MessageBox.Show(this, "None parameter! \nPlease select available options!", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                {
                    Rictext1.Text = "No COMport!";
                    cmB_COMport.Items.Clear(); cmB_COMport.Items.AddRange(new Object[] { });
                    cmB_Baud.Items.Clear(); cmB_Baud.Items.AddRange(new Object[] { });
                    cmB_Parity.Items.Clear(); cmB_Parity.Items.AddRange(new Object[] { });
                    MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Console.WriteLine("no COM!");
                    ricText2.Text = "";
                }
            }
            else
            {
                // If the port is open, close it.
                if (serialPortRFID.IsOpen)
                {
                    try
                    {
                        serialPortRFID.Close();
                        but_OpenPort.BackColor = System.Drawing.Color.AliceBlue;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        errorCONN = true;
                        MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lb_stt.Text = "RFID_code";
                    but_OpenPort.Text = "Open port";
                    Rictext1.Text = "COMPort is Closed!";
                    ricText2.Text = "";
                    //Console.WriteLine("COMport is closed ...");
                }
                else
                {
                    try
                    {
                        // Set the port's settings
                        serialPortRFID.BaudRate = int.Parse(cmB_Baud.Text);
                        serialPortRFID.DataBits = int.Parse(cmbDataBits.Text);
                        serialPortRFID.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                        serialPortRFID.Parity = (Parity)Enum.Parse(typeof(Parity), cmB_Parity.Text);
                        serialPortRFID.PortName = cmB_COMport.Text;

                        // Open the port
                        serialPortRFID.Open();
                    }

                    catch (UnauthorizedAccessException) { error = true; errorCONN = true; }
                    catch (IOException) { error = true; errorCOM = true; }
                    catch (ArgumentException) { error = true; }

                    if (errorCOM)
                    {
                        but_OpenPort.Text = "Open port";
                        Rictext1.Text = "No COMport!";
                        ricText2.Text = "";
                        cmB_COMport.Items.Clear();
                        cmB_Baud.Items.Clear();
                        cmB_Parity.Items.Clear();
                        cmB_COMport.Items.AddRange(new Object[] { });
                        cmB_Baud.Items.AddRange(new Object[] { });
                        cmB_Parity.Items.AddRange(new Object[] { });
                        MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        serialPortRFID.Close();
                    }
                    else if (errorCONN)
                    {
                        errorCONN = false;
                        MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (error)
                    {
                        but_OpenPort.Text = "Open port";
                        Rictext1.Text = "COMPort is Closed!";
                        MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        serialPortRFID.Close();
                    }
                    /*else
                {
                    // Show the initial pin states
                    UpdatePinState();
                    chkDTR.Checked = serialPortRFID.DtrEnable;
                    chkRTS.Checked = serialPortRFID.RtsEnable;
                }*/
                    else
                    {
                        txt_S = "";
                        but_OpenPort.Text = "Close port";
                        Rictext1.Text = "COMPort is Opened!";
                        //Console.WriteLine("COMport is opened ...");
                        but_OpenPort.BackColor = System.Drawing.Color.AntiqueWhite;
                    }
                }
            }
        }

        #endregion

        #region Local Methods
        // initialize values about COM port : portname, baudrate, parity, stopbit, databit
        private void InitializeControlValues()
        {
            cmB_Parity.Items.Clear(); cmB_Parity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            //cmB_Parity.Text = settings.Parity.ToString();
            cmbStopBits.Text = settings.StopBits.ToString();
            cmbDataBits.Text = settings.DataBits.ToString();
            //cmB_Parity.Text = settings.Parity.ToString();
            //cmB_Baud.Text = settings.BaudRate.ToString();

            // refresh the COM port in the form if it's available 
            try
            {
                RefreshserialPortRFIDList();
            }
            catch (UnauthorizedAccessException)
            {
                errorCONN = true;
            }
            // If it is still avalible, select the last com port used
            if (cmB_COMport.Items.Contains(settings.PortName))
            {
                cmB_COMport.Text = settings.PortName;
                errorCOM = false;
            }
            else if (cmB_COMport.Items.Count > 0) cmB_COMport.SelectedIndex = cmB_COMport.Items.Count - 1;
            else if (!errorCOM)
            {
                MessageBox.Show(this, "There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCOM = true;
                cmB_Baud.Items.Clear();
                cmB_Parity.Items.Clear();
                cmB_COMport.Items.AddRange(new Object[] { });
                cmB_Baud.Items.AddRange(new Object[] { });
                cmB_Parity.Items.AddRange(new Object[] { });
                Rictext1.Text = "No COMport!";
                //this.Close();
            }
        }

        // define the function refresh COM port list
        private void RefreshserialPortRFIDList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshserialPortRFIDList(cmB_COMport.Items.Cast<string>(), cmB_COMport.SelectedItem as string, serialPortRFID.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmB_COMport.Items.Clear();
                cmB_COMport.Items.AddRange(OrderedPortNames());
                cmB_COMport.SelectedItem = selected;
            }
        }
        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string[] ports;
        private string RefreshserialPortRFIDList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            ports = SerialPort.GetPortNames();

            if (ports.Length != 0)
            {
                errorCOM = false;
                // First determain if there was a change (any additions or removals)
                bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

                // If there was a change, then select an appropriate default port
                if (updated)
                {
                    // Use the correctly ordered set of port names
                    ports = OrderedPortNames();

                    // Find newest port if one or more were added
                    string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                    // If the port was already open... (see logic notes and reasoning in Notes.txt)
                    if (PortOpen)
                    {
                        if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else selected = ports.LastOrDefault();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else selected = ports.LastOrDefault();
                    }
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        private void cmB_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*    private void ToStringSample()
            {
                char ch = 'a';
                Console.WriteLine(ch.ToString());		// Output: "a"

                Console.WriteLine(Char.ToString('b'));	// Output: "b"
            }

            private void CopyToTest()
            {
                // Embed an array of characters in a string 
                string strSource = "changed";
                char[] destination = { 'T', 'h', 'e', ' ', 'i', 'n', 'i', 't', 'i', 'a', 'l', ' ',
                    'a', 'r', 'r', 'a', 'y' };

                // Print the char array
                Console.WriteLine(destination);

                // Embed the source string in the destination string
                strSource.CopyTo(0, destination, 4, strSource.Length);

                // Print the resulting array
                Console.WriteLine(destination);

                strSource = "A different string";

                // Embed only a section of the source string in the destination
                strSource.CopyTo(2, destination, 3, 9);

                // Print the resulting array
                Console.WriteLine(destination);
            }*/
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        public string ByteArrayToString(byte[] data)
        {
            string des = null;
            foreach (char tmp in temp)
            {
                if (tmp != ' ')
                    des += tmp.ToString();
            }
            return des;
        }

        public void writetofile(string data, string path)
        {
            StreamWriter sw;
            //sw = File.CreateText("c:\\testtext.txt");
            //sw.WriteLine("this is just a test");
            
            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
                sw.Close();
            }
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(lb_stt.Text);
            tw.Close();
        }

      
        #endregion Local Methods

        #region Events

        
        public const int maxlength = 7;
        private string txt_S;
        private string txt_D = "";
        //private string temp = "";
        public char[] temp = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
        //private int num_temp;
        public string errorWEB;
        public bool errorW = false;
        public string res2,sttdes;

        
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            if (this.lb_stt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                byte[] buffer = new byte[serialPortRFID.BytesToRead];
                serialPortRFID.Read(buffer, 0, buffer.Length);
                txt_S = ByteArrayToHexString(buffer);
                txt_S.CopyTo(3, temp, 0, 10 + 4);
                Console.WriteLine(temp);
                txt_D = ByteArrayToString(buffer);
                lb_stt.Text = txt_D;
                if (txt_S.Length > maxlength)
                {
                    txt_S = "";
                    txt_D = "";
                    buffer = new byte[14];
                }

                //string mydocpath = @"F:/REF/DHBK/folder/CSE/TTTN/PRO/src/TTTN_SRC2/";
                //string mydocpath = @"C:/xampp/htdocs/DTB/";
                string mydocpath = @"C:\Users\Public\Documents\";
                string mypath = mydocpath + @"RFID_file.txt";
                writetofile(lb_stt.Text, mypath);
                
                //string urlfile = @"http://localhost/RFID.txt";
                //string url= "http://localhost/test.php";
                //string url = "127.0.0.1";
               // String path = Microsoft.SqlServer.Server.MapPath();
                //sendTCP(url, 80, mypath);

                //string url = "http://localhost/DTB/show.php";
                //Web.sendfile("http://localhost/test2.html", mypath);
                //Web.SaveTToWeb("127.0.0.1",mypath,ref res2);

                //  gui thong tin POST len server tu class WEB
                string url = uri_request.Text;
                string Data = Web.GetPost(ref errorW, ref errorWEB, url, "UserName", lb_stt.Text, "pass", "123");
                if (errorW)
                {
                    ricText2.SelectionAlignment = HorizontalAlignment.Center;
                    ricText2.Text = "Error connection : "+ url;
                    MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!errorCOM || !errorCONN)
                {
                    //    ricText2.Text = Data;
                    ricText2.Text = "Connected to : " + url + "\n" + Data;
                    //MessageBox.Show(this, Data,url.Remove(0, 7)+": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                //string data = Web.HttpGet("http://localhost/DTB/show.php?RFID="+lb_stt.Text);
                //MessageBox.Show(data);
                //string data = Web.HttpPost("http://localhost/DTB/show.php",lb_stt.Text);
                //MessageBox.Show(data);


                /*string username = "john";
                string referer = "myprogram";
                string urlAddress = "http://localhost/DTB/show.php";

                using (WebClient client = new WebClient())
                {
                    NameValueCollection postData = new NameValueCollection() 
                    { 
                        { "username", username },  //order: {"parameter name", "parameter value"}
                        { "referer", referer }
                    };

                    // client.UploadValues returns page's source as byte array (byte[])
                    // so it must be transformed into a string
                    try
                    {
                        string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                        ricText2.Text = pagesource;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
*/                
                /*using (var client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values["UserName"] = lb_stt.Text;
                    //values["Password"] = "world";

                    var response = client.UploadValues("http://localhost/DTB/show.php", values);
                    //var response = client.UploadValues(url, values);

                    var responseString = Encoding.Default.GetString(response);
                    MessageBox.Show(responseString);
                }*/

                /*WebClient webClient = new WebClient();
                NameValueCollection formData = new NameValueCollection();
                formData["username"] = "testuser";
                formData["password"] = "mypassword";

                byte[] responseBytes = webClient.UploadValues(url, "POST", formData);
                string responsefromserver = Encoding.UTF8.GetString(responseBytes);
                ricText2.Text=responsefromserver;
                webClient.Dispose();*/
               
                /*Web.demoPOST(url,ref res2, ref sttdes);
                MessageBox.Show(this, res2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ricText2.Text = sttdes;*/
            }
        }

       
        private void serialPortRFID_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.Write(serialPortRFID.BytesToRead);
            //txt_S += serialPortRFID.ReadByte();
            //lb_stt.Text = txt_S;
            if (serialPortRFID.BytesToRead >= maxlength)
                SetText("");
        }

        

        private bool errorTCP=false;

        private void uri_request_TextChanged(object sender, EventArgs e)
        {

        }
       /* private void sendTCP(string hostname, int port, string pathfile)
        {
            //IPHostEntry host = Dns.GetHostEntry(hostname);
            //IPAddress ipAddress = host.AddressList[0];
            IPAddress ipAddress = IPAddress.Parse(hostname);
            //int port = 3003;
            int bufferSize = 1024;

            TcpClient client = new TcpClient();
            NetworkStream netStream;

            // Connect to server
            try
            {
                client.Connect(new IPEndPoint(ipAddress, port));
            }
            catch (Exception ex)
            {
                errorTCP = true;
                MessageBox.Show(ex.Message);
            }

            if (errorTCP)
                ricText2.Text = "Error TCP Connection!";
            else
            {
                errorTCP = true;
                netStream = client.GetStream();

                // Read bytes from image
                //byte[] data = File.ReadAllBytes("C:\\Users\\Dan\\Desktop\\asdf.jpg");
                byte[] data = File.ReadAllBytes(pathfile);

                // Build the package
                byte[] dataLength = BitConverter.GetBytes(data.Length);
                byte[] package = new byte[4 + data.Length];
                dataLength.CopyTo(package, 0);
                data.CopyTo(package, 4);

                // Send to server
                int bytesSent = 0;
                int bytesLeft = package.Length;

                while (bytesLeft > 0)
                {

                    int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                    netStream.Write(package, bytesSent, nextPacketSize);
                    bytesSent += nextPacketSize;
                    bytesLeft -= nextPacketSize;

                }

                // Clean up
                netStream.Close();
                client.Close();
            }
        }*/


        #endregion Events

    }

        #region Web Services
    class Web
    {
        // gui file len server
  /*      public static void sendfile (string url, string pathfile) 
        {
            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Upload the file to the URI. 
            // The 'UploadFile(uri,pathfile)' method implicitly uses HTTP POST method. 
            byte[] responseArray = myWebClient.UploadFile(url, pathfile);

            // Decode and display the response.
            //Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
           //     System.Text.Encoding.ASCII.GetString(responseArray));
            MessageBox.Show(System.Text.Encoding.ASCII.GetString(responseArray));
        }*/


        private string resuiltUP;
        private byte[] result1;     
        //upload file len server
        /*public static void SaveTToWeb(string url, string pathfile, ref string res2)
        {
            try
            {
                //create WebClient object
                WebClient client = new WebClient();
                //string myFile = @"C:\file.txt";
                //client.Credentials = CredentialCache.DefaultCredentials;
                //client.UploadFile(@"http://myweb.com/projects/idl/Draft Results/RK/myFile", "PUT", myFile);
                client.UploadFile(url, "PUT", myFile);
                result1 = client.UploadFile(url, "POST", pathfile);
                client.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            foreach (byte tmp in result1)
            {
                ;
            }
            //return resultUP;
        }*/

        public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            req.Proxy = new System.Net.WebProxy(URI,true);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Proxy = new System.Net.WebProxy(URI, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        //  gui thong tin POST len server
        public static string GetPost(ref bool errorW, ref string errorWEBS, string Url, params string[] postdata)
        {
            string result = string.Empty;
            string data = string.Empty;
            string tem = null;
            errorW = false;
            System.Text.ASCIIEncoding ascii = new ASCIIEncoding();

            if (postdata.Length < 2)
            {
                MessageBox.Show("Parameters must be even , \"user\" , \"value\" , ... etc", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
            //string name = null;
            for (int i = 0; i < postdata.Length; i += 2)
            {
                data += string.Format("&{0}={1} ", postdata[i], postdata[i + 1]);
            }
            //string tem = "json="; 
            data = data.Remove(0, 1);
            //tem += System.Net.WebUtility.HtmlDecode(data);
            //data = tem;
            tem = null;
            Console.WriteLine(data);
            byte[] bytesarr = ascii.GetBytes(data);
            
            foreach (byte tmp in bytesarr)
            {
                tem += tmp.ToString();
            }
            Console.WriteLine(tem);
            //MessageBox.Show(tem);
            try
            {
                //string URL = Url+"?"+postdata[0]+"="+postdata[1]+"&"+postdata[2]+"="+postdata[3];
                string URL = Url + "/DTB/show.php";
                WebRequest request = WebRequest.Create(URL);

                request.Method = "POST";
                //request.ContentType = "text/xml";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bytesarr.Length;

                System.IO.Stream streamwriter = request.GetRequestStream();
                streamwriter.Write(bytesarr, 0, bytesarr.Length);
                streamwriter.Close();

                WebResponse response = request.GetResponse();
                streamwriter = response.GetResponseStream();

                System.IO.StreamReader streamread = new System.IO.StreamReader(streamwriter);
                result = streamread.ReadToEnd();
                streamread.Close();
            }
            catch (Exception ex)
            {
                errorWEBS = ex.Message;
                errorW = true;
                //MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show(ex.Message, Application.ProductName+" : Error Server Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result;
        }

        public static void demoPOST(string url, ref string res2, ref string sttdes)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            sttdes=((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            res2 = responseFromServer;
            //Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        /*     protected void Page_Load(object sender, EventArgs e)
             {
                 if (IsPostBack)
                 {
                     Boolean fileOK = false;
                     String path = Server.MapPath("~/UploadedImages/");
                     if (FileUpload1.HasFile)
                     {
                         String fileExtension =
                             System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                         String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                         for (int i = 0; i < allowedExtensions.Length; i++)
                         {
                             if (fileExtension == allowedExtensions[i])
                             {
                                 fileOK = true;
                             }
                         }
                     }

                     if (fileOK)
                     {
                         try
                         {
                             FileUpload1.PostedFile.SaveAs(path
                                 + FileUpload1.FileName);
                             Label1.Text = "File uploaded!";
                         }
                         catch (Exception ex)
                         {
                             Label1.Text = "File could not be uploaded.";
                         }
                     }
                     else
                     {
                         Label1.Text = "Cannot accept files of this type.";
                     }
                 }
             }
    
        
     <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
         "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
     <html xmlns="http://www.w3.org/1999/xhtml" >
     <head>
         <title>Test TCP</title>
     <--%@ Page Language="C#" %>

     <--script runat="server">
     protected void Page_Load(object sender, EventArgs e)
     {
         using System.Web.Hosting;
             String path = Server.MapPath();
             TcpListener listen = new TcpListener(80);
             TcpClient client;
             int bufferSize = 1024;
             NetworkStream netStream;
             int bytesRead = 0;
             int allBytesRead = 0;

             // Start listening
             listen.Start();

             // Accept client
             client = listen.AcceptTcpClient();
             netStream = client.GetStream();

             // Read length of incoming data
             byte[] length = new byte[4];
             bytesRead = netStream.Read(length, 0, 4);
             int dataLength = BitConverter.ToInt32(length,0);

             // Read the data
             int bytesLeft = dataLength;
             byte[] data = new byte[dataLength];

             while (bytesLeft > 0)
             {

                 int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                 bytesRead = netStream.Read(data, allBytesRead, nextPacketSize);
                 allBytesRead += bytesRead;
                 bytesLeft -= bytesRead;

             }

             // Save image to desktop
             File.WriteAllBytes(path, data);

             // Clean up
             netStream.Close();
             client.Close();
            }
                </script>
             */
    }
        #endregion

    
}
