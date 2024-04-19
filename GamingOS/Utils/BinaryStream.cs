
using System;

namespace GamingOS.Utils
{
    public class BinaryStream
    {
        byte[] data;
        public uint Position;
        public uint Length;

        public BinaryStream(byte[] data)
        {
            Length = (uint)data.Length;
            Position = 0;
            this.data = data;
        }

        public byte ReadByte()
        {
            return data[Position++];
        }
        public byte[] ReadBytes(uint length)
        {
            byte[] ret = new byte[length];
            Cosmos.Core.MemoryOperations.Copy(ret, 0, data, (int)Position, ret.Length);
            Position += length;
            return ret;
        }
        public sbyte ReadSByte()
        {
            return (sbyte)data[Position++];
        }
        public char ReadChar()
        {
            return (char)ReadByte();
        }
        public ushort ReadUShort()
        {
            return (ushort)(data[Position++] | (data[Position++] << 8));
        }
        public short ReadShort()
        {
            return (short)(data[Position++] | (data[Position++] << 8));
        }
        public int ReadInt()
        {
            return data[Position++] | (data[Position++] << 8) | (data[Position++] << 16) | (data[Position++] << 24);
        }
        public uint ReadUInt()
        {
            return data[Position++] | (uint)(data[Position++] << 8) | (uint)(data[Position++] << 16) | (uint)(data[Position++] << 24);
        }
        public long ReadLong()
        {
            return data[Position++] | ((long)data[Position++] << 8) | ((long)data[Position++] << 16) | ((long)data[Position++] << 24) | ((long)data[Position++] << 32) | ((long)data[Position++] << 40) | ((long)data[Position++] << 48) | ((long)data[Position++] << 56);
        }
        public ulong ReadULong()
        {
            return data[Position++] | ((ulong)data[Position++] << 8) | ((ulong)data[Position++] << 16) | ((ulong)data[Position++] << 24) | ((ulong)data[Position++] << 32) | ((ulong)data[Position++] << 40) | ((ulong)data[Position++] << 48) | ((ulong)data[Position++] << 56);
        }
        public string ReadString()
        {
            int size = ReadInt();
            string ret = "";
            for(int i = 0; i < size; i++)
            {
                ret += ((char)data[Position++]).ToString();
            }
            return ret;
        }
        public float ReadFloat()
        {
            return BitConverter.ToSingle(ReadBytes(4));
        }
        public double ReadDouble()
        {
            return BitConverter.ToDouble(ReadBytes(8));
        }
        public bool ReadBool()
        {
            return ReadByte() != 0;
        }
        public void Write(byte value)
        {
            data[Position] = value;
            Position++;
        }
        public void Write(byte[] value)
        {
            for(int i = 0; i < value.Length; i++)
            {
                data[Position++] = value[i];
            }
        }
        public void Write(sbyte value)
        {
            data[Position] = (byte)value;
            Position++;
        }
        public void Write(char value)
        {
            Write((byte)value);
        }
        public void Write(short value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
        }
        public void Write(ushort value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
        }
        public void Write(int value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
            data[Position] = (byte)(value >> 16);
            Position++;
            data[Position] = (byte)(value >> 24);
            Position++;
        }
        public void Write(uint value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
            data[Position] = (byte)(value >> 16);
            Position++;
            data[Position] = (byte)(value >> 24);
            Position++;
        }
        public void Write(long value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
            data[Position] = (byte)(value >> 16);
            Position++;
            data[Position] = (byte)(value >> 24);
            Position++;
            data[Position] = (byte)(value >> 32);
            Position++;
            data[Position] = (byte)(value >> 40);
            Position++;
            data[Position] = (byte)(value >> 48);
            Position++;
            data[Position] = (byte)(value >> 56);
            Position++;
        }
        public void Write(ulong value)
        {
            data[Position] = (byte)value;
            Position++;
            data[Position] = (byte)(value >> 8);
            Position++;
            data[Position] = (byte)(value >> 16);
            Position++;
            data[Position] = (byte)(value >> 24);
            Position++;
            data[Position] = (byte)(value >> 32);
            Position++;
            data[Position] = (byte)(value >> 40);
            Position++;
            data[Position] = (byte)(value >> 48);
            Position++;
            data[Position] = (byte)(value >> 56);
            Position++;
        }
        public void Write(string s)
        {
            Write(s.Length);
            for(int i = 0; i < s.Length; i++)
            {
                Write((byte)s[i]);
            }
        }
        public void WriteFloat(float value)
        {
            Write(BitConverter.SingleToInt32Bits(value));
        }
        public void WriteDouble(double value)
        {
            Write(BitConverter.DoubleToInt64Bits(value));
        }
        public void WriteBool(bool value)
        {
            Write(value ? (byte)1 : (byte)0);
        }
    }
}
