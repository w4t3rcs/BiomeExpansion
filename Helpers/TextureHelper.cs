using System.IO;
using Terraria.ModLoader;

namespace BiomeExpansion.Helpers;

public static class TextureHelper
{
    public const string AssetsLocation = "BiomeExpansion/Assets";
    public const string ItemsAssetsLocation = $"{AssetsLocation}/Items";
    public const string TilesAssetsLocation = $"{AssetsLocation}/Tiles";
    public const string MinionsAssetsLocation = $"{AssetsLocation}/Minions";
    public const string ProjectilesAssetsLocation = $"{AssetsLocation}/Projectiles";
    public const string RainsAssetsLocation = $"{AssetsLocation}/Rains";
    public const string TreesAssetsLocation = $"{AssetsLocation}/Trees";
    public const string WallsAssetsLocation = $"{AssetsLocation}/Walls";
    public const string WatersAssetsLocation = $"{AssetsLocation}/Waters";
    public static readonly string ModSourcesDirectory = ModLoader.ModPath.Replace("Mods", "ModSources");
    
    public static string GetDynamicItemTexture(string fileName)
    {
        return GetDynamicTexture(ItemsAssetsLocation, fileName);
    }
    
    public static string GetDynamicTileTexture(string fileName)
    {
        return GetDynamicTexture(TilesAssetsLocation, fileName);
    }
    
    public static string GetDynamicMinionTexture(string fileName)
    {
        return GetDynamicTexture(MinionsAssetsLocation, fileName);
    }
    
    public static string GetDynamicProjectileTexture(string fileName)
    {
        return GetDynamicTexture(ProjectilesAssetsLocation, fileName);
    }
    
    public static string GetDynamicRainTexture(string fileName)
    {
        return GetDynamicTexture(RainsAssetsLocation, fileName);
    }
    
    public static string GetDynamicTreeTexture(string fileName)
    {
        return GetDynamicTexture(TreesAssetsLocation, fileName);
    }
    
    public static string GetDynamicWallTexture(string fileName)
    {
        return GetDynamicTexture(WallsAssetsLocation, fileName);
    }
    
    public static string GetDynamicWaterTexture(string fileName)
    {
        return GetDynamicTexture(WatersAssetsLocation, fileName);
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
            if (possiblyNeededFile is not null) 
                return possiblyNeededFile;
        }
        return null;
    }
}