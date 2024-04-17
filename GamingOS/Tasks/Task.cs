
using System.IO;

namespace GamingOS.Tasks
{
    //Task(.runable) file format
    //Header
    //Company Name(20) : char
    //Task Name(20) : char
    //Priority: byte
    //IsBackground: byte
    //MemorySize: uint
    //StackSize: uint
    public class Task
    {
        public uint Priority;
        public string Company;
        public string Name;
        public bool IsMinimize;
        public bool BackgroundTask;
        TaskState state;

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

            }
        }
    }
}
