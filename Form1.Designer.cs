namespace Snake_Game
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
            this.components = new System.ComponentModel.Container();
            this.gametick = new System.Windows.Forms.Timer(this.components);
            this.lbScore1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnHD = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.btnRES = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbScore2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gametick
            // 
            this.gametick.Interval = 180;
            this.gametick.Tick += new System.EventHandler(this.Gametick_Tick);
            // 
            // lbScore1
            // 
            this.lbScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore1.ForeColor = System.Drawing.Color.Yellow;
            this.lbScore1.Location = new System.Drawing.Point(759, 116);
            this.lbScore1.Name = "lbScore1";
            this.lbScore1.Size = new System.Drawing.Size(143, 43);
            this.lbScore1.TabIndex = 0;
            this.lbScore1.Text = "ScoreP1 : 0000";
            this.lbScore1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnStart.FlatAppearance.BorderSize = 4;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Yellow;
            this.btnStart.Location = new System.Drawing.Point(763, 161);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(290, 45);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "BẮT ĐẦU !!!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnExit.FlatAppearance.BorderSize = 4;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Yellow;
            this.btnExit.Location = new System.Drawing.Point(763, 359);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(290, 45);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "THOÁT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnHD
            // 
            this.btnHD.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnHD.FlatAppearance.BorderSize = 4;
            this.btnHD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnHD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHD.ForeColor = System.Drawing.Color.Yellow;
            this.btnHD.Location = new System.Drawing.Point(763, 290);
            this.btnHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(290, 45);
            this.btnHD.TabIndex = 3;
            this.btnHD.Text = "HƯỚNG DẪN";
            this.btnHD.UseVisualStyleBackColor = true;
            this.btnHD.Click += new System.EventHandler(this.BtnHD_Click);
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Showcard Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Yellow;
            this.lbName.Location = new System.Drawing.Point(758, 7);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(294, 96);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "SNAKE NHÀ LÀM :3\r\nFORM NHÓM 1 WITH LUV <3";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRES
            // 
            this.btnRES.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnRES.FlatAppearance.BorderSize = 4;
            this.btnRES.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRES.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRES.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRES.ForeColor = System.Drawing.Color.Yellow;
            this.btnRES.Location = new System.Drawing.Point(763, 226);
            this.btnRES.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRES.Name = "btnRES";
            this.btnRES.Size = new System.Drawing.Size(290, 45);
            this.btnRES.TabIndex = 8;
            this.btnRES.Text = "CHƠI LẠI";
            this.btnRES.UseVisualStyleBackColor = true;
            this.btnRES.Click += new System.EventHandler(this.BtnRES_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Snake_Game__o.o_.Properties.Resources.GameHubVN_Nhin_lai_thuy_to_Game_Mobile_Ran_san_moi_va_lich_su_de_che_Nokia_61;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(724, 411);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 9;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Snake_Game__o.o_.Properties.Resources.GameHubVN_Nhin_lai_thuy_to_Game_Mobile_Ran_san_moi_va_lich_su_de_che_Nokia_61;
            this.pictureBox2.Location = new System.Drawing.Point(764, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(289, 82);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // lbScore2
            // 
            this.lbScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore2.ForeColor = System.Drawing.Color.Yellow;
            this.lbScore2.Location = new System.Drawing.Point(910, 116);
            this.lbScore2.Name = "lbScore2";
            this.lbScore2.Size = new System.Drawing.Size(143, 43);
            this.lbScore2.TabIndex = 11;
            this.lbScore2.Text = "ScoreP2 : 0000";
            this.lbScore2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1063, 435);
            this.Controls.Add(this.lbScore2);
            this.Controls.Add(this.lbScore1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnRES);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnHD);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game !!!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gametick;
        private System.Windows.Forms.Label lbScore1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnRES;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbScore2;
    }
}

