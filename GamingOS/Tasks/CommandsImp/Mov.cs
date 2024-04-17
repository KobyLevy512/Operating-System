

namespace GamingOS.Tasks.CommandsImp
{
    public unsafe class Mov
    {
        public Mov(Commands c)
        {
            c.MakeCommands[1] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte loc = r.ReadByte();
                if (loc > 185)
                {
                    c.LastMsg = "Can't determine that register " + loc;
                    return false;
                }
                ptr += loc;
                *ptr = r.ReadByte();
                c.State.EcpPtr += 2;
                return true;
            };
            c.MakeCommands[2] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ptr += reg;
                uint loc = r.ReadUInt32();
                if (loc >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + loc;
                    return false;
                }
                *ptr = c.State.Memory.AsByte[loc];
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[3] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
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
                c.State.EcpPtr += 2;
                return true;
            };
            c.MakeCommands[4] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                c.State.Memory.AsByte[mem] = r.ReadByte();
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[5] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                c.State.Memory.AsByte[mem] = c.State.Memory.AsByte[mem2];
                c.State.EcpPtr += 8;
                return true;
            };
            c.MakeCommands[6] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
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
                byte* ptr = c.State.Registers.AsByte;
                ptr += reg;
                c.State.Memory.AsByte[mem] = *ptr;
                c.State.EcpPtr += 5;
                return true;
            };

            c.MakeCommands[7] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte loc = r.ReadByte();
                if (loc > 185)
                {
                    c.LastMsg = "Can't determine that register " + loc;
                    return false;
                }
                ptr += loc;
                ushort* shortPtr = (ushort*)ptr;
                *shortPtr = r.ReadUInt16();
                c.State.EcpPtr += 3;
                return true;
            };
            c.MakeCommands[8] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ptr += reg;
                ushort* shortPtr = (ushort*)ptr;

                uint loc = r.ReadUInt32();
                if (loc >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + loc;
                    return false;
                }
                *shortPtr = c.State.Memory.AsByte[loc];
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[9] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
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
                c.State.EcpPtr += 2;
                return true;
            };
            c.MakeCommands[10] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                ushort* ptr = (ushort*)(c.State.Memory.AsByte + mem); 
                *ptr = r.ReadUInt16();
                c.State.EcpPtr += 6;
                return true;
            };
            c.MakeCommands[11] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                ushort* ptrDst = (ushort*)(c.State.Memory.AsByte + mem);
                ushort* ptrSrc = (ushort*)(c.State.Memory.AsByte + mem2);
                *ptrDst = *ptrSrc;
                c.State.EcpPtr += 8;
                return true;
            };
            c.MakeCommands[12] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
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
                ushort* ptr = (ushort*)(c.State.Registers.AsByte + reg);
                ushort* ptr2 = (ushort*)(c.State.Memory.AsByte + mem);
                
                *ptr2 = *ptr;
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[13] = (r) =>
            {
                byte* registers = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                registers += reg;
                *(uint*)registers = r.ReadUInt32();
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[14] = (r) =>
            {
                byte* registers = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                registers += reg;

                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }

                *(uint*)registers = *(uint*)(c.State.Memory.AsByte + mem2);
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[15] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                uint* dstPtr = (uint*)(ptr + reg);

                byte reg2 = r.ReadByte();
                if (reg2 > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                uint* srcPtr = (uint*)(ptr + reg2);
                *dstPtr = *srcPtr;
                c.State.EcpPtr += 2;
                return true;
            };
            c.MakeCommands[16] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint* ptr = (uint*)(c.State.Memory.AsByte + mem);
                *ptr = r.ReadUInt32();
                c.State.EcpPtr += 8;
                return true;
            };
            c.MakeCommands[17] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                uint* ptrDst = (uint*)(c.State.Memory.AsByte + mem);
                uint* ptrSrc = (uint*)(c.State.Memory.AsByte + mem2);
                *ptrDst = *ptrSrc;
                c.State.EcpPtr += 8;
                return true;
            };
            c.MakeCommands[18] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
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
                uint* ptr = (uint*)(c.State.Registers.AsByte + reg);
                uint* ptr2 = (uint*)(c.State.Memory.AsByte + mem);

                *ptr2 = *ptr;
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[19] = (r) =>
            {
                byte* registers = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                registers += reg;
                *(ulong*)registers = r.ReadUInt64();
                c.State.EcpPtr += 9;
                return true;
            };
            c.MakeCommands[20] = (r) =>
            {
                byte* registers = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                registers += reg;

                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }

                *(ulong*)registers = *(ulong*)(c.State.Memory.AsByte + mem2);
                c.State.EcpPtr += 5;
                return true;
            };
            c.MakeCommands[21] = (r) =>
            {
                byte* ptr = c.State.Registers.AsByte;
                byte reg = r.ReadByte();
                if (reg > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ulong* dstPtr = (ulong*)(ptr + reg);

                byte reg2 = r.ReadByte();
                if (reg2 > 185)
                {
                    c.LastMsg = "Can't determine that register " + reg;
                    return false;
                }
                ulong* srcPtr = (ulong*)(ptr + reg2);
                *dstPtr = *srcPtr;
                c.State.EcpPtr += 2;
                return true;
            };
            c.MakeCommands[22] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                ulong* ptr = (ulong*)(c.State.Memory.AsByte + mem);
                *ptr = r.ReadUInt64();
                c.State.EcpPtr += 12;
                return true;
            };
            c.MakeCommands[23] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem;
                    return false;
                }
                uint mem2 = r.ReadUInt32();
                if (mem2 >= c.State.Memory.Size)
                {
                    c.LastMsg = "Cannot access memory at address:" + mem2;
                    return false;
                }
                ulong* ptrDst = (ulong*)(c.State.Memory.AsByte + mem);
                ulong* ptrSrc = (ulong*)(c.State.Memory.AsByte + mem2);
                *ptrDst = *ptrSrc;
                c.State.EcpPtr += 8;
                return true;
            };
            c.MakeCommands[24] = (r) =>
            {
                uint mem = r.ReadUInt32();
                if (mem >= c.State.Memory.Size)
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
                ulong* ptr = (ulong*)(c.State.Registers.AsByte + reg);
                ulong* ptr2 = (ulong*)(c.State.Memory.AsByte + mem);

                *ptr2 = *ptr;
                c.State.EcpPtr += 5;
                return true;
            };
        }
    }
}
