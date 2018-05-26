namespace client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chatting = new System.Windows.Forms.RichTextBox();
            this.message = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.serverHost = new System.Windows.Forms.TextBox();
            this.serverPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chatting
            // 
            this.chatting.Enabled = false;
            this.chatting.Location = new System.Drawing.Point(24, 46);
            this.chatting.Name = "chatting";
            this.chatting.Size = new System.Drawing.Size(416, 225);
            this.chatting.TabIndex = 0;
            this.chatting.Text = "";
            // 
            // message
            // 
            this.message.Enabled = false;
            this.message.Location = new System.Drawing.Point(24, 312);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(416, 162);
            this.message.TabIndex = 2;
            this.message.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "聊天记录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "发送消息";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(496, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 48);
            this.button2.TabIndex = 7;
            this.button2.Text = "连接服务器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // serverHost
            // 
            this.serverHost.Location = new System.Drawing.Point(551, 67);
            this.serverHost.Name = "serverHost";
            this.serverHost.Size = new System.Drawing.Size(138, 21);
            this.serverHost.TabIndex = 8;
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(551, 142);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(138, 21);
            this.serverPort.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "服务器地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "端口号";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 514);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.serverHost);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.chatting);
            this.Name = "Form1";
            this.Text = "socket;聊天--客户端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox chatting;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox serverHost;
        private System.Windows.Forms.TextBox serverPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

