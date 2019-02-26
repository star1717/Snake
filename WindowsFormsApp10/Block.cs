using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp10
{       [Serializable]
        class Block
        {
            public int width = 20;
            public int height = 20;
            public int x;
            public int y;
            bool ex;
            Rectangle obj;
            Bitmap pict= new Bitmap(Image.FromFile("rab.png"));
            // Pen pen = new Pen(Color.Beige, 2);

            public virtual void draw(Graphics g)
            {

               if (!ex)
               {

                obj = new Rectangle(x, y, width, height);
                g.DrawImage(pict, obj);
                ex = true;
               }

               else
               {
                ex = false;
               }
            }
            virtual public void hide(Graphics g)
            {           
            g.FillRectangle(Brushes.Chocolate, obj);
            }  
        }
}
