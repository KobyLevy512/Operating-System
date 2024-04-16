
namespace GamingOS.Tasks
{
    public class TaskRegister
    {
        ulong Value;

        public uint Lower32
        {
            get => (uint)(Value & 0xFFFFFFFF);
            set => Value = (Value & 0xFFFFFFFF00000000) | value;
        }
        public ushort Lower16
        {
            get => (ushort)(Value & 0xFFFF);
            set => Value = (Value & 0xFFFFFFFFFFFF0000) | value;
        }
        public byte Lower8
        {
            get => (byte)(Value & 0xFF);
            set => Value = (Value & 0xFFFFFFFFFFFFFF00) | value;
        }
        public byte Higher8
        {
            get => (byte)(Value & 0xFF00);
            set => Value = (Value & 0xFFFFFFFFFFFF00FF) | ((ulong)value << 8);
        }
    }
}
