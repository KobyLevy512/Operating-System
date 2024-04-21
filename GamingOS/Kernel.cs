using Cosmos.Core.Memory;
using Cosmos.System.Graphics;
using GamingOS.Programs;
using GamingOS.Resources;
using GamingOS.Styles;
using Sys = Cosmos.System;

namespace GamingOS
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            //Init all the globals.
            Globals.Initialize
            (
                this,
                new Style(Style.StyleType.Green),
                new VBECanvas(new Mode(1920, 1080, ColorDepth.ColorDepth32))
            );

            Globals.SystemPrograms.Add(new Inspector(1920, 1080));

            //Initialize mouse coordinates and size.
            Sys.MouseManager.ScreenWidth = 1920 - ResourceManager.CursorBitmap.Width;
            Sys.MouseManager.ScreenHeight = 1080 - ResourceManager.CursorBitmap.Height;
            Sys.MouseManager.X = 1920 / 2;
            Sys.MouseManager.Y = 1080 / 2;

        }

        protected override void Run()
        {
            //Clear the background
            Globals.Canvas.Clear(Globals.Style.Background.Color);

            //Dispatch all the system events.
            Globals.Events.Dispatch();

            //Render all the system programs.
            foreach(SystemProgram program in Globals.SystemPrograms)
            {
                program.Render();
            }

            //Update all the tasks
            for (int i = 0; i < Globals.Tasks.Count; i++)
            {
                Globals.Tasks[i].Execute();
            }

            //Draw the mouse
            Globals.Canvas.DrawImageAlpha(ResourceManager.CursorBitmap, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y);

            //Collect unrefence object for the garbage collector.
            Heap.Collect();

            //Render the graphics to the screen.
            Globals.Canvas.Display();
        }
    }
}
