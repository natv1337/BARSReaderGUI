# BARSReaderGUI

Basic program for reading and exporting data from Nintendo's BARS file format.

## Usage
Select "File" at the top, then "Open..." then select the BARS you wish to read.
![image](https://user-images.githubusercontent.com/33284629/222014613-de53a59f-5115-428c-8f9c-73b2ae16694d.png)

You can extract the sound or meta with the two buttons on the bottom right after selecting an asset from the list on the left.

## Compatibility
This has been tested with:
- Splatoon 3
- Animal Crossing New Horizons
- Splatoon 2
- Mario Kart 8 Deluxe

The above games definitely work, but any little endian BARS file of version 1.1 or 1.2 should work just fine as well.

## Credits

NativeReader class from [FrostyToolSuite](https://github.com/CadeEvs/FrostyToolsuite) 

Zstd compressed files support provided by [ZstdNet](https://github.com/skbkontur/ZstdNet)

Lastly, the awesome [Nintendo-File-Formats
 wiki](https://github.com/kinnay/Nintendo-File-Formats/wiki) for it's documentation on the BARS and AMTA formats
