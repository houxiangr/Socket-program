using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;  

namespace server
{
    public partial class Form1 : Form
    {
        private byte[] result = new byte[1024];
        //客户端列表
        private List<Socket> mClientSockets;
        public List<Socket> ClientSockets
        {
            get { return mClientSockets; }
        }
        private string host;
        private int port;
        private IPAddress ip;
        private IPEndPoint ipe;
        private Socket s;
        private Socket c;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serverIp.Text == "" || serverPort.Text == "") {
                MessageBox.Show("IP地址和端口号不能为空！");
                return;
            }
            this.mClientSockets = new List<Socket>();
            //获取服务器主机地址和ip地址
            this.host = serverIp.Text;
            try
            {
                this.port = Convert.ToInt32(serverPort.Text);
            }
            catch
            {
                MessageBox.Show("端口号不合法");
                return;
            }
            if (this.port > 65535)
            {
                MessageBox.Show("端口号大于电脑的最大端口号");
                return;
            }
            //把IP地址转换成IPAddress实例
            try
            {
                this.ip = IPAddress.Parse(host);
            }
            catch 
            {
                MessageBox.Show("IP地址不合法");
                return;
            }
            //用指定的ip和端口号指定IPEndPoint实例
            this.ipe = new IPEndPoint(this.ip, this.port);
            //创建Socket并开始监听
            //创建一个socket对象，如果用udp协议，则要用SocketType.Dgram类型的套接字
            this.s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                this.s.Bind(this.ipe);
            }
            catch {
                MessageBox.Show("此socket已经被占用请选择其他地址或端口");
                return;
            }
            //绑定EndPoint对象
            this.s.Listen(0);//开始监听
            //接受到client连接，为此连接建立新的socket，并接受信息
            //创建服务端线程，实现客户端连接请求的循环监听  
            var mServerThread = new Thread(this.ListenClientConnect);
            mServerThread.IsBackground = true;
            //服务端线程开启  
            mServerThread.Start();
            button1.Enabled = false;
        }
        //服务器端循环监听客户端
        private void ListenClientConnect()
        {
            //设置循环标志位  
            bool flag = true;
            while (flag)
            {
                try
                {
                    //获取连接到服务端的客户端
                    this.c = this.s.Accept();
                }
                catch (Exception ex)
                {
                    
                }
                //将获取到的客户端添加到客户端列表  
                this.mClientSockets.Add(this.c);
                //向客户端发送一条消息
                try
                {
                    this.SendMessage(string.Format("客户端{0}已成功连接到服务器", this.c.RemoteEndPoint));
                }
                catch (Exception ex)
                {
                    
                }
                //创建客户端消息线程，实现客户端消息的循环监听  
                var mReveiveThread = new Thread(this.ReceiveClient);
                mReveiveThread.IsBackground = true;
                //注意到ReceiveClient方法传入了一个参数  
                //实际上这个参数就是此时连接到服务器的客户端  
                //即ClientSocket  
                mReveiveThread.Start(this.c);
            }
        }
        //群发消息
        public void SendMessage(string msg)
        {
            try
            {
                //确保消息非空以及客户端列表非空  
                if (msg == string.Empty || this.mClientSockets.Count <= 0) return;
                //向每一个客户端发送消息  
                foreach (Socket temps in this.mClientSockets)
                {
                    (temps as Socket).Send(Encoding.UTF8.GetBytes(msg));
                }
            }
            catch {
 
            }
        }
        // 接收客户端消息的方法  
        private void ReceiveClient(object obj)
        {
            //获取当前客户端  
            //因为每次发送消息的可能并不是同一个客户端，所以需要使用var来实例化一个新的对象   
            var mClientSocket = (Socket)obj;
            // 循环标志位  
            bool flag = true;
            while (flag)
            {
                try
                {
                    //获取数据长度  
                    int receiveLength = mClientSocket.Receive(result);
                    //获取客户端消息  
                    string clientMessage = Encoding.UTF8.GetString(result, 0, receiveLength);
                    //服务端负责将客户端的消息分发给各个客户端  
                    this.SendMessage(string.Format("客户端{0}发来消息:{1}", mClientSocket.RemoteEndPoint, clientMessage));

                }
                catch (Exception e)
                {
                    //从客户端列表中移除该客户端  
                    this.mClientSockets.Remove(mClientSocket);
                    try
                    {
                        //向其它客户端告知该客户端下线
                        this.SendMessage(string.Format("服务器发来消息:客户端{0}从服务器断开,断开原因:{1}", mClientSocket.RemoteEndPoint, e.Message));
                        //断开连接
                        mClientSocket.Close();
                    }
                    catch 
                    {
                    }
                    break;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.s.Close();
                MessageBox.Show("欢迎下次使用");
            }
            catch
            {
                MessageBox.Show("欢迎下次使用");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SendMessage("服务器关闭。");
        }
    }
}
