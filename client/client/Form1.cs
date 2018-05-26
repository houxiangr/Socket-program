using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //定义数据
        private byte[] result = new byte[1024];
        private string host;
        private int port;
        private IPEndPoint ipEndPoint;
        private Socket c;
        private bool isConnected = false;
        private void button1_Click(object sender, EventArgs e)
        {
            //获取要发送的内容
            string msg = message.Text;
            if (msg == string.Empty || this.c == null) return;

            c.Send(Encoding.UTF8.GetBytes(msg));
            message.Text = "";
        }

        
        // 连接到服务器  
  
        private void ConnectToServer()
        {
            //当没有连接到服务器时开始连接  
            while (!this.isConnected)
            {
                try
                {
                    //开始连接  
                    this.c.Connect(this.ipEndPoint);
                    this.isConnected = true;
                }
                catch (Exception e)
                {
                    //输出Debug信息
                    string error = "因为一个错误的发生，暂时无法连接到服务器，错误信息为:" + e.Message;
                    MessageBox.Show(error,"错误");
                    this.isConnected = false;
                    return;
                }
            }
            //连接成功后  
            MessageBox.Show("连接服务器成功，现在可以和服务器进行会话了");
            message.Enabled = true;
            button1.Enabled = true;
            //创建一个线程以监听数据接收  
            var mReceiveThread = new Thread(this.ReceiveMessage);
            mReceiveThread.IsBackground = true;
            //开启线程  
            mReceiveThread.Start();
        }
        
        // 因为客户端只接受来自服务器的数据  
        // 因此这个方法中不需要参数  
        
        private void ReceiveMessage()
        {
            //设置循环标志位  
            bool flag = true;
            while (flag)
            {
                try
                {
                    //获取数据长度  
                    int receiveLength = this.c.Receive(result);
                    //获取服务器消息  
                    string serverMessage = Encoding.UTF8.GetString(result, 0, receiveLength);
                    if (serverMessage == "服务器关闭。")
                    {
                        MessageBox.Show("由于服务器关闭，此聊天室被迫关闭");
                        Application.Exit();
                    }
                    DateTime ct = DateTime.Now;
                    //输出服务器消息  
                    chatting.Text = chatting.Text + serverMessage +"("+ct+")"+ "\n";
                }
                catch (Exception e)
                {
                    //停止消息接收  
                    flag = false;
                    //断开服务器  
                    this.c.Shutdown(SocketShutdown.Both);
                    //关闭套接字  
                    this.c.Close();
                    //重新尝试连接服务器  
                    this.isConnected = false;
                    ConnectToServer();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serverHost.Text == "" || serverPort.Text == "") {
                MessageBox.Show("服务器地址和端口号不能为空");
                return;
            }
            this.host = serverHost.Text;
            try
            {
                this.port = int.Parse(serverPort.Text);
            }
            catch
            {
                MessageBox.Show("端口号不合法");
                return;
            }
            if (this.port > 65535) {
                MessageBox.Show("端口号大于电脑的最大端口号");
                return;
            }
            try
            {
                this.ipEndPoint = new IPEndPoint(IPAddress.Parse(this.host), this.port);
            }
            catch
            {
                MessageBox.Show("IP地址不合法");
                return;
            }
            //初始化客户端Socket  
            this.c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //创建一个线程以不断连接服务器  
            var mConnectThread = new Thread(this.ConnectToServer);
            mConnectThread.IsBackground = true;
            //开启线程  
            mConnectThread.Start();
        }  
    }
}
