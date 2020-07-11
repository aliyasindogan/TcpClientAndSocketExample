namespace TcpClientAndSocketExample
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTcpClient = new System.Windows.Forms.Button();
            this.btnSocket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.txtFinishValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTcpClient
            // 
            this.btnTcpClient.Location = new System.Drawing.Point(100, 213);
            this.btnTcpClient.Name = "btnTcpClient";
            this.btnTcpClient.Size = new System.Drawing.Size(93, 23);
            this.btnTcpClient.TabIndex = 0;
            this.btnTcpClient.Text = "Tcp Client";
            this.btnTcpClient.UseVisualStyleBackColor = true;
            this.btnTcpClient.Click += new System.EventHandler(this.btnTcpClient_Click);
            // 
            // btnSocket
            // 
            this.btnSocket.Location = new System.Drawing.Point(199, 213);
            this.btnSocket.Name = "btnSocket";
            this.btnSocket.Size = new System.Drawing.Size(78, 23);
            this.btnSocket.TabIndex = 0;
            this.btnSocket.Text = "Socket";
            this.btnSocket.UseVisualStyleBackColor = true;
            this.btnSocket.Click += new System.EventHandler(this.btnSocket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NONE";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(100, 34);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(177, 20);
            this.txtIPAddress.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(100, 77);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(177, 20);
            this.txtPort.TabIndex = 2;
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(100, 120);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(177, 20);
            this.txtSendData.TabIndex = 2;
            // 
            // txtFinishValue
            // 
            this.txtFinishValue.Location = new System.Drawing.Point(100, 163);
            this.txtFinishValue.Name = "txtFinishValue";
            this.txtFinishValue.Size = new System.Drawing.Size(177, 20);
            this.txtFinishValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Send Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Finish Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Get Data:";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(97, 251);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(180, 23);
            this.btnClearForm.TabIndex = 0;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 336);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFinishValue);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSocket);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnTcpClient);
            this.Name = "Form1";
            this.Text = "TcpClient And Socket Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTcpClient;
        private System.Windows.Forms.Button btnSocket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.TextBox txtFinishValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClearForm;
    }
}

