
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
        public Buffer Registers, Memory, Stack;
        public List<Type> Structs;
        //public Dictionary<string, object> Instances;
        Commands cmd;

        public TaskState(uint memorySize, uint stackSize)
        {
            Registers = new Buffer(186);
            Memory = new Buffer(memorySize);
            Stack = new Buffer(stackSize);

            cmd = new Commands(this);
            byte* ptr = Registers.AsByte;
            ptr += 32;
            *((ulong*)ptr) = 
        }

        public void Free()
        {
            Registers.Free();
            Memory.Free();
            Stack.Free();
        }
    }
}
