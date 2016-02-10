using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;

namespace Design
{
    class anBrush
    {
        public Bitmap myBrush;

        public anBrush()
        {
            myBrush = new Bitmap(5, 5); // создали плоскость 5*5

            //заполнили все пиксели красным цветом
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    myBrush.SetPixel(i, j, Color.Red);
            
            //закрасили черным цветом крестик
            myBrush.SetPixel(0, 2, Color.Black);
            myBrush.SetPixel(1, 2, Color.Black);

            myBrush.SetPixel(2, 0, Color.Black);
            myBrush.SetPixel(2, 1, Color.Black);
            myBrush.SetPixel(2, 2, Color.Black);
            myBrush.SetPixel(2, 3, Color.Black);
            myBrush.SetPixel(2, 4, Color.Black);

            myBrush.SetPixel(3, 2, Color.Black);
            myBrush.SetPixel(4, 2, Color.Black);

            //красные пиксели - не будут использованы в рисовании 
            //черные пиксели - будут использованы при рисовании
        }
    }
}
