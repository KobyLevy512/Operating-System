using Cosmos.System;
using Cosmos.System.Graphics;
using GamingOS.Events;
using GamingOS.Utils;

namespace GamingOS.Programs
{
    public class Inspector : SystemProgram
    {
        Bitmap buffer;
        BitmapGraphics gr;
        bool show = false;
        public Inspector(uint width, uint height)
        {
            buffer = new Bitmap(width, height, ColorDepth.ColorDepth32);
            gr = new BitmapGraphics(buffer);
            Location = new Location() { Position = new Vector(0, 0), Size = new Vector((int)width, (int)height)} ;
        }

        public override void Render()
        {
            if(IsFocus && show)
            {
                gr.DrawRectangle(0xffff0000, Location);
            }
        }
        public override void OnGainFocus()
        {

        }

        public override void OnKeyDown(KeyEvent key)
        {
        
        }

        public override void OnKeyUp(KeyEvent key)
        {

        }

        public override void OnLostFocus()
        {

        }

        public override void OnMinimize(bool isMinimize)
        {

        }

        public override void OnMouseDown(int x, int y, MouseState state)
        {

        }

        public override void OnMouseEnter(int x, int y, MouseState state)
        {

        }

        public override void OnMouseLeave(int x, int y, MouseState state)
        {

        }

        public override void OnMouseMove(int x, int y, MouseState state)
        {

        }

        public override void OnMouseUp(int x, int y, MouseState state)
        {
            if(state == MouseState.Right)
            {
                show = !show;
            }
        }

        public override void OnSizeChange(int width, int height)
        {

        }
    }
}
