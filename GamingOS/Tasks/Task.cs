
using System.IO;

namespace GamingOS.Tasks
{
    //Task(.runable) file format
    //Header
    //Company Name(20) : char offset - 0
    //Task Name(20) : char offset - 20
    //Priority: byte offset - 21
    //IsBackground: byte offset -22
    //MemorySize: uint offset -23
    //StackSize: uint offset -27
    public class Task
    {
        public uint Priority;
        public string Company;
        public string Name;
        public bool IsMinimize;
        public bool BackgroundTask;
        TaskState state;
        BinaryReader reader;
        public Task(byte[] opcodes)
        {
            BinaryReader read = new BinaryReader(new MemoryStream(opcodes));
            try
            {
                Company = read.ReadChars(20).ToString();
                Name = read.ReadChars(20).ToString();
                Priority = read.ReadByte() * 1000u;
                BackgroundTask = read.ReadByte() != 0;
                uint memSize = read.ReadUInt32();
                uint stackSize = read.ReadUInt32();
                state = new TaskState(memSize, stackSize);
                state.OnRuntimeError += (msg) =>
                {
                    //Show alert.
                    Globals.Tasks.Remove(this);
                };
                read.Close();
                MemoryStream newStream = new MemoryStream(opcodes, 31,opcodes.Length - 31, false);
                reader = new BinaryReader(newStream);
            }
            catch
            {

            }

            Globals.Tasks.Add(this);
        }
        public void Execute()
        {
            for (int i = 0; i < Priority; i++)
            {
                state.ExecuteCommand(reader);
            }
        }
    }
}
