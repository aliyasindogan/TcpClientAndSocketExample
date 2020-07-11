using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpClientAndSocketExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtIPAddress.Text = Properties.Settings.Default["ipAddress"].ToString();
            txtFinishValue.Text = Properties.Settings.Default["finishValue"].ToString();
            txtPort.Text = Properties.Settings.Default["port"].ToString();
            txtSendData.Text = Properties.Settings.Default["sendData"].ToString();
            if (txtIPAddress.Text.Count() > 1)
                checkBoxRememberMe.Checked = true;
        }

        private void btnTcpClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtFinishValue.Text) &&
                    !String.IsNullOrEmpty(txtIPAddress.Text) &&
                    !String.IsNullOrEmpty(txtPort.Text) &&
                    !String.IsNullOrEmpty(txtSendData.Text))
                {
                    if (checkBoxRememberMe.Checked)
                    {
                        Properties.Settings.Default["ipAddress"] = txtIPAddress.Text;
                        Properties.Settings.Default["finishValue"] = txtFinishValue.Text;
                        Properties.Settings.Default["port"] = txtPort.Text;
                        Properties.Settings.Default["sendData"] = txtSendData.Text;
                    }
                    else
                    {
                        Properties.Settings.Default[""] = txtIPAddress.Text;
                        Properties.Settings.Default[""] = txtFinishValue.Text;
                        Properties.Settings.Default[""] = txtPort.Text;
                        Properties.Settings.Default[""] = txtSendData.Text;
                    }
                    Properties.Settings.Default.Save();

                    BaseRequest baseRequest = new BaseRequest()
                    {
                        FinishValue = txtFinishValue.Text,
                        IpAddress = txtIPAddress.Text,
                        TcpPort = Convert.ToInt32(txtPort.Text),
                        SendData = txtSendData.Text,
                    };
                    Task.Run(() =>
                    {
                        label1.Text = TcpClientSendAndGet(baseRequest, listBoxData);
                    });
                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSocket_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtFinishValue.Text) &&
                    !String.IsNullOrEmpty(txtIPAddress.Text) &&
                    !String.IsNullOrEmpty(txtPort.Text) &&
                    !String.IsNullOrEmpty(txtSendData.Text))
                {
                    label1.Text = "NONE";
                    string ip1 = txtIPAddress.Text.Substring(0, 3);
                    string ip2 = txtIPAddress.Text.Substring(3, 3);
                    string ip3 = txtIPAddress.Text.Substring(6, 3);
                    string ip4 = txtIPAddress.Text.Substring(9, 3);
                    IPAddress ip = IPAddress.Parse($"{ip1.TrimStart('0')}.{ip2.TrimStart('0')}.{ip3.TrimStart('0')}.{ip4.TrimStart('0')}");
                    var serverIP = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
                    using (var socket = new Socket(serverIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp))

                    {
                        socket.Connect(serverIP);

                        using (var ns = new NetworkStream(socket))
                        using (var sw = new StreamWriter(ns, Encoding.ASCII))
                        using (var sr = new StreamReader(ns, Encoding.UTF8))
                        {
                            string request = txtSendData.Text;

                            sw.Write(request);
                            sw.Flush();
                            while (!ns.DataAvailable)
                            {
                                Thread.SpinWait(1);
                            }

                            char[] responseBuffer = new char[1024];
                            int getSize;

                            while ((getSize = sr.Read(responseBuffer, 0, responseBuffer.Length)) > 0)
                            {
                                string data = new string(responseBuffer, 0, getSize);
                                label1.Text = data;
                                Debug.Write(data);
                                if (data.Contains(txtFinishValue.Text))
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Tüm Alanları Doldurunuz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex.Message);
            }
        }

        public static string TcpClientSendAndGet(BaseRequest baseRequest, ListBox listBox)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    TcpClient tcpCli = new TcpClient();
                    bool connectionStatus = GetConnection(baseRequest, out tcpCli);
                    NetworkStream stream = null;
                    if (connectionStatus == false)
                        return "Could not establish TCP connection";
                    else
                    {
                        try
                        {
                            //Send data to TCP Client
                            Byte[] data = Encoding.ASCII.GetBytes(baseRequest.SendData);
                            stream = tcpCli.GetStream();
                            stream.Write(data, 0, data.Length);
                            //Read from TCP Client
                            string answer = "";
                            DateTime st = DateTime.Now;
                            DateTime et = DateTime.Now.AddSeconds(600);
                            do
                            {
                                st = DateTime.Now;
                                if (st > et)
                                    return "TIME-OUT";
                                data = new Byte[tcpCli.ReceiveBufferSize];
                                Int32 bytes = stream.ReadAsync(data, 0, data.Length).Result;
                                string tmpAnswer = Encoding.ASCII.GetString(data, 0, bytes);
                                listBox.Items.Add(tmpAnswer);
                                Debug.WriteLine(tmpAnswer);
                                if (tmpAnswer.Contains(baseRequest.FinishValue))
                                {
                                    answer += tmpAnswer;
                                    break;
                                }
                                answer += tmpAnswer;
                            } while (et > st);

                            if (answer.Contains("**"))
                                return answer;
                            else
                                return "Panel no answer";
                        }
                        catch (Exception) { return "COMMUNICATION ERROR"; }
                        finally { tcpCli.Close(); }
                    }
                }
                else
                {
                    return "THERE IS NO CONNECTION";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Message: " + ex.Message);
                return "";
            }
        }

        public static bool GetConnection(BaseRequest baseRequest, out TcpClient tcpClient)
        {
            TcpClient cli = new TcpClient();
            string ip1 = baseRequest.IpAddress.Substring(0, 3);
            string ip2 = baseRequest.IpAddress.Substring(3, 3);
            string ip3 = baseRequest.IpAddress.Substring(6, 3);
            string ip4 = baseRequest.IpAddress.Substring(9, 3);
            Thread.Sleep(100);
            if (cli.Connected)
                cli.Close();
            try
            {
                IPAddress ip = IPAddress.Parse($"{ip1.TrimStart('0')}.{ip2.TrimStart('0')}.{ip3.TrimStart('0')}.{ip4.TrimStart('0')}");
                var result = cli.BeginConnect(ip, baseRequest.TcpPort, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2));
                if (success)
                {
                    tcpClient = cli;
                    return true;
                }
                else
                {
                    tcpClient = null;
                    cli.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                tcpClient = null;
                cli.Close();
                return false;
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            txtSendData.Text = "";
            txtPort.Text = "";
            txtIPAddress.Text = "";
            txtFinishValue.Text = "";
            label1.Text = "NONE";
        }
    }
}