using Cosmos.System;
using GamingOS.Events;
using GamingOS.Utils;

namespace GamingOS.Programs
{
    public class SystemProgram : IEventable
    {
        public Location Location { get; set; }
        public bool MouseInside { get; set; }
        public bool IsFocus { get; set; }
        public bool IsBackground = false;
        public SystemProgram()
        {
            MouseInside = false;
            IsFocus = false;
            Location = new Location() { Position = new Vector(0,0), Size = new Vector(0,0)};
        }

        public virtual void Render()
        {

        }
        public virtual void OnGainFocus()
        {

        }

        public virtual void OnKeyDown(KeyEvent key)
        {
        }

        public virtual void OnKeyUp(KeyEvent key)
        { 
        }

        public virtual void OnLostFocus()
        {
        }

        public virtual void OnMinimize(bool isMinimize)
        {
        }

        public virtual void OnMouseDown(int x, int y, MouseState state)
        {
        }

        public virtual void OnMouseEnter(int x, int y, MouseState state)
        {
        }

        public virtual void OnMouseLeave(int x, int y, MouseState state)
        {
        }

        public virtual void OnMouseMove(int x, int y, MouseState state)
        {
        }

        public virtual void OnMouseUp(int x, int y, MouseState state)
        {
        }

        public virtual void OnSizeChange(int width, int height)
        {
        }
    }
}
