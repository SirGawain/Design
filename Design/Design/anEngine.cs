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
    class anEngine
    {
        private int size_x, size_y; //размер изображения
        //private int scroll_x, scroll_y; // положение полос прокрутки
        private int screen_width, screen_heigth; //размер окна (объекта AnT)
        private int ActiveLayerNum; //номер активного слоя
        private List <anLayer> Layers; // массив слоев
        private anBrush standartBrush; 

        public anEngine (int size_x, int size_y, int screen_width, int screen_heigth)
        {
            this.size_x = size_x;
            this.size_y = size_y;
            this.screen_width = screen_width;
            this.screen_heigth = screen_heigth;

            Layers = new List<anLayer>();
            Layers.Add(new anLayer(size_x, size_y)); // добавили первый слой
            ActiveLayerNum = 0;

            standartBrush = new anBrush(); 
        }
        
        public void Drawing(int x, int y)
        {
            Layers[ActiveLayerNum].DrawBrush(standartBrush, x, y);
        }

        public void SwapImage()
        {
            Layers[0].RenderLayer();
        }
    }
}
