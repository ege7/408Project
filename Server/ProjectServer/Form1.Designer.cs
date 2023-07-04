namespace CS408ClientSide
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
            this.logs = new System.Windows.Forms.RichTextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label4_Name = new System.Windows.Forms.Label();
            this.label2_Port = new System.Windows.Forms.Label();
            this.label1_IP = new System.Windows.Forms.Label();
            this.textBox_GridSel = new System.Windows.Forms.TextBox();
            this.label5_GridSel = new System.Windows.Forms.Label();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_Select = new System.Windows.Forms.Button();
            this.game_rtb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(43, 188);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(391, 269);
            this.logs.TabIndex = 19;
            this.logs.Text = "";
            this.logs.TextChanged += new System.EventHandler(this.logs_TextChanged);
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(103, 134);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 18;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button1_Connect_Click_1);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(92, 94);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(197, 22);
            this.textBox_name.TabIndex = 17;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox4_Name_TextChanged);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(92, 66);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(197, 22);
            this.textBox_port.TabIndex = 15;
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(92, 38);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(197, 22);
            this.textBox_ip.TabIndex = 14;
            // 
            // label4_Name
            // 
            this.label4_Name.AutoSize = true;
            this.label4_Name.Location = new System.Drawing.Point(40, 97);
            this.label4_Name.Name = "label4_Name";
            this.label4_Name.Size = new System.Drawing.Size(44, 16);
            this.label4_Name.TabIndex = 13;
            this.label4_Name.Text = "Name";
            // 
            // label2_Port
            // 
            this.label2_Port.AutoSize = true;
            this.label2_Port.Location = new System.Drawing.Point(40, 69);
            this.label2_Port.Name = "label2_Port";
            this.label2_Port.Size = new System.Drawing.Size(31, 16);
            this.label2_Port.TabIndex = 11;
            this.label2_Port.Text = "Port";
            // 
            // label1_IP
            // 
            this.label1_IP.AutoSize = true;
            this.label1_IP.Location = new System.Drawing.Point(40, 41);
            this.label1_IP.Name = "label1_IP";
            this.label1_IP.Size = new System.Drawing.Size(19, 16);
            this.label1_IP.TabIndex = 10;
            this.label1_IP.Text = "IP";
            // 
            // textBox_GridSel
            // 
            this.textBox_GridSel.Enabled = false;
            this.textBox_GridSel.Location = new System.Drawing.Point(511, 54);
            this.textBox_GridSel.Name = "textBox_GridSel";
            this.textBox_GridSel.Size = new System.Drawing.Size(197, 22);
            this.textBox_GridSel.TabIndex = 20;
            // 
            // label5_GridSel
            // 
            this.label5_GridSel.AutoSize = true;
            this.label5_GridSel.Location = new System.Drawing.Point(412, 57);
            this.label5_GridSel.Name = "label5_GridSel";
            this.label5_GridSel.Size = new System.Drawing.Size(91, 16);
            this.label5_GridSel.TabIndex = 21;
            this.label5_GridSel.Text = "Grid Selection";
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(196, 134);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(93, 23);
            this.button_disconnect.TabIndex = 22;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button2_Disconnect_Click);
            // 
            // button_Select
            // 
            this.button_Select.Enabled = false;
            this.button_Select.Location = new System.Drawing.Point(572, 82);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(75, 23);
            this.button_Select.TabIndex = 23;
            this.button_Select.Text = "Select";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button3_Select_Click);
            // 
            // game_rtb
            // 
            this.game_rtb.Location = new System.Drawing.Point(481, 188);
            this.game_rtb.Name = "game_rtb";
            this.game_rtb.Size = new System.Drawing.Size(275, 269);
            this.game_rtb.TabIndex = 24;
            this.game_rtb.Text = "";
            this.game_rtb.TextChanged += new System.EventHandler(this.game_rtb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Game: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.game_rtb);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.label5_GridSel);
            this.Controls.Add(this.textBox_GridSel);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label4_Name);
            this.Controls.Add(this.label2_Port);
            this.Controls.Add(this.label1_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label4_Name;
        private System.Windows.Forms.Label label2_Port;
        private System.Windows.Forms.Label label1_IP;
        private System.Windows.Forms.TextBox textBox_GridSel;
        private System.Windows.Forms.Label label5_GridSel;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.RichTextBox game_rtb;
        private System.Windows.Forms.Label label1;
    }
}

