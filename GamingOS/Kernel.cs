﻿using Cosmos.Core.Memory;
using Cosmos.System.Graphics;
using GamingOS.Resources;
using GamingOS.Styles;
using GamingOS.Tasks;
using System.Collections.Generic;
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
                new Sys.Graphics.VBECanvas(new Sys.Graphics.Mode(1920, 1080, Sys.Graphics.ColorDepth.ColorDepth32)),
                new Sys.FileSystem.CosmosVFS()
            );

            //Initialize mouse coordinates and size.
            Sys.MouseManager.ScreenWidth = 1920 - ResourceManager.CursorBitmap.Width;
            Sys.MouseManager.ScreenHeight = 1080 - ResourceManager.CursorBitmap.Height;
            Sys.MouseManager.X = 1920 / 2;
            Sys.MouseManager.Y = 1080 / 2;
        }

        protected override void Run()
        {
            //get reference to the globals
            VBECanvas canvas = Globals.Canvas;
            Style style = Globals.Style;
            List<Task> tasks = Globals.Tasks;

            //Clear the background
            canvas.Clear(style.Background);

            //Draw menu

            //Update all the tasks
            for(int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Execute();
            }

            //Draw the mouse
            canvas.DrawImageAlpha(ResourceManager.CursorBitmap, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y);

            //Collect unrefence object for the garbage collector.
            Heap.Collect();

            //Render the graphics to the screen.
            canvas.Display();
        }
    }
}
