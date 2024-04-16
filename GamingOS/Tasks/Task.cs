
namespace GamingOS.Tasks
{
    //Task(.runable) file format
    //Header
    //Company Name(20) : char
    //Task Name(20) : char
    //Priority: byte
    //IsBackground: byte
    public class Task
    {
        public uint Priority;
        public string Company;
        public string Name;
        public bool IsMinimize;
        public bool BackgroundTask;

        public Task() 
        {
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
