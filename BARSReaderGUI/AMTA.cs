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
        public string magic;
        public ushort endian;
        public ushort version;
        public uint size;
        public byte channelCount;
        public string assetName;
        public AMTADATAV4 amtaDataV4 = new AMTADATAV4();
        public AMTAMARKV4 amtaMarkV4 = new AMTAMARKV4();
        public AMTAEXTV4 amtaExtV4 = new AMTAEXTV4();
        public AMTASTRGV4 amtaStrgV4 = new AMTASTRGV4();

        public void ReadAMTA(long startPosition, NativeReader reader)
        {
            reader.Position = startPosition;
            magic = reader.ReadSizedString(4);
            endian = reader.ReadUShort();
            version = reader.ReadUShort();
            size = reader.ReadUInt();

            switch ((AMTAVersion)version)
            {
                case AMTAVersion.V4:
                    {
                        ReadAMTAV4(reader.Position, reader);
                    }
                    break;
                case AMTAVersion.V5:
                    {
                        ReadAMTAV5(reader.Position, reader);
                    }
                    break;
                default:
                    MessageBox.Show("Unsupported AMTA version.");
                    return;
            }
        }

        #region V4
        #region Classes
        public class AMTADATAV4
        {
            public string identifer;
            public uint sectionsize;
            public uint nameoffset;
            public uint unk1;
            public byte type;
            public byte channelcount;
            public byte usedstreamcount;
            public byte flags; //xxAx xBCC || A = 0 = BFWAV/BFSTP, 1 = BWAV || B = looping || C = Unknown, 2 for stream, 3 for prefetch stream
            public float volume;
            public uint samplerate;

            public AMTALoopInfo loopInfo = new AMTALoopInfo();
            public class AMTALoopInfo
            {
                public uint loopstartsample;
                public uint loopendsample;
            }
            public float loudness;

            public List<AMTAStreamTrack> streamTracks = new List<AMTAStreamTrack>();
            public class AMTAStreamTrack //theres 8 of these i think?
            {
                public uint channelcount;
                public float volume;
            }
            public float peakamplitude;
        }
        public class AMTAMARKV4
        {
            public string identifier;
            public uint sectionsize;
            public uint entrycount;
            public class AMTAMarker
            {
                uint id;
                uint nameoffset;
                uint startpos;
                uint length; //one doc page says this is unknown
            }
        }
        public class AMTAEXTV4
        {
            public string identifier;
            public uint sectionsize;
            public uint entrycount;
            public class AMTAEXTEntry
            {
                uint unk1; //one doc page says this is a string offset
                uint unk2;
            }
        }
        public class AMTASTRGV4
        {
            public string identifier;
            public uint sectionsize;
            //null terminated strings, all entries are linked to via offsets that are relative to the end of the section header(strgoffset +8)
        } 
        #endregion
        public void ReadAMTAV4(long startPosition, NativeReader reader)
        {
            uint dataoffset = reader.ReadUInt();
            uint markoffset = reader.ReadUInt();
            uint extoffset = reader.ReadUInt();
            uint strgoffset = reader.ReadUInt();
            ReadAMTADATAV4(dataoffset, reader);
            ReadAMTAMARKV4(markoffset, reader);
            ReadAMTAEXTV4(extoffset, reader);
            ReadAMTASTRGV4(strgoffset, reader);
        }
        public void ReadAMTADATAV4(long startPosition, NativeReader reader)
        {
            startPosition = reader.Position;
            reader.ReadSizedString(4);
            amtaDataV4.sectionsize = reader.ReadUInt();
            amtaDataV4.nameoffset = reader.ReadUInt();
            amtaDataV4.unk1 = reader.ReadUInt();
            amtaDataV4.type = reader.ReadByte();
            amtaDataV4.channelcount = reader.ReadByte();
            amtaDataV4.usedstreamcount = reader.ReadByte();
            amtaDataV4.flags = reader.ReadByte();
            amtaDataV4.volume = reader.ReadFloat();
            amtaDataV4.samplerate = reader.ReadUInt();
            amtaDataV4.loopInfo.loopstartsample = reader.ReadUInt();
            amtaDataV4.loopInfo.loopendsample = reader.ReadUInt();
            amtaDataV4.loudness = reader.ReadFloat();
            for (int i = 0; i < amtaDataV4.usedstreamcount; i++)
            {
                amtaDataV4.streamTracks.Add(new AMTADATAV4.AMTAStreamTrack());
                amtaDataV4.streamTracks[i].channelcount = reader.ReadUInt();
                amtaDataV4.streamTracks[i].volume = reader.ReadFloat();
            }

            amtaDataV4.peakamplitude = reader.ReadFloat();
        }

        public void ReadAMTAMARKV4(long startPosition, NativeReader reader)
        {
            startPosition = reader.Position;
            reader.ReadSizedString(4);
        }

        public void ReadAMTAEXTV4(long startPosition, NativeReader reader)
        {
            startPosition = reader.Position;
            reader.ReadSizedString(4);
        }

        public void ReadAMTASTRGV4(long startPosition, NativeReader reader)
        {
            startPosition = reader.Position;
            reader.ReadSizedString(4);
        } 
        #endregion

        #region V5
        public void ReadAMTAV5(long startPosition, NativeReader reader)
        {
            uint unk1 = reader.ReadUInt();
            uint unk2 = reader.ReadUInt(); //observed 0x34 or 0x38
            uint unk3 = reader.ReadUInt();
            uint unk4 = reader.ReadUInt();
            uint unk5 = reader.ReadUInt();
            uint unk6 = reader.ReadUInt();
            ReadAMTADATAV5(reader.Position, reader);
            assetName = reader.ReadNullTerminatedString();
        }
        public void ReadAMTADATAV5(long startPosition, NativeReader reader)
        {
            uint datasize = reader.ReadUInt();
            uint namehash = reader.ReadUInt(); //same as asset name hash
            uint unk1 = reader.ReadUInt();
            byte unk2 = reader.ReadByte();
            channelCount = reader.ReadByte();
            reader.Position = startPosition + datasize; //return to start pos and use the size to skip over the rest of the section
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
