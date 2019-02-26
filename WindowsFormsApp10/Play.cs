using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp10
{
    [Serializable]
    class Play
    {      
        private List<Rectangle> walls = new List<Rectangle>();
        Bitmap wal1 = new Bitmap(Image.FromFile("1.png"));
        Bitmap wal2 = new Bitmap(Image.FromFile("2.png"));
        Bitmap wal3 = new Bitmap(Image.FromFile("3.png"));
        Bitmap wal4 = new Bitmap(Image.FromFile("4.png"));
        Bitmap wal5 = new Bitmap(Image.FromFile("5.png"));
        Hardle stop=new Hardle();
        Hardle stop2 = new Hardle();
        public int level=1;
        List<Rectangle> field = new List<Rectangle>();// занятые ячейки
        List<Rectangle> field_bez_snake = new List<Rectangle>();
        private Random rnd = new Random();
        public Snake snake = new Snake();
        private Rabbit eda = new Rabbit();
        private Mangust mang = new Mangust();
        private Am am = new Am();
        
        int l = 1; int u = 0;int q = 0;
        SoundPlayer muz = new SoundPlayer();       
        public void run()
        {
            Rectangle size0 = new Rectangle(20, 20, 20, 20);
            snake.g.DrawImage(wal5, size0);
            size0 = new Rectangle(560, 20, 20, 20);
            snake.g.DrawImage(wal5, size0);
            size0 = new Rectangle(560, 580, 20, 20);
            snake.g.DrawImage(wal5, size0);
            size0 = new Rectangle(20, 580, 20, 20);
            snake.g.DrawImage(wal5, size0);
            walls.Add(size0);
            Rectangle size1 = new Rectangle(20, 40, 20, 20);
            for (int i = 0; i < 27; i++)
            {
                snake.g.DrawImage(wal1, size1);
                walls.Add(size1);                
                size1.Y = size1.Y + 20;
            }
            Rectangle size2 = new Rectangle(40, 20, 20, 20);
            for (int i = 0; i < 26; i++)
            {
                snake.g.DrawImage(wal2, size2);
                 walls.Add(size2);                
                size2.X = size2.X + 20;
            }
            Rectangle size3 = new Rectangle(560, 40, 20, 20);
            for (int i = 0; i < 27; i++)
            {
                snake.g.DrawImage(wal3, size3);
                walls.Add(size3);
                size3.Y = size3.Y + 20;
            }
            Rectangle size4 = new Rectangle(40, 580, 20, 20);
            for (int i = 0; i < 26; i++)
            {
                snake.g.DrawImage(wal4, size4);
                walls.Add(size4);
                size4.X = size4.X + 20;
            }

            snake.DrawSnake();
            for (int i=0; i<snake.snake.Count; i++)
            {
                    field.Add(snake.snake[i]);                
            }
            //snake.hide();
            if (snake.snake[0].IntersectsWith(eda.rabb))//съел еду
            {
                snake.AddSnake(eda.rabb);
                eda.hide();
                if (snake.dlina() == 10) level = 2;
                if (snake.dlina() == 15) level = 3;
                if (snake.dlina() == 20) level = 4;
                if (snake.dlina() == 25) level = 5;
                if (snake.dlina() == 40) level = 5;
            }
            for (int i=0; i < stop.all_hard.Count; i++)
            {
                field.Add(stop.all_hard[i]);
            }
            int x1 = rnd.Next(40, 540);
            int y1 = rnd.Next(40, 560);

            for (int i = 0; i < field.Count; i++)
                {
                    if (new Rectangle(x1, y1, 20, 20).IntersectsWith(field[i]) || (x1 % 20!=0) || (y1 % 20 != 0))
                    {
                        x1 = rnd.Next(40, 540);
                        y1 = rnd.Next(40, 560);
                        i = 0;
                    }
                }

                mang.setx(x1);
                mang.sety(y1);
                mang.draw(snake.g);
                field.Add(mang.mann);
            
                int x = rnd.Next(40, 540);
                int y = rnd.Next(40, 560);

                for (int i = 0; i < field.Count; i++)
                {
                    if (new Rectangle(x, y, 20, 20).IntersectsWith(field[i]) || (x % 20 != 0) || (y % 20 != 0))
                    {
                        x = rnd.Next(40, 540);
                        y = rnd.Next(40, 560);
                        i = 0;
                    }
                }
                
                eda.setx(x);
                eda.sety(y);
                eda.draw(snake.g);
                if (field.IndexOf(eda.rabb) == -1 )
                {
                    field.Add(eda.rabb);
                }
           
            if (level >= 2 )
            {
                prep(stop);
                prep(stop);
                prep(stop);
            }
            if (level >= 3)
            {
            int x4 = rnd.Next(40, 540);
            int y4 = rnd.Next(40, 560);

            for (int i = 0; i < field.Count; i++)
            {
                if (new Rectangle(x4, y4, 20, 20).IntersectsWith(field[i]) || (x4 % 20 != 0) || (y4 % 20 != 0))
                {
                    x4 = rnd.Next(40, 540);
                    y4 = rnd.Next(40, 560);
                    i = 0;
                }
            }

            am.setx(x4);
            am.sety(y4);
            am.draw(snake.g);
            field.Add(am.amm);
                for (int i = 0; i < field.Count; i++)
                {
                    for (int j = 0; j < snake.snake.Count; j++)
                    {
                        if (field[i] != snake.snake[j]) q = 1; else { q = 0; break; }
                    }
                    if (q==1) field_bez_snake.Add(field[i]);
                }
                    for (int i = 0; i < field_bez_snake.Count; i++)
                {
                    if (!new Rectangle(am.amm.X + 20, am.amm.Y, 20, 20).IntersectsWith(field_bez_snake[i]) && am.amm.X + 20 < 540 && u != 1)
                    {
                        l = 1;
                    }
                    else { l = 0; break; }
                }
                if (l == 1) am.moveRight();
                if (l == 0)
                    for (int i = 0; i < field_bez_snake.Count; i++)
                    {
                        if (!new Rectangle(am.amm.X - 20, am.amm.Y, 20, 20).IntersectsWith(field_bez_snake[i]) && am.amm.X - 20 > 40)
                        {
                            u = 1;
                        }
                        else { u = 0; break; }
                    }
                if (u==1) am.moveLeft();
            }

            if (level >= 4)
            {
                prep(stop2);
                prep(stop2);
                prep(stop2);
            }

            snake.move();  
            if (snake.snake[0].IntersectsWith(mang.mann))//съел мангуста
            {              
                snake.k = 0;
                mang.hide();

              //  field.RemoveAt(field.IndexOf(new Rectangle(x1, y1, 20, 20)));
            }
            for(int i=0; i < snake.snake.Count; i++)
            { 
              if (snake.snake[i].IntersectsWith(am.amm))//съел монстра
              {
                 snake.k = 0;
                 am.hide();
              }
            }
              
            for (int i = 0; i < stop.all_hard.Count; i++)//врезался в препядствие
            {
                if (snake.snake[0].IntersectsWith(stop.all_hard[i]))
                {
                    snake.k = 0;
                    break;
                }
            }
            for (int i = 0; i < stop2.all_hard.Count; i++)//врезался в препядствие
            {
                if (snake.snake[0].IntersectsWith(stop2.all_hard[i]))
                {
                    snake.k = 0;
                    break;
                }
            }
            for (int i = 1; i < snake.snake.Count - 1; i++)//сам в себя
            {
                if (snake.snake[0].IntersectsWith(snake.snake[i]))
                {
                    snake.k = 0;
                }
            }
                for (int i = 0; i < walls.Count; i++)
            {
                if (snake.snake[0].IntersectsWith(walls[i])) snake.k = 0;
            }
             field.Clear();
            field_bez_snake.Clear();
            walls.Clear();
        }
            public void endplay()
            {           
            muz = new SoundPlayer("p.wav");
            muz.Play();
            MessageBox.Show("Вы проиграли\nДлина змейки равна: " + snake.dlina().ToString(),"Досвидули");
            }
       void prep(Hardle stopp)
        {
            int x3 = rnd.Next(40, 500);
            int y3 = rnd.Next(40, 520);
            for (int i = 0; i < field.Count; i++)
            {
                if (new Rectangle(x3, y3, 20, 20).IntersectsWith(field[i]) || new Rectangle(x3 + 20, y3, 20, 20).IntersectsWith(field[i]) || new Rectangle(x3, y3 + 20, 20, 20).IntersectsWith(field[i]) || new Rectangle(x3, y3 + 40, 20, 20).IntersectsWith(field[i]) || (x3 % 20 != 0) || (y3 % 20 != 0))
                {
                    x3 = rnd.Next(40, 500);
                    y3 = rnd.Next(40, 520);
                    i = 0;
                }
            }
            stopp.setx(x3);
            stopp.sety(y3);
            stopp.draw(snake.g);

            stopp.setx(x3 + 20);
            stopp.sety(y3);
            stopp.draw(snake.g);

            stopp.setx(x3);
            stopp.sety(y3 + 20);
            stopp.draw(snake.g);

            stopp.setx(x3);
            stopp.sety(y3 + 40);
            stopp.draw(snake.g);
        }


    }
}
