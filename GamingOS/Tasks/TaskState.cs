
using System;
using System.Collections.Generic;

namespace GamingOS.Tasks
{
    public unsafe class TaskState
    {
        public enum RegistersA
        {
            RAX,
            RBX, //8
            RCX, //
            RDX,
            EAX,
            EBX,
            ECX,
            EDX,
            AX,
            BX,
            CX,
            DX,
            AH,
            AL,
            BH,
            BL,
            CL,
            CH,
            DH,
            DL,

            ESP,
            ECP,

            FLG, //0 - error, 1 - sign,  2 - eq, 3 - gt, 4 - lt, 5 - overflow

            R1,
            R2,
            R3,
            R4,
            R5, 
            R6, 
            R7,
            XMM0,
            XMM1,
            XMM2,
            XMM3,
            XMM4,
            XMM5,
            XMM6,
            XMM7,
            XMM8,
            XMM9,
        }
        public byte* Registers;
        public byte* Memory;
        public byte* Stack;
        public uint MemoryLength;
        public uint StackLength;
        public List<Type> Structs;
        public Dictionary<string, object> Instances;
        Commands cmd;

        public TaskState(uint memorySize, uint stackSize)
        {
            Registers = Cosmos.Core.Memory.Heap.Alloc(186);

            MemoryLength = memorySize;
            Memory = Cosmos.Core.Memory.Heap.Alloc(memorySize);

            StackLength = stackSize;
            Stack = Cosmos.Core.Memory.Heap.Alloc(stackSize);
        }

        public void Free()
        {
            Cosmos.Core.Memory.Heap.Free(Registers);
            Cosmos.Core.Memory.Heap.Free(Memory);
            Cosmos.Core.Memory.Heap.Free(Stack);
        }
    }
}
