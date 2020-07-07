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
            this.SuspendLayout();
            // 
            // btnTcpClient
            // 
            this.btnTcpClient.Location = new System.Drawing.Point(28, 31);
            this.btnTcpClient.Name = "btnTcpClient";
            this.btnTcpClient.Size = new System.Drawing.Size(96, 23);
            this.btnTcpClient.TabIndex = 0;
            this.btnTcpClient.Text = "Tcp Client";
            this.btnTcpClient.UseVisualStyleBackColor = true;
            this.btnTcpClient.Click += new System.EventHandler(this.btnTcpClient_Click);
            // 
            // btnSocket
            // 
            this.btnSocket.Location = new System.Drawing.Point(130, 31);
            this.btnSocket.Name = "btnSocket";
            this.btnSocket.Size = new System.Drawing.Size(96, 23);
            this.btnSocket.TabIndex = 0;
            this.btnSocket.Text = "Socket";
            this.btnSocket.UseVisualStyleBackColor = true;
            this.btnSocket.Click += new System.EventHandler(this.btnSocket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 140);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSocket);
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
    }
}

