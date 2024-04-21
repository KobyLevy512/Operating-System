using Cosmos.System;
using GamingOS.Utils;
using System.Collections.Generic;
using System.Linq;

namespace GamingOS.Events
{
    public class EventsHandler
    {
        public List<IEventable> Callbacks = new List<IEventable>();
        IEventable focused;
        Vector lastMouse = new Vector(0, 0);

        public void Dispatch()
        {
            if(focused == null)
            {
                foreach (IEventable e in Callbacks)
                {
                    if (e.Location.PointIsInside(lastMouse))
                    {
                        focused.IsFocus = false;
                        focused.OnLostFocus();
                        e.IsFocus = true;
                        e.OnGainFocus();
                        break;
                    }
                }
            }
            //Keyboard events.
            if (KeyboardManager.TryReadKey(out KeyEvent eve))
            {
                if(eve.Type == KeyEvent.KeyEventType.Make)
                {
                    focused.OnKeyDown(eve);
                }
                else
                {
                    focused.OnKeyUp(eve);
                }
            }

            //Mouse events
            if (MouseManager.X != lastMouse.X || MouseManager.Y != lastMouse.Y)
            {
                MouseState state = MouseManager.MouseState;
                lastMouse.X = (int)MouseManager.X;
                lastMouse.Y = (int)MouseManager.Y;
                if (focused.Location.PointIsInside(lastMouse))
                {
                    if (!focused.MouseInside)
                    {
                        focused.OnMouseEnter(lastMouse.X - focused.Location.Position.X, lastMouse.Y - focused.Location.Position.Y, state);
                        focused.MouseInside = true;
                    }
                    focused.OnMouseMove(lastMouse.X, lastMouse.Y, state);
                    if (state != MouseState.None && MouseManager.LastMouseState == MouseState.None)
                    {
                        focused.OnMouseDown(lastMouse.X, lastMouse.Y, state);
                    }
                    else if (state == MouseState.None && MouseManager.LastMouseState != MouseState.None)
                    {
                        focused.OnMouseUp(lastMouse.X, lastMouse.Y, state);
                    }
                }
                else
                {
                    focused.MouseInside = false;
                    if(state == MouseState.Left)
                    {
                        foreach(IEventable e in Callbacks)
                        {
                            if(e.Location.PointIsInside(lastMouse))
                            {
                                focused.IsFocus = false;
                                focused.OnLostFocus();
                                e.IsFocus = true;
                                e.OnGainFocus();
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MouseState state = MouseManager.MouseState;
                if(focused.MouseInside)
                {
                    if (state != MouseState.None && MouseManager.LastMouseState == MouseState.None)
                    {
                        focused.OnMouseDown(lastMouse.X, lastMouse.Y, state);
                    }
                    else if (state == MouseState.None && MouseManager.LastMouseState != MouseState.None)
                    {
                        focused.OnMouseUp(lastMouse.X, lastMouse.Y, state);
                    }
                }
                else
                {
                    if (state == MouseState.Left)
                    {
                        foreach (IEventable e in Callbacks)
                        {
                            if (e.Location.PointIsInside(lastMouse))
                            {
                                focused.IsFocus = false;
                                focused.OnLostFocus();
                                e.IsFocus = true;
                                e.OnGainFocus();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
