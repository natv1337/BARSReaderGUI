namespace BARSReaderGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputFile = fileDialog.FileName;

                using (NativeReader reader = new(new FileStream(inputFile, FileMode.Open)))
                {
                    string magic;
                    uint size;
                    ushort endian;
                    ushort version;
                    uint assetcount;
                    KeyValuePair<uint, AssetOffsetPair>[] assets;

                    magic = reader.ReadSizedString(4);
                    if (magic != "BARS")
                    {
                        MessageBox.Show("Not a BARS file. Did you decompress it first?"); //this is for when future me is an idiot
                        return;
                    }

                    size = reader.ReadUInt();

                    endian = reader.ReadUShort();
                    if (endian != 0xFEFF)
                    {
                        MessageBox.Show("Unsupported endian!"); //the version we support will likely never be big endian, so really this is unneeded but why not
                        return;
                    }

                    version = reader.ReadUShort();
                    if (version != 0x0102)
                    {
                        MessageBox.Show("Unsupported version!"); //we don't support anything but v102, the latest version of the format
                        return;
                    }

                    assetcount = reader.ReadUInt();
                    assets = new KeyValuePair<uint, AssetOffsetPair>[assetcount];

                    // Pair CRC32 hash with asset
                    for (int i = 0; i < assetcount; i++)
                        assets[i] = new KeyValuePair<uint, AssetOffsetPair>(reader.ReadUInt(), new AssetOffsetPair());

                    // Pair ATMA/BWAV offsets with asset
                    for (int i = 0; i < assetcount; i++)
                    {
                        assets[i].Value.amtaoffset = reader.ReadUInt();
                        assets[i].Value.bwavoffset = reader.ReadUInt();
                    }

                    bwavListBox.Items.Clear();
                    for (int i = 0; i < assetcount; i++)
                    {
                        bwavListBox.Items.Add(ReadAMTAName(assets[i].Value.amtaoffset, reader));
                    }

                    MessageBox.Show("Successfully read " + assetcount + " assets.");
                }
            }
        }

        public string ReadAMTAName(uint startPosition, NativeReader reader)
        {
            reader.Position = startPosition;
            string magic = reader.ReadSizedString(4);
            ushort endian = reader.ReadUShort();
            ushort version = reader.ReadUShort();
            string fileName;

            if (magic != "AMTA")
                return "";

            if (endian != 0xFEFF)
                return "";

            reader.Position += 0x1C;

            uint nameOffset1 = reader.ReadUInt();
            reader.Position = startPosition + nameOffset1 + 36;
            fileName = reader.ReadNullTerminatedString();

            reader.Position = startPosition;

            return fileName;
        }
    }
}