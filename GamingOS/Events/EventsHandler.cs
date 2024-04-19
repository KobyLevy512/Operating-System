using System.Collections.Generic;
using System.Linq;

namespace GamingOS.Events
{
    public class EventsHandler
    {
        public List<IEventable> Callbacks = new List<IEventable>();

        public void Dispatch()
        {
            //Keyboard events.
            List<IEventable> focused = Callbacks.Where(c=>c.IsFocus).ToList();
            if(Cosmos.System.KeyboardManager.TryReadKey(out Cosmos.System.KeyEvent eve))
            {
                if(eve.Type == Cosmos.System.KeyEvent.KeyEventType.Make)
                {
                    foreach(var c in focused)
                    {
                        c.OnKeyDown(eve);
                    }
                }
                else
                {
                    foreach (var c in focused)
                    {
                        c.OnKeyUp(eve);
                    }
                }
            }

        }
    }
}
