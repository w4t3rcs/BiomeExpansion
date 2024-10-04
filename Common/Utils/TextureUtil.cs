using System;
using System.IO;
using Terraria.ModLoader;

namespace BiomeExpansion.Common.Utils;

public static class TextureUtil
{
    public const string AssetsLocation = "BiomeExpansion/Assets";
    public static readonly string ModSourcesDirectory = ModLoader.ModPath.Replace("Mods", "ModSources");
    
    public static string GetDynamicTileItemTexture(string fileName)
    {
        return GetDynamicTexture($"Placeable/{fileName}");
    }
    
    public static string GetDynamicTileTexture(string fileName)
    {
        return GetDynamicTexture($"Tiles/{fileName}");
    }
    
    public static string GetDynamicTexture(string fileName)
    {
        return GetDynamicTexture(AssetsLocation, fileName);
    }
    
    public static string GetDynamicTexture(string parentDirectory, string fileName)
    {
        string fullPath = $"{parentDirectory}/{fileName}";
        if (ModContent.HasAsset(fullPath)) return fullPath;
        foreach (string subdirectory in Directory.GetDirectories($"{ModSourcesDirectory}/{parentDirectory}"))
        {
            string dynamicSubDirectory = subdirectory.Replace($"{ModSourcesDirectory}/", "");
            string possiblyNeededFile = GetDynamicTexture(dynamicSubDirectory, fileName); 
            Console.WriteLine(possiblyNeededFile); 
            if (possiblyNeededFile is not null) 
                return possiblyNeededFile;
        }
        return null;
    }
}