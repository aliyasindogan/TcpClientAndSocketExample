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
            InitializeComponent();
        }

        private void btnTcpClient_Click(object sender, EventArgs e)
        {
            BaseRequest baseRequest = new BaseRequest()
            {
                FinishValue = "finishValue",
                IpAddress = "ipAdrress",
                TcpPort = 0000,
                SendData = "sendData",
            };
            label1.Text = TcpClientSendAndGet(baseRequest);
        }

        public static string TcpClientSendAndGet(BaseRequest baseRequest)
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

        private void btnSocket_Click(object sender, EventArgs e)
        {
            var serverIP = new IPEndPoint(IPAddress.Parse("ipadress"), 0000);
            using (var socket = new Socket(serverIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp))

            {
                socket.Connect(serverIP);

                using (var ns = new NetworkStream(socket))
                using (var sw = new StreamWriter(ns, Encoding.ASCII))
                using (var sr = new StreamReader(ns, Encoding.UTF8))
                {
                    string request = "request";

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
                        if (data.Contains("**"))
                            break;
                    }
                }
            }
        }
    }
}