using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARSReaderGUI
{
    public class ZstdUtils
    {
        public Stream Decompress(Stream stream)
        {
            return new MemoryStream(Decompressor(stream.ToArray()));
        }

        public static byte[] Decompressor(byte[] b)
        {
            using (var decompressor = new ZstdNet.Decompressor())
            {
                return decompressor.Unwrap(b);
            }
        }
    }
    public static class StreamExtensions
    {
        public static byte[] ToArray(this Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
