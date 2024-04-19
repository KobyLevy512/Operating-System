
namespace GamingOS.Programs
{
    public unsafe class Debbuger
    {
        bool activate = true;
        string content = "";
        byte openKey = (byte)'p';
        byte clearKey = (byte)'c';
        public void AddMessage(string message)
        {
            content += message + "\n";
        }

        public void Execute()
        {
            if(Cosmos.System.KeyboardManager.TryReadKey(out Cosmos.System.KeyEvent key))
            {
                if(key.Key == Cosmos.System.ConsoleKeyEx.P)
                {
                    activate = !activate;
                }
            }

            if(activate)
            {
                if (Cosmos.System.KeyboardManager.TryReadKey(out key))
                {
                    if(key.Key == Cosmos.System.ConsoleKeyEx.C)
                    {
                        content = "";
                    }
                    else if(key.Key == Cosmos.System.ConsoleKeyEx.F)
                    {
                        content += Globals.Tasks[0].State.Registers.AsByte[0];
                    }
                }
                Globals.Canvas.DrawFilledRectangle
                (
                    Globals.Style.Foreground,
                    Globals.Canvas.Mode.Columns / 2 - 100,
                    Globals.Canvas.Mode.Rows - 101,
                    200,
                    100
                );
                Globals.Canvas.DrawString(content, Globals.Style.Font, Globals.Style.Background, Globals.Canvas.Mode.Columns / 2 - 95, Globals.Canvas.Mode.Rows - 95);
            }
        }
    }
}
