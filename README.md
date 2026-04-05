# BOG.FolderManifest

Class: Small Utility
Author: John J Schultz   ( http://www.bitsofgenius.com )

Builds a simple manifest of the files in a folder, optionally including
the sub-folders, assembly version, file time and size, etc.  Various output
formats are available.

The app is launched either:
- Directly and the operator enters a folder path in the upper text box.
- By right-clicking on a folder in Explorer, and selecting Folder Manifest from the context menu.

To install the context menu option into Windows Explorer:

- Copy the application files to a folder on your drive
- Edit the file FolderManifest_Apply_ShellExt.reg to update the folder in the key for [HKEY_CLASSES_ROOT\Directory\shell\BOG.FolderManifest\command]
- Save the file, and open Registry Editor to import that file into.

- Open windows explorer and right click a folder to see if Folder Manifest appears in the context menu.
- Click Folder Manifest, which will use that folder as the manifest content.

The result in the text box support Ctrl+A (select all), Ctrl+C (copy), and Ctrl+V (paste) for easy copying of the manifest content.

History:

1.1.1.0 -- 04/04/2025
- Pre-installer project addition (i.e. last manual install)

1.1.0.0 -- 06/01/2025
- Migrated from .NET Framework to .NET 8 for long term maintenance.

1.0.6.0 -- 01/05/2013
- Add new checkbox for "Show Subfolder Names" to show an empty folder in the list.

1.0.5.0 -- 04/03/2012
- Adds sorting (ascending) to all folder names and file names.

1.0.4.0 -- 01/09/2012
- Adds radio button for file name only, in addition to path as header and filepath.
- Adds checkbox to include time and size
- Adds checkbox to toggle between space and tab separators.  The latter allows copying
  the data to Excel and sorting.

