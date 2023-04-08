namespace BARSReaderGUI
{
    public partial class Form1 : Form
    {
        List<AudioAsset> audioAssets = new List<AudioAsset>();
        // stores all of the names of the BWAVs in a BARS file
        // used when sorting to get the index of the actual sound
        List<String> audioNames = new List<string>();

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
                audioNames.Clear();
                AssetListBox.Items.Clear();
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
                    // Check file magic.
                    string magic = reader.ReadSizedString(4);
                    if (magic != "BARS")
                    {
                        MessageBox.Show("Not a BARS file.");
                        return;
                    }

                    // Read file size.
                    uint size = reader.ReadUInt();

                    // Read endianness from file.
                    ushort endian = reader.ReadUShort();
                    if (endian != 0xFEFF)
                    {
                        MessageBox.Show("Unsupported endian!");
                        return;
                    }

                    // Read version from the file.
                    ushort version = reader.ReadUShort();
                    if (version != 0x0102 && version != 0x0101)
                    {
                        MessageBox.Show("This version of BARS is unsupported at this time."); //throw this error on trying to read anything other than v1.1/1.2
                        return;
                    }

                    uint assetcount = reader.ReadUInt();
                    //assets = new KeyValuePair<uint, AssetOffsetPair>[assetcount];

                    // Create audioAssets and tie crcHashes to them.
                    for (int i = 0; i < assetcount; i++)
                    {
                        audioAssets.Add(new AudioAsset());
                        audioAssets[i].crcHash = reader.ReadUInt();
                    }

                    // Pair ATMA/BWAV offsets with asset
                    for (int i = 0; i < assetcount; i++)
                    {
                        audioAssets[i].amtaOffset = reader.ReadUInt();
                        audioAssets[i].assetOffset = reader.ReadUInt();
                    }

                    // Read asset's amta data.
                    for (int i = 0; i < assetcount; i++)
                    {
                        audioAssets[i].amtaData = new AMTA();
                        audioAssets[i].amtaData.ReadAMTA(audioAssets[i].amtaOffset, reader);
                    }

                    for (int i = 0; i < assetcount; i++)
                    {
                        reader.Position = audioAssets[i].amtaOffset;
                        audioAssets[i].amtaAssetData = reader.ReadBytes(audioAssets[i].amtaData.size);
                    }

                    // Sort assets.
                    audioAssets = SortAudioAssets();

                    // Reads audio assets.
                    // TODO: Explain this particular section better.
                    for (int i = 0; i < audioAssets.Count; i++)
                    {
                        reader.Position = audioAssets[i].assetOffset;

                        audioAssets[i].assetType = reader.ReadSizedString(4);
                        reader.Position -= 4;


                        if (audioAssets[i].assetType != "BWAV")
                        {
                            //FSTPs are prefetch assets.
                            if (audioAssets[i].assetType == "FSTP")
                                audioAssets[i].isPrefetch = true;
                            reader.Position += 0xC;
                            int assetSize = reader.ReadInt();
                            reader.Position -= 0x10;

                            audioAssets[i].assetData = reader.ReadBytes(assetSize);
                        }
                        else
                        {
                            //check if BWAV is a prefetch or not.
                            reader.Position += 0xC;
                            if (reader.ReadUShort() == 1)
                                audioAssets[i].isPrefetch = true;
                            reader.Position -= 0xE;

                            // For BWAV assets, read data of the size of the next assset offset minus the current asset offset.
                            if (i != audioAssets.Count - 1)
                                audioAssets[i].assetData = reader.ReadBytes(Convert.ToInt32(audioAssets[i + 1].assetOffset - audioAssets[i].assetOffset));
                            else
                                audioAssets[i].assetData = reader.ReadBytes(Convert.ToInt32(size - audioAssets[i].assetOffset));
                        }
                    }

                    // Adds all of the audio asset names to the main list box.
                    for (int i = 0; i < audioAssets.Count; i++)
                    {
                        AssetListBox.Items.Add(audioAssets[i].amtaData.assetName);
                        audioNames.Add(audioAssets[i].amtaData.assetName);
                    }

                    this.Text = $"BARSReaderGUI - {fileDialog.SafeFileName} - {assetcount} Assets";
                    MessageBox.Show("Successfully read " + assetcount + " assets.");
                    AssetListBox.Sorted = true;
                    extractAllButton.Enabled = true;
                }
            }
        }

        private void AssetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                extractAudioButton.Enabled = true;
                extractMetaButton.Enabled = true;
                String sortedAssetName = AssetListBox.Items[AssetListBox.SelectedIndex].ToString();
                int index = audioNames.FindIndex(s => s.Contains(sortedAssetName));
                AudioAssetNameLabel.Text = audioAssets[index].amtaData.assetName;
                AudioAssetCrc32HashLabel.Text = audioAssets[index].crcHash.ToString("X");
                AudioAssetAmtaOffsetLabel.Text = audioAssets[index].amtaOffset.ToString("X");
                AudioAssetBwavOffsetLabel.Text = audioAssets[index].assetOffset.ToString("X");
                AudioAssetIsPrefetchLabel.Text = audioAssets[index].isPrefetch.ToString();

            }
            catch (Exception ex)
            {
                extractAudioButton.Enabled = false;
                extractMetaButton.Enabled = false;
                extractAllButton.Enabled = false;
            }
        }

        private void extractAudioButton_Click(object sender, EventArgs e)
        {
            int index = AssetListBox.SelectedIndex;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            switch (audioAssets[index].assetType)
            {
                case "BWAV":
                    saveFileDialog.Filter = "BWAV files (*.bwav)|*.bwav";
                    break;
                case "FWAV":
                    saveFileDialog.Filter = "BFWAV files (*.bfwav)|*.bfwav";
                    break;
                case "FSTP":
                    saveFileDialog.Filter = "BFSTP files (*.bfstp)|*.bfstp";
                    break;
                default:
                    break;
            }// Change this later to handle other audio formats

            saveFileDialog.Title = "Extract Audio";
            saveFileDialog.FileName = audioAssets[AssetListBox.SelectedIndex].amtaData.assetName;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var writer = new BinaryWriter(File.Create(saveFileDialog.FileName));
                writer.Write(audioAssets[index].assetData);
                MessageBox.Show(audioAssets[index].amtaData.assetName + " extracted successfully.");
            }
        }

        private void extractMetaButton_Click(object sender, EventArgs e)
        {
            int index = AssetListBox.SelectedIndex;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "BAMTA files (*.bamta)|*.bamta";
            saveFileDialog.Title = "Extract Meta";
            saveFileDialog.FileName = audioAssets[AssetListBox.SelectedIndex].amtaData.assetName;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var writer = new BinaryWriter(File.Create(saveFileDialog.FileName));
                writer.Write(audioAssets[index].amtaAssetData);
                MessageBox.Show(audioAssets[index].amtaData.assetName + " extracted successfully.");
            }
        }

        // Sorts audio asssets by their asset offsets.
        private List<AudioAsset> SortAudioAssets()
        {
            List<AudioAsset> sortedAssets = new List<AudioAsset>();
            // Iterate through all assets
            int oldAssetCount = audioAssets.Count;
            for (int i = 0; i < oldAssetCount; i++)
            {
                int lowestToSave = 0;

                for (int j = 0; j < audioAssets.Count; j++)
                {
                    // Check if we reached the end.
                    if (j == audioAssets.Count - 1)
                    {
                        // Make the saved index j if it is smaller than the current saved one.
                        if (audioAssets[lowestToSave].assetOffset > audioAssets[j].assetOffset)
                            lowestToSave = j;

                        break;
                    }

                    // Check if the currently saved index is greater than at j + 1. Change the saved index to this if true.
                    if (audioAssets[lowestToSave].assetOffset > audioAssets[j + 1].assetOffset)
                    {
                        lowestToSave = j + 1;
                    }
                }

                // Add the currently saved index to the sorted list and remove it from the main list so we don't run into it again on future iterations.
                sortedAssets.Add(audioAssets[lowestToSave]);
                audioAssets.RemoveAt(lowestToSave);
            }
            return sortedAssets;
        }

        private void extractAllButton_Click(object sender, EventArgs e)
        {
            // Select export folder
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Personal;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                int assetcount = 0;
                // Iterate through each entry and export.
                audioAssets.ForEach(asset =>
                {
                    String fileName = folderBrowserDialog.SelectedPath + "\\" + asset.amtaData.assetName + "." + asset.assetType;
                    using var writer = new BinaryWriter(File.Create(fileName));
                    writer.Write(asset.assetData);
                    assetcount++;
                });

                MessageBox.Show("Successfully extracted " + assetcount + " sounds.");
            }
        }
    }
    public class AssetOffsetPair
    {
        public uint amtaoffset;
        public uint bwavoffset;
    }
}