using System.Collections.Generic;
using UnityEngine;

namespace wwrzal.ColorfulFolders
{
    [CreateAssetMenu(menuName = "ColorfulFolders/FolderColorCollection", fileName = "FolderColorCollection")]
    class FolderColorCollection : ScriptableObject
    {
        public List<FolderColor> Data;

        private void OnValidate()
        {
            // Reload settings so that changes are visible in the editor immediately.
            ColorfulFolders.LoadSettings();
        }
    }
}