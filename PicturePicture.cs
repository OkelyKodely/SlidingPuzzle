using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Picture_Picture
{
    public class PicturePicture : Form
    {
        MyPanel panel;
        Graphics graphics;
        List<Image> list = new List<Image>();

        public class TBitmap
        {
            public int x, y;

            public Bitmap bitmap;

            public TBitmap(Image img)
            {
                bitmap = new Bitmap(img);
            }
        }

        public class Cursor
        {
            public int x, y;
        }

        bool control = false;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Control)
            {
                control = true;
            }
            if (keyData == Keys.Up)
            {
                int xx = panel._.x;
                int yy = panel._.y;
                for (int i = 0; i < panel.bitmap.Count; i++)
                {
                    if (panel.bitmap[i].x == xx && panel.bitmap[i].y == yy &&
                        panel.bitmap[i].x == panel._empty.x && panel.bitmap[i].y - 125 == panel._empty.y)
                    {
                        panel.bitmap[i].y -= 125;
                        panel._empty.y += 125;
                    }
                }
                panel._.y -= 125;
            }
            else if (keyData == Keys.Down)
            {
                int xx = panel._.x;
                int yy = panel._.y;
                for (int i = 0; i < panel.bitmap.Count; i++)
                {
                    if (panel.bitmap[i].x == xx && panel.bitmap[i].y == yy &&
                        panel.bitmap[i].x == panel._empty.x && panel.bitmap[i].y + 125 == panel._empty.y)
                    {
                        panel.bitmap[i].y += 125;
                        panel._empty.y -= 125;
                    }
                }
                panel._.y += 125;
            }
            else if (keyData == Keys.Left)
            {
                int xx = panel._.x;
                int yy = panel._.y;
                for (int i = 0; i < panel.bitmap.Count; i++)
                {
                    if (panel.bitmap[i].x == xx && panel.bitmap[i].y == yy &&
                        panel.bitmap[i].x - 125 == panel._empty.x && panel.bitmap[i].y == panel._empty.y)
                    {
                        panel.bitmap[i].x -= 125;
                        panel._empty.x += 125;
                    }
                }
                panel._.x -= 125;
            }
            else if (keyData == Keys.Right)
            {
                int xx = panel._.x;
                int yy = panel._.y;
                for(int i=0; i<panel.bitmap.Count; i++)
                {
                    if (panel.bitmap[i].x == xx && panel.bitmap[i].y == yy &&
                        panel.bitmap[i].x + 125 == panel._empty.x && panel.bitmap[i].y == panel._empty.y)
                    {
                        panel.bitmap[i].x += 125;
                        panel._empty.x -= 125;
                    }
                }
                panel._.x += 125;
            }
            panel.Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public PicturePicture()
        {
            this.Text = "Sliding Puzzle";

            Cursor _ = new Cursor();

            Bitmap bitmap = new Bitmap(Environment.CurrentDirectory + "\\picture.gif");
            panel = new MyPanel(_, bitmap);
            graphics = panel.CreateGraphics();

            this.SetBounds(0, 0, 1000, 800);
            panel.SetBounds(0, 0, 1000, 800);
            panel.BackColor = Color.Chartreuse;
            //this.WindowState = FormWindowState.Maximized;

            this.Controls.Add(panel);

            Pen pen = new Pen(new SolidBrush(Color.Black));

            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Rectangle r = new Rectangle(i * (bitmap.Width / 4),
                                                y * (bitmap.Height / 4),
                                                bitmap.Width / 4,
                                                bitmap.Height / 4);

                    graphics.DrawRectangle(pen, r);

                    list.Add(cropImage(bitmap, r));
                }
            }

            for (int i = 0; i < 16; i++)
                panel.bitmap.Add(new TBitmap(list[i]));

            panel.setup();
        }

        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
            return (Image)(bmpCrop);
        }    
    }
}