using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    [Serializable]
    class Snake
    {
        public List<Rectangle> walls = new List<Rectangle>();
        public int n = 3;//длина змейки
        private int addX, addY; // смещение координат   
        public int k = 1;//вых из игры       
        public List<Rectangle> snake = new List<Rectangle>(); // змейка    
        public enum Course { UP, DOWN, LEFT, RIGHT };
        public Course course;
        [NonSerialized]
        public Graphics g;     
        Bitmap head = new Bitmap(Image.FromFile("3sne.png"));
        Bitmap body = new Bitmap(Image.FromFile("6sne.png"));
        Bitmap hvost = new Bitmap(Image.FromFile("9sne.png"));
        //Bitmap sne = new Bitmap(Image.FromFile("am1.png"));

        public int dlina()
        {
            return (n);
        }
        public void DrawSnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0)
                { // рисуем голову                    
                    head.MakeTransparent();
                    g.DrawImage(head, snake[i]);
                }
                
                if (i == snake.Count - 1)
                {
                    if (snake[i - 1].X > snake[i].X && snake[i - 1].Y == snake[i].Y)
                    {
                        hvost = new Bitmap(Image.FromFile("9sne.png"));
                    }
                    if (snake[i - 1].X < snake[i].X && snake[i - 1].Y == snake[i].Y)
                    {
                        hvost = new Bitmap(Image.FromFile("11sne.png"));
                    }
                    if (snake[i - 1].X == snake[i].X && snake[i - 1].Y > snake[i].Y)
                    {
                        hvost = new Bitmap(Image.FromFile("10sne.png"));
                    }
                    if (snake[i - 1].X == snake[i].X && snake[i - 1].Y < snake[i].Y)
                    {
                        hvost = new Bitmap(Image.FromFile("12sne.png"));
                    }
                    hvost.MakeTransparent();
                    g.DrawImage(hvost, snake[i]);
                }
                if (i!=0 && i!=snake.Count-1) // рисуем оставшиеся сегменты
                {
                    if (snake[i-1].X!= snake[i].X && snake[i - 1].Y == snake[i].Y)
                    {
                        body= new Bitmap(Image.FromFile("6sne.png"));
                    }
                    else body = new Bitmap(Image.FromFile("5sne.png"));
                    if (snake[i].Y== snake[i+1].Y && snake[i].X < snake[i + 1].X && snake[i].Y > snake[i - 1].Y && snake[i].X == snake[i - 1].X || snake[i].Y == snake[i - 1].Y && snake[i].X < snake[i - 1].X && snake[i].Y > snake[i + 1].Y && snake[i].X == snake[i + 1].X)
                    {
                        body = new Bitmap(Image.FromFile("14sne.png"));
                    }
                    if (snake[i].Y < snake[i + 1].Y && snake[i].X == snake[i + 1].X && snake[i].Y == snake[i - 1].Y && snake[i].X < snake[i - 1].X || snake[i].Y < snake[i - 1].Y && snake[i].X == snake[i - 1].X && snake[i].Y == snake[i + 1].Y && snake[i].X < snake[i + 1].X)
                    {
                        body = new Bitmap(Image.FromFile("15sne.png"));
                    }
                    if (snake[i].Y == snake[i + 1].Y && snake[i].X > snake[i + 1].X && snake[i].Y > snake[i - 1].Y && snake[i].X == snake[i - 1].X || snake[i].Y == snake[i - 1].Y && snake[i].X > snake[i - 1].X && snake[i].Y > snake[i + 1].Y && snake[i].X == snake[i + 1].X)
                    {
                        body = new Bitmap(Image.FromFile("17sne.png"));
                    }
                    if (snake[i].Y < snake[i + 1].Y && snake[i].X == snake[i + 1].X && snake[i].Y == snake[i - 1].Y && snake[i].X > snake[i - 1].X || snake[i].Y < snake[i - 1].Y && snake[i].X == snake[i - 1].X && snake[i].Y == snake[i + 1].Y && snake[i].X > snake[i + 1].X)
                    {
                        body = new Bitmap(Image.FromFile("16sne.png"));
                    }
                    body.MakeTransparent();
                    g.DrawImage(body, snake[i]);
                }

            }
        } //DrawSnake
        public void AddSnake(Rectangle r)//добавляем в конец змейки один блок
        {
            n++;
            snake.Add(r);
        }

        public Snake()
        {

        }
        public void AddVZmeyku()
        {
            // добавляем в змейку три начальных сегмента
            snake.Add(new Rectangle(200, 200, 20, 20));
            snake.Add(new Rectangle(200, 220, 20, 20));
            snake.Add(new Rectangle(200, 240, 20, 20));

            
        }
        public void hide()
        {
           // g.FillRectangle(Brushes.Chocolate, snake[snake.Count - 1]);
           // g.DrawRectangle(Pens.Chocolate, snake[snake.Count - 1]);
        }
 
        public void move()
        {
            // course =Course.up;
            // в зависимости от выбранного направления
            // наращиваем координаты головы (snake[0])
            
       

            if (course == Course.UP)
            {
                addX = 0;
                addY = -20;
                head = new Bitmap(Image.FromFile("2sne.png"));
            }

            if (course == Course.DOWN)
            {
                addX = 0;
                addY = 20;
                head = new Bitmap(Image.FromFile("13sne.png"));
            }

            if (course == Course.LEFT)
            {
                addX = -20;
                addY = 0;
                head = new Bitmap(Image.FromFile("4sne.png"));
            }

            if (course == Course.RIGHT)
            {
                addX = 20;
                addY = 0;
                 head = new Bitmap(Image.FromFile("3sne.png"));
            }

            Rectangle sled;
            Rectangle pred;
            // запоминаем значение старой головы
            // чтобы присвоить его след. сегменту
            // по циклу присваиваем значение предыдущего сегмента следующему
            pred = snake[0];
            for (int i = 0; i < snake.Count - 1; i++)
            {

                if (i == 0)
                {

                    snake[i] = new Rectangle(
                    snake[i].X + addX,
                    snake[i].Y + addY,
                    20, 20);

                    
                }
                if (!(snake[i + 1].IsEmpty))
                {
                    sled = snake[i + 1];
                    snake[i + 1] = pred;
                    pred = sled;
                    
                }
            }
        }
    }
}

