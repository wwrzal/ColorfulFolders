using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace wwrzal.ColorfulFolders
{
    [InitializeOnLoad]
    public class ColorfulFolders
    {
        private static Dictionary<Color, Texture> _ColorToTexture;
        private static Dictionary<string, Color> _FolderToColor;

        static ColorfulFolders()
        {
            LoadSettings();
            EditorApplication.projectWindowItemOnGUI += DrawProjectWindowItem;
        }

        /// <summary> Discard old settings and load new ones from existing FolderColorCollections scriptable objects. </summary>
        public static void LoadSettings()
        {
            _ColorToTexture = new Dictionary<Color, Texture>();
            _FolderToColor = new Dictionary<string, Color>();

            var guids = AssetDatabase.FindAssets($"t:{typeof(FolderColorCollection).Name}");
            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var folderColorCollection = AssetDatabase.LoadAssetAtPath<FolderColorCollection>(path);
                // Can be null during package initialization.
                if (folderColorCollection != null)
                {
                    LoadFolderColorCollection(folderColorCollection);
                }
            }
        }

        private static void LoadFolderColorCollection(FolderColorCollection folderColorCollection)
        {
            foreach (var folderColor in folderColorCollection.Data)
            {
                _FolderToColor[folderColor.Path] = folderColor.Color;
            }
        }

        private static Texture MakeTextureForColor(Color color)
        {
            var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            texture.name = color.ToString();
            texture.SetPixel(0, 0, color);
            texture.Apply();
            return texture;
        }

        private static Texture GetTextureForColor(Color color)
        {
            if (_ColorToTexture.TryGetValue(color, out var texture) && texture != null)
            {
                return texture;
            }

            var newTexture = MakeTextureForColor(color);
            _ColorToTexture[color] = newTexture;
            return newTexture;
        }

        private static Texture GetTextureForFolder(string path)
        {
            if (_FolderToColor.TryGetValue(path, out var color))
            {
                return GetTextureForColor(color);
            }
            return null;
        }

        private static void DrawProjectWindowItem(string guid, Rect rect)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var texture = GetTextureForFolder(path);
            if (texture != null)
            {
                GUI.DrawTexture(rect, texture);
            }
        }
    }
}