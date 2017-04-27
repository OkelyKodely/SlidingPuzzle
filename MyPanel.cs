using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Picture_Picture
{
    public class MyPanel : Panel
    {
        public Bitmap bitmap_, b_;

        public List<Picture_Picture.PicturePicture.TBitmap> bitmap = new List<Picture_Picture.PicturePicture.TBitmap>();

        public Picture_Picture.PicturePicture.Cursor _ = new Picture_Picture.PicturePicture.Cursor();

        public Picture_Picture.PicturePicture.Cursor _empty = new Picture_Picture.PicturePicture.Cursor();

        public MyPanel(Picture_Picture.PicturePicture.Cursor cursor, Bitmap b)
        {
            bitmap_ = b;
            _ = cursor;
            _empty.x = 375;
            _empty.y = 375;
        }

        public void setup()
        {
            bitmap[0].x = 0;
            bitmap[0].y = 0;
            bitmap[1].x = 125;
            bitmap[1].y = 0;
            bitmap[2].x = 250;
            bitmap[2].y = 0;
            bitmap[3].x = 375;
            bitmap[3].y = 0;

            bitmap[4].x = 0;
            bitmap[4].y = 125;
            bitmap[5].x = 125;
            bitmap[5].y = 125;
            bitmap[6].x = 250;
            bitmap[6].y = 125;
            bitmap[7].x = 375;
            bitmap[7].y = 125;

            bitmap[8].x = 0;
            bitmap[8].y = 250;
            bitmap[9].x = 125;
            bitmap[9].y = 250;
            bitmap[10].x = 250;
            bitmap[10].y = 250;
            bitmap[11].x = 375;
            bitmap[11].y = 250;
            
            bitmap[12].x = 0;
            bitmap[12].y = 375;
            bitmap[13].x = 125;
            bitmap[13].y = 375;
            bitmap[14].x = 250;
            bitmap[14].y = 375;
            bitmap[15].x = 375;
            bitmap[15].y = 500;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (bitmap_ != null)
            {
                b_ = bitmap_;
                bitmap_ = null;
            }
            else
            {
                bitmap_ = b_;
                b_ = null;
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (bitmap_ != null)
            {
                e.Graphics.DrawImage(bitmap_, 0, 0, 500, 500);
                e.Graphics.DrawString("Click Anywhere to Play", new Font("arial", 20f), new SolidBrush(Color.Black), 20, 540);
            }
            else
            {
                e.Graphics.DrawString("Click Anywhere to Preview", new Font("arial", 20f), new SolidBrush(Color.Black), 20, 540);
                for (int i = 0; i < 16; i++)
                    e.Graphics.DrawImage(bitmap[i].bitmap, bitmap[i].x, bitmap[i].y, 500 / 4, 500 / 4);
                Rectangle rect = new Rectangle(_.x, _.y, 125, 125);
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), rect);
            }
        }
    }
}