using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARSReaderGUI
{
    public enum AMTAVersion : ushort
    {
        V1 = 0x0100,
        V3 = 0x0300,
        V4 = 0x0400,
        V5 = 0x0500
    }
    public class AMTA //Audio Metadata
    {
        public void ReadAMTA(uint startPosition, NativeReader reader)
        {
            reader.Position = startPosition;
            string magic = reader.ReadSizedString(4); //always AMTA
            ushort endian = reader.ReadUShort(); //0xFFFE for little, 0xFEFF for big
            ushort version = reader.ReadUShort();
            uint size = reader.ReadUInt();

            switch ((AMTAVersion)version)
            {
                case AMTAVersion.V5:
                    {
                        ReadAMTAV5(startPosition, reader);
                    }
                    break;
                default:
                    MessageBox.Show("Unsupported AMTA version.");
                    return;
            }
        }

        #region V5
        public void ReadAMTAV5(uint startPosition, NativeReader reader)
        {
            uint unk1 = reader.ReadUInt();
            uint unk2 = reader.ReadUInt(); //observed 0x34 or 0x38
            uint unk3 = reader.ReadUInt();
            uint unk4 = reader.ReadUInt();
            uint unk5 = reader.ReadUInt();
            uint unk6 = reader.ReadUInt();
            ReadAMTADATAV5(startPosition, reader);
            string assetname = reader.ReadNullTerminatedString();
        }
        public void ReadAMTADATAV5(uint startPosition, NativeReader reader)
        {
            reader.Position = startPosition;
            uint datasize = reader.ReadUInt();
            uint namehash = reader.ReadUInt(); //same as asset name hash
            uint unk1 = reader.ReadUInt();
            byte unk2 = reader.ReadByte();
            byte channelcount = reader.ReadByte();
            reader.Position = startPosition + datasize;
        }

        //public class MINF //Music Info
        //{
        //    public string magic; //always MINF
        //    public ushort endian;
        //    public ushort version;
        //    public uint size;
        //}
    }
    #endregion
}
