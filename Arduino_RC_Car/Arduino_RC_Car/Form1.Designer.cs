namespace Arduino_RC_Car
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_bluetooth = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lbl_temp = new System.Windows.Forms.Label();
            this.trackBar_acceleration = new System.Windows.Forms.TrackBar();
            this.lbl_acceleration = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_humidity = new System.Windows.Forms.Label();
            this.cmb_ComPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_acceleration)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_down
            // 
            this.btn_down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_down.BackgroundImage")));
            this.btn_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_down.FlatAppearance.BorderSize = 0;
            this.btn_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_down.Location = new System.Drawing.Point(281, 568);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(88, 51);
            this.btn_down.TabIndex = 0;
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_right
            // 
            this.btn_right.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_right.BackgroundImage")));
            this.btn_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_right.FlatAppearance.BorderSize = 0;
            this.btn_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_right.Location = new System.Drawing.Point(369, 491);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(59, 76);
            this.btn_right.TabIndex = 1;
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.btn_right_Click);
            // 
            // btn_up
            // 
            this.btn_up.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_up.BackgroundImage")));
            this.btn_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_up.FlatAppearance.BorderSize = 0;
            this.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_up.Location = new System.Drawing.Point(281, 434);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(88, 51);
            this.btn_up.TabIndex = 2;
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_left
            // 
            this.btn_left.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_left.BackgroundImage")));
            this.btn_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_left.FlatAppearance.BorderSize = 0;
            this.btn_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_left.Location = new System.Drawing.Point(216, 491);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(59, 76);
            this.btn_left.TabIndex = 3;
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.btn_left_Click);
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.btn_minimize);
            this.pnl_top.Controls.Add(this.btn_exit);
            this.pnl_top.Location = new System.Drawing.Point(1, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(638, 35);
            this.pnl_top.TabIndex = 4;
            this.pnl_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.pnl_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            this.pnl_top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseUp);
            // 
            // btn_minimize
            // 
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.btn_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(126)))), ((int)(((byte)(5)))));
            this.btn_minimize.Location = new System.Drawing.Point(582, 3);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(32, 29);
            this.btn_minimize.TabIndex = 1;
            this.btn_minimize.Text = "__";
            this.btn_minimize.UseVisualStyleBackColor = true;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(126)))), ((int)(((byte)(5)))));
            this.btn_exit.Location = new System.Drawing.Point(606, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(32, 29);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "X";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_bluetooth
            // 
            this.btn_bluetooth.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_bluetooth.BackgroundImage")));
            this.btn_bluetooth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bluetooth.FlatAppearance.BorderSize = 0;
            this.btn_bluetooth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_bluetooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bluetooth.Location = new System.Drawing.Point(595, 47);
            this.btn_bluetooth.Name = "btn_bluetooth";
            this.btn_bluetooth.Size = new System.Drawing.Size(43, 32);
            this.btn_bluetooth.TabIndex = 5;
            this.btn_bluetooth.UseVisualStyleBackColor = true;
            this.btn_bluetooth.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(68, 434);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 38);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.Text = "Refresh Data";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lbl_temp
            // 
            this.lbl_temp.AutoSize = true;
            this.lbl_temp.ForeColor = System.Drawing.Color.White;
            this.lbl_temp.Location = new System.Drawing.Point(81, 491);
            this.lbl_temp.Name = "lbl_temp";
            this.lbl_temp.Size = new System.Drawing.Size(63, 13);
            this.lbl_temp.TabIndex = 7;
            this.lbl_temp.Text = "temperature";
            // 
            // trackBar_acceleration
            // 
            this.trackBar_acceleration.Location = new System.Drawing.Point(485, 568);
            this.trackBar_acceleration.Minimum = 1;
            this.trackBar_acceleration.Name = "trackBar_acceleration";
            this.trackBar_acceleration.Size = new System.Drawing.Size(104, 45);
            this.trackBar_acceleration.TabIndex = 8;
            this.trackBar_acceleration.Value = 1;
            // 
            // lbl_acceleration
            // 
            this.lbl_acceleration.AutoSize = true;
            this.lbl_acceleration.ForeColor = System.Drawing.Color.White;
            this.lbl_acceleration.Location = new System.Drawing.Point(508, 552);
            this.lbl_acceleration.Name = "lbl_acceleration";
            this.lbl_acceleration.Size = new System.Drawing.Size(65, 13);
            this.lbl_acceleration.TabIndex = 9;
            this.lbl_acceleration.Text = "acceleration";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(498, 486);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 11;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_humidity
            // 
            this.lbl_humidity.AutoSize = true;
            this.lbl_humidity.ForeColor = System.Drawing.Color.White;
            this.lbl_humidity.Location = new System.Drawing.Point(81, 523);
            this.lbl_humidity.Name = "lbl_humidity";
            this.lbl_humidity.Size = new System.Drawing.Size(45, 13);
            this.lbl_humidity.TabIndex = 12;
            this.lbl_humidity.Text = "humidity";
            // 
            // cmb_ComPorts
            // 
            this.cmb_ComPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.cmb_ComPorts.ForeColor = System.Drawing.Color.Green;
            this.cmb_ComPorts.FormattingEnabled = true;
            this.cmb_ComPorts.Location = new System.Drawing.Point(533, 54);
            this.cmb_ComPorts.Name = "cmb_ComPorts";
            this.cmb_ComPorts.Size = new System.Drawing.Size(56, 21);
            this.cmb_ComPorts.TabIndex = 13;
            this.cmb_ComPorts.TextChanged += new System.EventHandler(this.cmb_ComPorts_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(295, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Status:";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(638, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_ComPorts);
            this.Controls.Add(this.lbl_humidity);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_acceleration);
            this.Controls.Add(this.trackBar_acceleration);
            this.Controls.Add(this.lbl_temp);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_bluetooth);
            this.Controls.Add(this.pnl_top);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_down);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Main";
            this.Text = "Arduino_RC";
            this.pnl_top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_acceleration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_bluetooth;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lbl_temp;
        private System.Windows.Forms.TrackBar trackBar_acceleration;
        private System.Windows.Forms.Label lbl_acceleration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_humidity;
        private System.Windows.Forms.ComboBox cmb_ComPorts;
        private System.Windows.Forms.Label label1;
    }
}

