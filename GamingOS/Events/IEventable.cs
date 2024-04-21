
using Cosmos.System;
using GamingOS.Utils;

namespace GamingOS.Events
{
    public interface IEventable
    {
        public Location Location { get; set; }
        public bool MouseInside {  get; set; }
        public bool IsFocus {  get; set; }
        public void OnMouseEnter(int x, int y, MouseState state);
        public void OnMouseLeave(int x, int y, MouseState state);
        public void OnMouseMove(int x, int y, MouseState state);
        public void OnMouseDown(int x, int y, MouseState state);
        public void OnMouseUp(int x, int y, MouseState state);
        public void OnGainFocus();
        public void OnLostFocus();
        public void OnMinimize(bool isMinimize);
        public void OnSizeChange(int width, int height);
        public void OnKeyDown(KeyEvent key);
        public void OnKeyUp(KeyEvent key);
    }
}
