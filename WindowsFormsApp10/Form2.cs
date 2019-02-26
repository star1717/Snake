using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            game.snake.g = CreateGraphics();
            add += game.snake.AddVZmeyku;
            add();
            game.snake.DrawSnake();
            BackgroundImage = null;
            Color color = Color.Gold;
            BackColor = color;
            timer1.Enabled = true;
        }
        Play game = new Play();
        
        bool h1 = true; bool h2 = true; bool h3 = true; bool h4 = true;
        public delegate void run();
        public event run add;
        Bitmap view;
        
        public void SnakeLoad()
        {
            Save load = new Save();
            game = (Play)load.DeserializeObject("./save.bin");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            game.snake.g.Clear(this.BackColor);          
            timer1.Enabled = false; // останавливаем таймер              
            pictureBox4.Image = (Image)view;
            game.run();
            if (game.level == 2)
            {
                if (h1==true) MessageBox.Show("Вы перешли на 2 уровень!!!");
                progressBar1.Value = 25;
                timer1.Interval = 200;
                h1 = false;
            }
            if (game.level == 3)
            {
                if (h2 == true) MessageBox.Show("Вы перешли на 3 уровень!!!");
                progressBar1.Value = 50;
                timer1.Interval = 160;
                h2 = false;
            }
            if (game.level == 4)
            {
                if (h3 == true) MessageBox.Show("Вы перешли на 4 уровень!!!");
                progressBar1.Value = 85;
                timer1.Interval = 130;
                h3 = false;
            }
            if (game.level == 5)
            {
                if (h4 == true) MessageBox.Show("Вы перешли на 5 уровень!!!");
                timer1.Interval = 98;
                h4 = false;
            }
            if (game.level == 6)
            {
                if (h4 == true) MessageBox.Show("Вы выиграли!!!");
               
                h4 = false;
            }
            if (game.snake.k == 0) { /*Konec();*/  game.endplay(); Close(); }
            timer1.Enabled = true;
        }
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W && game.snake.course != Snake.Course.DOWN)
            {
                game.snake.course = Snake.Course.UP;
            }
            if (e.KeyCode == Keys.S && game.snake.course != Snake.Course.UP)
            {
                game.snake.course = Snake.Course.DOWN;
            }
            if (e.KeyCode == Keys.A && game.snake.course != Snake.Course.RIGHT)
            {

                game.snake.course = Snake.Course.LEFT;
            }
            if (e.KeyCode == Keys.D && game.snake.course != Snake.Course.LEFT)
            {
                game.snake.course = Snake.Course.RIGHT;
            }
            if (e.KeyCode == Keys.E)
            {
                timer1.Enabled = false;
            }
            if (e.KeyCode == Keys.R)
            {
                timer1.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox5.Visible = true;
            //pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            pictureBox5.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Application.Exit();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            view = new Bitmap(pictureBox4.Width, pictureBox4.Height); // инициализируем второй буфер
            game.snake.g = Graphics.FromImage((Image)view); // и графику для него
        }
         public void FuncSave()
        {
            Save save = new Save();
            save.SerializeObject("./save.bin", game);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FuncSave();
        }
    }
}
