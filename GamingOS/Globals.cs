using Cosmos.System.FileSystem;
using Cosmos.System.Graphics;
using GamingOS.Styles;
using GamingOS.Tasks;
using System.Collections.Generic;

namespace GamingOS
{
    public static class Globals
    {
        public static Kernel Kernal;
        public static Style Style;
        public static VBECanvas Canvas;
        public static CosmosVFS Drive;
        public static List<Task> Tasks;

        /// <summary>
        /// Initialize all the globals
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="style"></param>
        /// <param name="canvas"></param>
        /// <param name="drive"></param>
        public static void Initialize(Kernel kernel, Style style, VBECanvas canvas, CosmosVFS drive)
        {
            Kernal = kernel;
            Style = style;
            Canvas = canvas;
            Drive = drive;
            Tasks = new List<Task>();

            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(Drive);
        }
    }
}
