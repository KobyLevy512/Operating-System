
using System;
using System.Collections.Generic;
using System.IO;

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
        public delegate void RuntimeError(string reason);

        public Buffer Registers, Memory, Stack;
        public List<Type> Structs;
        public event RuntimeError OnRuntimeError;
        //public Dictionary<string, object> Instances;
        Commands cmd;
        private List<Buffer> allocationTable;
        public ulong* EspPtr, EcpPtr;
        public TaskState(uint memorySize, uint stackSize)
        {
            Registers = new Buffer(186);
            Memory = new Buffer(memorySize);
            Stack = new Buffer(stackSize);

            cmd = new Commands(this);
            allocationTable = new List<Buffer>();
            Structs = new List<Type>();

            byte* ptr = Registers.AsByte;
            ptr += 32;
            EspPtr = (ulong*)ptr;
            *EspPtr = 0;
            ptr += 8;
            EcpPtr = (ulong*)ptr;
            *EcpPtr = 0;
        }

        public void ExecuteCommand(BinaryReader reader)
        {
            if (!cmd.MakeCommands[reader.ReadByte()](reader))
            {
                OnRuntimeError?.Invoke(cmd.LastMsg);
            }
        }
        public uint Alloc(uint size)
        {
            Buffer b = new Buffer(size);
            allocationTable.Add(b);
            return b.Address;
        }

        public void FreeAlloc(uint address)
        {
            for(int i = 0; i < allocationTable.Count; i++)
            {
                if (allocationTable[i].Address == address)
                {
                    allocationTable[i].Free();
                    allocationTable.RemoveAt(i);
                }
            }
        }
        public void Free()
        {
            Registers.Free();
            Memory.Free();
            Stack.Free();
            while(allocationTable.Count > 0)
            {
                allocationTable[0].Free();
                allocationTable.RemoveAt(0);
            }
        }
    }
}
