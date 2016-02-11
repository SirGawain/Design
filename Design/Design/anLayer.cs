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
    class anLayer 
    {
        public int width, heigth; //размеры
        private int[,,] DrawPlace; //область рисунка (x,y,color)
        private bool isVisible; // флаг видимости слоя
        private Color ActiveColor; //текущий установленный цвет

        public anLayer (int width, int heigth)
        {
            this.width = width;
            this.heigth = heigth;

            //массив. каждая точка имеет 3 составляющие цвета (r/g/b)
            // + 4 ячейка - флаг (0 - пиксель пустой, 1 - не пустой)
            DrawPlace = new int[width, heigth, 4];

            //устанавливаем все пиксели пустыми
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigth; j++)
                    DrawPlace[i, j, 3] = 0;

            isVisible = true;
            ActiveColor = Color.Black;
        }

        public int [,,] GetDrawingPlace()
        {
            return DrawPlace;
        }

        public void SetVisibility(bool state)
        {
            isVisible = state;
        }
        
        public bool GetVisibility()
        {
            return isVisible;
        }

        public void DrawBrush (anBrush BR, int x, int y)
        {
            //определяем позицию  
            int start_X = x - BR.myBrush.Width / 2;
            int start_Y = y - BR.myBrush.Height / 2;
            int end_X = start_X + BR.myBrush.Width;
            int end_Y = start_Y + BR.myBrush.Height;

            //корректируем позицию (не выход за границы)
            if (start_X < 0)
                start_X = 0;
            if (start_Y < 0)
                start_Y = 0;
            if (end_X > width)
                end_X = width;
            if (end_Y > heigth)
                end_Y = heigth;

            //счетчик маски кисти
            int count_X =0, count_Y = 0;

            //наносим кисть на слой
            for(int i = start_X; i < end_X; i++)
            {
                count_Y = 0;
                for(int j=start_Y; j<end_Y; j++)
                {
                    Color temp = BR.myBrush.GetPixel(count_X, count_Y);
                    if(!(temp.R==255 && temp.G==0 && temp.B==0)) //цвет не красный
                    {
                        DrawPlace[i, j, 0] = ActiveColor.R;
                        DrawPlace[i, j, 1] = ActiveColor.G;
                        DrawPlace[i, j, 2] = ActiveColor.B;
                        DrawPlace[i, j, 3] = 1;
                    }
                    count_Y++;
                }
                count_X++;
            }
        }
        
        public void RenderLayer()
        {
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigth; j++)
                {
                    if(DrawPlace[i,j,3]==1)
                    {
                        Gl.glColor3f(DrawPlace[i, j, 0], DrawPlace[i, j, 1], DrawPlace[i, j, 2]);
                        Gl.glVertex2i(i,j);
                    }
                }
            Gl.glEnd();
        } 
    }
}
