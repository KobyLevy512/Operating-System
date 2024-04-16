﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingOS.Tasks.CommandsImp
{
    public unsafe class Mov
    {
        public Mov(Commands c)
        {
            c.MakeCommands[1] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte loc = r.ReadByte();
                if (loc > 185)
                {
                    c.LastMsg = "Can't determine that register " + loc;
                    return false;
                }
                ptr += loc;
                *ptr = r.ReadByte();
                return true;
            };
            c.MakeCommands[2] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ptr += reg;
                uint loc = r.ReadUInt32();
                if (loc >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + loc;
                    return false;
                }
                *ptr = c.State.Memory[loc];
                return true;
            };
            c.MakeCommands[3] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                byte reg2 = r.ReadByte();
                if (reg2 > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                *(ptr + reg) = *(ptr + reg2);
                return true;
            };
            c.MakeCommands[4] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                c.State.Memory[mem] = r.ReadByte();
                return true;
            };
            c.MakeCommands[5] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                c.State.Memory[mem] = c.State.Memory[mem2];
                return true;
            };
            c.MakeCommands[6] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                byte* ptr = c.State.Registers;
                ptr += reg;
                c.State.Memory[mem] = *ptr;
                return true;
            };

            c.MakeCommands[7] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte loc = r.ReadByte();
                if (loc > 185)
                {
                    c.LastMsg = "Can't determine that register " + loc;
                    return false;
                }
                ptr += loc;
                ushort* shortPtr = (ushort*)ptr;
                *shortPtr = r.ReadUInt16();
                return true;
            };
            c.MakeCommands[8] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ptr += reg;
                ushort* shortPtr = (ushort*)ptr;

                uint loc = r.ReadUInt32();
                if (loc >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + loc;
                    return false;
                }
                *shortPtr = c.State.Memory[loc];
                return true;
            };
            c.MakeCommands[9] = (r) =>
            {
                byte* ptr = c.State.Registers;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ushort* dstPtr = (ushort*)(ptr + reg);

                byte reg2 = r.ReadByte();
                if (reg2 > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ushort* srcPtr = (ushort*)(ptr + reg2);
                *dstPtr = *srcPtr;
                return true;
            };
            c.MakeCommands[10] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                ushort* ptr = (ushort*)(c.State.Memory + mem); 
                *ptr = r.ReadUInt16();
                return true;
            };
            c.MakeCommands[11] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                ushort* ptrDst = (ushort*)(c.State.Memory + mem);
                ushort* ptrSrc = (ushort*)(c.State.Memory + mem2);
                *ptrDst = *ptrSrc;
                return true;
            };
            c.MakeCommands[12] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.MemoryLength)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ushort* ptr = (ushort*)(c.State.Registers + reg);
                ushort* ptr2 = (ushort*)(c.State.Memory + mem);
                
                *ptr2 = *ptr;
                return true;
            };
        }
    }
}