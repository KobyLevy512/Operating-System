
using Cosmos.System.Network.IPv4;
using System;

namespace GamingOS.Tasks
{
    public unsafe class Buffer
    {
        public uint Size;
        public uint Address;
        public byte* Data;

        public Buffer(uint size)
        {
            Data = Cosmos.Core.Memory.Heap.Alloc(size);
            Address = new UIntPtr(Data).ToUInt32();
        }
        public byte* AsByte
        {
            get => Data;
        }

        public ushort* AsShort
        {
            get=>(ushort*)Data;
        }
        public uint* AsUInt
        {
            get=>(uint*)Data;
        }
        public ulong* AsULong
        {
            get => (ulong*)Data;
        }
        public float* AsFloat
        {
            get=>(float*)Data;
        }
        public double* AsDouble
        {
            get => (double*)Data;
        }
        public void Free()
        {
            Cosmos.Core.Memory.Heap.Free(Data);
        }
    }
}
