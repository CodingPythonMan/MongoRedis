using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.EngineExample
{
    public static class PacketExtension
    {
        public static ArraySegment<byte> Write(this IPacket packet)
        {
            ArraySegment<byte> segment = SendBufferHelper.Open(4096);

            ushort count = 0;

            using MemoryStream memoryStream = new MemoryStream(segment.Array);
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.Unicode);

            binaryWriter.BaseStream.Position = segment.Offset;

            binaryWriter.Write(packet.Protocol);
            binaryWriter.Write((ushort)0);

            foreach (var property in packet.GetType().GetProperties())
            {
                if (property.Name == "Protocol")
                {
                    continue;
                }

                if (property.PropertyType == typeof(string))
                {
                    string value = (string)property.GetValue(packet);

                    binaryWriter.Write((ushort)(value.Length * sizeof(char)));
                    binaryWriter.Write(value.ToCharArray());
                }
                else
                {
                    unsafe
                    {
                        fixed (byte* p = &segment.Array[binaryWriter.BaseStream.Position])
                        {
                            object value = property.GetValue(packet);
                            int size = Marshal.SizeOf(value);

                            Marshal.StructureToPtr(value, new IntPtr(p), false);

                            binaryWriter.BaseStream.Position += size;
                        }
                    }
                }
            }

            count = (ushort)(binaryWriter.BaseStream.Position - segment.Offset);

            binaryWriter.BaseStream.Position = segment.Offset + 2;
            binaryWriter.Write(count);

            return SendBufferHelper.Close(count);
        }
    }

    public interface IPacket
    {
        ushort Protocol { get; }
    }

}
