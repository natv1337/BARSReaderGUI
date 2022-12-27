using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARSReaderGUI
{
    public class AudioAsset
    {
        public uint crcHash;
        public uint amtaOffset;
        public uint assetOffset;
        public string assetName;
        public string assetType;
        public byte[] assetData;
        public AMTA amtaData = new AMTA();
    }
}
