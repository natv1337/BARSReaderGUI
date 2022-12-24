namespace BARSReaderGUI
{
    public partial class Form1 : Form
    {
        List<AudioAsset> audioAssets = new List<AudioAsset>();
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                audioAssets.Clear();
                string inputFile = fileDialog.FileName;

                // Check for compression first.
                using (NativeReader reader = new(new FileStream(inputFile, FileMode.Open)))
                {
                    if (reader.ReadUInt() == 0xFD2FB528)
                    {
                        ZstdUtils zstdUtils = new ZstdUtils();
                        reader.Position -= 4;
                        fileStream = zstdUtils.Decompress(reader.BaseStream); // Stores decompressed data into stream
                    }
                    else
                    {
                        reader.Position -= 4;
                        fileStream = new MemoryStream(reader.BaseStream.ToArray()); // If no compression is found, we store the original file data in the stream.
                    }
                }

                // Read the file stored in the stream.
                using (NativeReader reader = new NativeReader(fileStream))
                {
                    KeyValuePair<uint, AssetOffsetPair>[] assets;

                    string magic = reader.ReadSizedString(4);
                    if (magic != "BARS")
                    {
                        MessageBox.Show("Not a BARS file.");
                        return;
                    }

                    uint size = reader.ReadUInt();

                    ushort endian = reader.ReadUShort();
                    if (endian != 0xFEFF)
                    {
                        MessageBox.Show("Unsupported endian!");
                        return;
                    }

                    ushort version = reader.ReadUShort();
                    if (version != 0x0102)
                    {
                        MessageBox.Show("BARS V1.1 Is unsupported at this time."); //we don't support anything but v102 atm
                        return;
                    }

                    uint assetcount = reader.ReadUInt();
                    //assets = new KeyValuePair<uint, AssetOffsetPair>[assetcount];

                    for (int i = 0; i < assetcount; i++)
                        audioAssets.Add(new AudioAsset());

                    // Pair CRC32 hash with asset
                    for (int i = 0; i < assetcount; i++)
                        audioAssets[i].crcHash = reader.ReadUInt();
                        //assets[i] = new KeyValuePair<uint, AssetOffsetPair>(reader.ReadUInt(), new AssetOffsetPair());

                    // Pair ATMA/BWAV offsets with asset
                    for (int i = 0; i < assetcount; i++)
                    {
                        audioAssets[i].amtaOffset = reader.ReadUInt();
                        audioAssets[i].bwavOffset = reader.ReadUInt();
                        //assets[i].Value.amtaoffset = reader.ReadUInt();
                        //assets[i].Value.bwavoffset = reader.ReadUInt();
                    }

                    bwavListBox.Items.Clear();
                    for (int i = 0; i < assetcount; i++)
                    {
                        reader.Position = audioAssets[i].amtaOffset + 0x24;
                        //reader.Position = assets[i].Value.amtaoffset + 0x24;
                        uint unkOffset = reader.ReadUInt();
                        reader.Position = audioAssets[i].amtaOffset + unkOffset + 36;
                        //reader.Position = assets[i].Value.amtaoffset + unkOffset + 36;

                        bwavListBox.Items.Add(reader.ReadNullTerminatedString());
                    }

                    this.Text = $"BARSReaderGUI - {fileDialog.SafeFileName} - {assetcount} Assets";
                    MessageBox.Show("Successfully read " + assetcount + " assets.");
                }
            }
        }

        public void ReadAMTA(uint startPosition, NativeReader reader)
        {

            //reader.Position = startPosition;
            //string magic = reader.ReadSizedString(4);
            //ushort endian = reader.ReadUShort();
            //ushort version = reader.ReadUShort();
            //uint size = reader.ReadUInt();
            //uint unk1 = reader.ReadUInt();
            //uint unk2 = reader.ReadUInt();
            //uint unk3 = reader.ReadUInt();
            //uint unk4 = reader.ReadUInt();
            //uint unk5 = reader.ReadUInt();
            //uint unk6 = reader.ReadUInt();

            //string fileName;

            //if (magic != "AMTA")
            //    return "";

            //if (endian != 0xFEFF)
            //    return "";

            //reader.Position += 0x1C;

            //uint nameOffset1 = reader.ReadUInt();
            //reader.Position = startPosition + nameOffset1 + 36;
            //fileName = reader.ReadNullTerminatedString();

            //reader.Position = startPosition;

            //return fileName;
        }
    }
    public class AssetOffsetPair
    {
        public uint amtaoffset;
        public uint bwavoffset;
    }
}