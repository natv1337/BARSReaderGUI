using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARSReaderGUI
{
    public class AMTA //Audio Metadata
    {
        public string magic; //always AMTA
        public ushort endian;
        public ushort version;
        public uint size;
        public uint unk1;
        public uint unk2; //observed 0x34 or 0x38
        public uint unk3;
        public uint unk4;
        public uint unk5;
        public uint unk6;
        public string assetname;
    }
    public class AMTADATA
    {
        public uint size;
        public uint namehash; //same as asset name hash
        public uint unk1; //type?
        public byte unk2;
        public byte channelcount;
    }

    public class MINF //Music Info
    {
        public string magic; //always MINF
        public ushort endian;
        public ushort version;
        public uint size;
    }
}
