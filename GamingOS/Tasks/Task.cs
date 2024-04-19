
using System.IO;

namespace GamingOS.Tasks
{
    //Task(.runable) file format
    //Header
    //Company Name(20) : char offset - 0
    //Task Name(20) : char offset - 20
    //Priority: byte offset - 41
    //IsBackground: byte offset -42
    //MemorySize: uint offset -43
    //StackSize: uint offset -47
    public class Task
    {
        public uint Priority;
        public string Company;
        public string Name;
        public bool IsMinimize;
        public bool BackgroundTask;
        public TaskState State;
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
                State = new TaskState(memSize, stackSize);
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
                if(reader.BaseStream.Position >= reader.BaseStream.Length - 1)
                {
                    Globals.Tasks.Remove(this);
                    break;
                }
                if (!State.ExecuteCommand(reader)) break;
            }
        }
    }
}
