using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ColorfulFolders/FolderColorCollection", fileName = "FolderColorCollectoin")]
class FolderColorCollection : ScriptableObject
{
    public List<FolderColor> Data;

    private void OnValidate()
    {
        // Reload settings so that changes are visible in the editor immediately.
        ColorfulFolders.LoadSettings();
    }
}