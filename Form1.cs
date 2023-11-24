using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public string connectStr = @"Data Source=DesKtop-DaVinci;Initial Catalog=Snake2Player;Integrated Security=True";


        private int square = 10;
        private int sohang = 30;
        private int socot = 50;
        PictureBox[,] Map = new PictureBox[50, 50];
        private Point start = new Point(30, 30); //Point đại diện cho một cặp tọa độ x, y trên một mặt phẳng hai chiều
        private int snakeX1 = 0;
        private int snakeY1 = 0;
        private int snakeX2 = 0;
        private int snakeY2 = 0;
        private int foodX = 0;
        private int foodY = 0;
        private int dir = 0;//1=lên 2=trái 3=xuống 4=phải
        private int dir2 = 0;
        private int scoreP1 = 0;
        private int scoreP2 = 0;
        Random r = new Random();
        Point[] bodyran1 = new Point[100];
        Point[] bodyran2 = new Point[100];
        private int body1 = 1;
        private int body2 = 1;
        public Form1()
        {
            InitializeComponent();
        }

        public void updateInfo()
        {
            lbScore1.Text = "ScoreP1 : " + scoreP1.ToString();
            lbScore2.Text = "ScoreP2 : " + scoreP2.ToString();
            if (gametick.Enabled == false)
            {
                btnStart.Hide();
            }

        }
        private void Form1_Load(object sender, EventArgs e) //hàm setup
        {
            

            using (SqlConnection Conn = new SqlConnection(connectStr))
            {
                Conn.Open();
                string Querry = "SELECT * FROM Ran";
                using (SqlCommand cmd = new SqlCommand(Querry,Conn)) 
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {

                            scoreP1 = Convert.ToInt32(reader["Value"]);
                            reader.Read();
                            scoreP2 = Convert.ToInt32(reader["Value"]);
                            reader.Read();
                            body1 = Convert.ToInt32(reader["Value"]);
                            reader.Read();
                            body2 = Convert.ToInt32(reader["Value"]);


                        }
                    }
                }
            }

            veMap();
            snakeX1 = sohang / 2;
            snakeY1 = 32;
            snakeX2 = sohang / 2;
            snakeY2 = 16;
            dir = 1;
            dir2 = 1;
            foodX = r.Next(1, sohang - 1);
            foodY = r.Next(1, socot - 1);
            while (foodX == snakeX1 && foodY == snakeY1 || foodX == snakeX2 && foodY == snakeY2) //Khi rắn ăn đc mồi sẽ thay đổi vị trí thức ăn
            {
                foodX = r.Next(1, sohang - 1);
                foodY = r.Next(1, socot - 1);
            }
            // body1 = 1;
            // body2 = 1;
            pictureBox2.Hide();
            btnRES.Hide();
        }


        public void veRan1()
        {
            Map[snakeX1, snakeY1].BackColor = Color.Yellow;
            for (int i = 99; i >= 1; i--)
            {
                bodyran1[i] = bodyran1[i - 1];
            }
            bodyran1[0].X = snakeX1;
            bodyran1[0].Y = snakeY1;
            for (int i = 1; i < body1; i++)
            {
                Map[bodyran1[i].X, bodyran1[i].Y].BackColor = Color.Yellow; //đuôi rắn 
            }
        }

        public void veRan2()
        {
            Map[snakeX2, snakeY2].BackColor = Color.Orange;
            for (int i = 99; i >= 1; i--)
            {
                bodyran2[i] = bodyran2[i - 1];
            }
            bodyran2[0].X = snakeX2;
            bodyran2[0].Y = snakeY2;
            for (int i = 1; i < body2; i++)
            {
                Map[bodyran2[i].X, bodyran2[i].Y].BackColor = Color.Orange; //đuôi rắn 
            }
        }
        public void veMap()
        {
            for (int i = 0; i < sohang; i++)
            {
                for (int j = 0; j < socot; j++)
                {
                    Map[i, j] = new PictureBox();
                    Map[i, j].Left = start.X + j * square;//vị trí của cạnh bên trái so với lề
                    Map[i, j].Top = start.Y + i * square;//vị trí của cạnh trên so với lề

                    //Kích thước được thiết lập làm cho mỗi ô không bị che khuất bởi ô kế bên và giữ cho chúng đều nhau về kích thước
                    Map[i, j].Width = square + 1;
                    Map[i, j].Height = square + 1;

                    Map[i, j].BackColor = Color.DarkGreen;
                    //Map[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Controls.Add(Map[i, j]);
                }
            }
            for (int i = 0; i < sohang; i++)//Tường ngang
            {
                Map[i, 0].BackColor = Color.White;
                Map[i, socot - 1].BackColor = Color.White;
            }
            for (int i = 0; i < socot; i++)//Tường dọc
            {
                Map[0, i].BackColor = Color.White;
                Map[sohang - 1, i].BackColor = Color.White;
            }
        }
        public void resetMap()
        {
            for (int i = 1; i < sohang - 1; i++)
            {
                for (int j = 1; j < socot - 1; j++)
                {
                    if (Map[i, j].BackColor != Color.Red)
                    {
                        Map[i, j].BackColor = Color.DarkGreen;
                    }
                }
            }
            Map[snakeX1, snakeY1].BackColor = Color.DarkGreen;
            Map[snakeX2, snakeY2].BackColor = Color.DarkGreen;
        }
        private void Gametick_Tick(object sender, EventArgs e)
        {
            resetMap();
            input1();
            input2();
            veFood();
            veRan1();
            veRan2();
            check();
            updateInfo();

        }
        public void veFood()
        {
            while (Map[foodX, foodY].BackColor == Color.Yellow || Map[foodX, foodY].BackColor == Color.Orange)//Khi ăn được mồi mới set lại vị trí thức ăn
            {
                foodX = r.Next(1, sohang - 1);
                foodY = r.Next(1, socot - 1);
            }
            Map[foodX, foodY].BackColor = Color.Red;
        }
        public void resetgame()
        {
            for (int i = 1; i < sohang - 1; i++)
            {
                for (int j = 1; j < socot - 1; j++)
                {
                    Map[i, j].BackColor = Color.DarkGreen;
                }
            }
            for (int i = 0; i < sohang; i++)
            {
                Map[i, 0].BackColor = Color.White;
                Map[i, socot - 1].BackColor = Color.White;
            }
            for (int i = 0; i < socot; i++)
            {
                Map[0, i].BackColor = Color.White;
                Map[sohang - 1, i].BackColor = Color.White;
            }
            snakeX1 = sohang / 2;
            snakeY1 = 32;
            snakeX2 = sohang / 2;
            snakeY2 = 16;
            foodX = r.Next(1, sohang - 1);
            foodY = r.Next(1, socot - 1);
            while (foodX == snakeX1 && foodY == snakeY1 || foodX == snakeX2 && foodY == snakeY2)
            {
                foodX = r.Next(1, sohang - 1);
                foodY = r.Next(1, socot - 1);
            }
            scoreP1 = 0;
            scoreP2 = 0;
            body1 = 1;
            body2 = 1;
            btnStart.Text = "TẠM DỪNG";
            gametick.Interval = 150;
            dir = 1;
            dir2 = 1;
        }
        public void input1()
        {
            if (dir == 1)
            {
                snakeX1--;
            }
            else if (dir == 2)
            {
                snakeY1--;
            }
            else if (dir == 3)
            {
                snakeX1++;
            }
            else
            {
                snakeY1++;
            }

        }
        public void input2()
        {
            if (dir2 == 1)
            {
                snakeX2--;
            }
            else if (dir2 == 2)
            {
                snakeY2--;
            }
            else if (dir2 == 3)
            {
                snakeX2++;
            }
            else if (dir2 == 4)
            {
                snakeY2++;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up && dir != 3)
            {
                dir = 1;
                return true;
            }
            if (keyData == Keys.Down && dir != 1)
            {
                dir = 3;
                return true;
            }
            if (keyData == Keys.Left && dir != 4)
            {
                dir = 2;
                return true;
            }
            if (keyData == Keys.Right && dir != 2)
            {
                dir = 4;
                return true;
            }

            if (keyData == Keys.W && dir2 != 3)
            {
                dir2 = 1;
                return true;
            }
            if (keyData == Keys.S && dir2 != 1)
            {
                dir2 = 3;
                return true;
            }
            if (keyData == Keys.A && dir2 != 4)
            {
                dir2 = 2;
                return true;
            }
            if (keyData == Keys.D && dir2 != 2)
            {
                dir2 = 4;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void check()
        {
            if (snakeX1 == 0 || snakeX1 == sohang - 1 || snakeY1 == 0 || snakeY1 == socot - 1)
            {
                // Rắn vàng đâm vào tường
                gametick.Enabled = false;
                MessageBox.Show("Rắn vàng đã thua!");
                //resetgame();
                return;
            }
            if (snakeX1 == snakeX2 && snakeY1 == snakeY2)
            {
                if (bodyran1.Length > bodyran2.Length)
                {
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn cam đã thua!");
                    //resetgame();
                    return;
                }
                else if (bodyran1.Length < bodyran2.Length)
                {
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn vàng đã thua!");
                    //resetgame();
                    return;
                }
                else
                {
                    gametick.Enabled = false;
                    MessageBox.Show("Hòa !!!");
                    //resetgame();
                    return;
                }

            }

            for (int i = 1; i < body2; i++)
            {
                if (snakeX1 == bodyran1[i].X && snakeY1 == bodyran1[i].Y)
                {
                    // Rắn vàng cắn vào đuôi của mình
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn vàng đã thua!");
                    //resetgame();
                    return;
                }

                if (snakeX1 == bodyran2[i].X && snakeY1 == bodyran2[i].Y)
                {
                    // Rắn vàng cắn vào đuôi của Rắn cam
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn vàng đã thua!");
                    //resetgame();
                    return;
                }
            }

            if (snakeX2 == 0 || snakeX2 == sohang - 1 || snakeY2 == 0 || snakeY2 == socot - 1)
            {
                // Rắn cam đâm vào tường
                gametick.Enabled = false;
                MessageBox.Show("Rắn cam đã thua!");
                //resetgame();
                return;
            }

            for (int i = 1; i < body1; i++)
            {
                if (snakeX2 == bodyran2[i].X && snakeY2 == bodyran2[i].Y)
                {
                    // Rắn cam cắn vào đuôi của mình
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn cam đã thua!");
                    //resetgame();
                    return;
                }

                if (snakeX2 == bodyran1[i].X && snakeY2 == bodyran1[i].Y)
                {
                    // Rắn cam cắn vào đuôi của Rắn vàng
                    gametick.Enabled = false;
                    MessageBox.Show("Rắn cam đã thua!");
                    //resetgame();
                    return;
                }

               
            }
           

            if (snakeX1 == foodX && snakeY1 == foodY)
            {
                body1++;
                if (body1 == 100)
                {
                    body1--;
                }
                scoreP1 += r.Next(7, 11);
                while (Map[foodX, foodY].BackColor == Color.Yellow)
                {
                    foodX = r.Next(1, sohang - 1);
                    foodY = r.Next(1, socot - 1);
                }
                gametick.Interval = 150 - body1 * 2;
            }
            if (snakeX2 == foodX && snakeY2 == foodY)
            {
                body2++;
                if (body2 == 100)
                {
                    body2--;
                }
                scoreP2 += r.Next(7, 11);
                while (Map[foodX, foodY].BackColor == Color.Orange)
                {
                    foodX = r.Next(1, sohang - 1);
                    foodY = r.Next(1, socot - 1);
                }
                gametick.Interval = 150 - body2 * 2;
            }
        }



        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (gametick.Enabled == true)
            {
                gametick.Enabled = false;
                btnStart.Text = "TIẾP TỤC";
            }
            else
            {
                gametick.Enabled = true;
                btnStart.Text = "TẠM DỪNG";
            }
            pictureBox2.Show();
            pictureBox.Hide();
            btnRES.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            gametick.Enabled = false;
            DialogResult a = MessageBox.Show("Thoát trò chơi ngay bây giờ ?", "Thoát Game ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnHD_Click(object sender, EventArgs e)
        {
            pictureBox.Show();
            btnStart.Text = "TIẾP TỤC";
            gametick.Enabled = false;
            MessageBox.Show("Điều khiển con rắn đi săn mồi \nNgười chơi 1 sử dụng các phím mũi tên để di chuyển rắn vàng\nNgười chơi 2 sử dụng các phím A S W D để di chuyển rắn cam\n" +
                "Tránh cắn vào đuôi và đập đầu vô tường hoặc cắn vào đuôi nhau :V", "Game Rule", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BtnRES_Click(object sender, EventArgs e)
        {
            pictureBox.Hide();
            gametick.Enabled = false;
            DialogResult a = MessageBox.Show("Bạn có muốn chơi lại ?", "Restart Game ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                resetgame();
                btnStart.Show();
                btnStart.Text = "TẠM DỪNG";
                gametick.Enabled = true;
            }
            else
                gametick.Enabled = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (SqlConnection Conn = new SqlConnection(connectStr))
            {
                Conn.Open();
                string updateQuerry = @"UPDATE Ran SET Value = @newValue WHERE Name = 'Ran1'";
                using (SqlCommand cmd = new SqlCommand(updateQuerry, Conn))
                {
                    cmd.Parameters.AddWithValue("@newValue", scoreP1);

                    cmd.ExecuteNonQuery();

                }
                updateQuerry = @"UPDATE Ran SET Value = @newValue WHERE Name = 'Ran2'";
                using (SqlCommand cmd = new SqlCommand(updateQuerry, Conn))
                {
                    cmd.Parameters.AddWithValue("@newValue", scoreP2);

                    cmd.ExecuteNonQuery();

                }
                updateQuerry = @"UPDATE Ran SET Value = @newValue WHERE Name = 'DD1'";
                using (SqlCommand cmd = new SqlCommand(updateQuerry, Conn))
                {
                    cmd.Parameters.AddWithValue("@newValue", body1);

                    cmd.ExecuteNonQuery();

                }
                updateQuerry = @"UPDATE Ran SET Value = @newValue WHERE Name = 'DD2'";
                using (SqlCommand cmd = new SqlCommand(updateQuerry, Conn))
                {
                    cmd.Parameters.AddWithValue("@newValue", body2);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}