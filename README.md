# ColorfulFolders
ColorfulFolders is a very simple Unity utility to set custom colors for Project window folders.

## Installation

ColorfulFolder can be added to a project via Package Manager.

Download to disk and use "Add package from disk..." and navigate to downloaded project "package.json" file.

Or use "Add package from git URL..." and enter https://github.com/wwrzal/ColorfulFolders.git.
## Usage

Crate scriptable objects of type FolderColorCollection (RMB > Create > ColorfulFolders > FolderColorCollection).

Add an entry to its Data member.

Set Path property to full path of the folder to color (e.g. Assets/Scripts).

Set Color property to desired color. As this solution simply draws colored rectangle over the item the color should probably be transparent.

## Example

![Alt text](config.png?raw=true "FolderColorCollection")

![Alt text](result1.png?raw=true "Result")

![Alt text](result2.png?raw=true "Result")

## License 
[MIT](https://choosealicense.com/licenses/mit/)