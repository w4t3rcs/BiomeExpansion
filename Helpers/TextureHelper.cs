using System.Collections.Generic;
using System.IO;
using ReLogic.Content;

namespace BiomeExpansion.Helpers;

public static class TextureHelper
{
    public static readonly Dictionary<string, string> DynamicItemsTextures = [];
    public static readonly Dictionary<string, string> DynamicTilesTextures = [];
    public static readonly Dictionary<string, string> DynamicBuffsTextures = [];
    public static readonly Dictionary<string, string> DynamicMinionsTextures = [];
    public static readonly Dictionary<string, string> DynamicProjectilesTextures = [];
    public static readonly Dictionary<string, string> DynamicRainsTextures = [];
    public static readonly Dictionary<string, string> DynamicTreesTextures = [];
    public static readonly Dictionary<string, string> DynamicWallsTextures = [];
    public static readonly Dictionary<string, string> DynamicWatersTextures = [];
    public static readonly Dictionary<string, string> DynamicSkiesTextures = [];
    public static readonly Dictionary<string, string> DynamicNPCsTextures = [];
    public static readonly Dictionary<string, string> DynamicBackgroundsTextures = [];
    public static readonly Dictionary<string, string> DynamicBestiaryTextures = [];
    public const string AssetsLocation = "BiomeExpansion/Assets";
    public const string ItemsAssetsLocation = $"{AssetsLocation}/Items";
    public const string TilesAssetsLocation = $"{AssetsLocation}/Tiles";
    public const string BuffsAssetsLocation = $"{AssetsLocation}/Buffs";
    public const string MinionsAssetsLocation = $"{AssetsLocation}/Minions";
    public const string ProjectilesAssetsLocation = $"{AssetsLocation}/Projectiles";
    public const string RainsAssetsLocation = $"{AssetsLocation}/Rains";
    public const string TreesAssetsLocation = $"{AssetsLocation}/Trees";
    public const string WallsAssetsLocation = $"{AssetsLocation}/Walls";
    public const string WatersAssetsLocation = $"{AssetsLocation}/Waters";
    public const string SkiesAssetsLocation = $"{AssetsLocation}/Skies";
    public const string NPCsAssetsLocation = $"{AssetsLocation}/NPCs";
    public const string GoresAssetsLocation = $"{AssetsLocation}/Gores";
    public const string BackgroundsAssetsLocation = $"{AssetsLocation}/Backgrounds";
    public const string BestiaryAssetsLocation = $"{AssetsLocation}/Bestiary";
    public static readonly string ModSourcesDirectory = ModLoader.ModPath.Replace("Mods", "ModSources");
    
    public static void LoadDynamicTextures()
    {
        LoadDynamicTextures(ItemsAssetsLocation, DynamicItemsTextures);
        LoadDynamicTextures(TilesAssetsLocation, DynamicTilesTextures);
        LoadDynamicTextures(BuffsAssetsLocation, DynamicBuffsTextures);
        // LoadDynamicTextures(MinionsAssetsLocation, DynamicMinionsTextures);
        // LoadDynamicTextures(ProjectilesAssetsLocation, DynamicProjectilesTextures);
        LoadDynamicTextures(RainsAssetsLocation, DynamicRainsTextures);
        LoadDynamicTextures(TreesAssetsLocation, DynamicTreesTextures);
        LoadDynamicTextures(WallsAssetsLocation, DynamicWallsTextures);
        LoadDynamicTextures(WatersAssetsLocation, DynamicWatersTextures);
        // LoadDynamicTextures(SkiesAssetsLocation, DynamicSkiesTextures);
        LoadDynamicTextures(NPCsAssetsLocation, DynamicNPCsTextures);
        LoadDynamicTextures(BackgroundsAssetsLocation, DynamicBackgroundsTextures);
        LoadDynamicTextures(BestiaryAssetsLocation, DynamicBestiaryTextures);
    }

    public static void LoadDynamicTextures(string location, Dictionary<string, string> cache)
    {
        foreach (string fileLocation in Directory.GetFiles($"{ModSourcesDirectory}/{location}", "*", SearchOption.AllDirectories))
        {
            string fileName = Path.GetFileNameWithoutExtension(fileLocation);
            cache.Remove(fileName);
            string tmodFilePath = fileLocation.Replace($"{ModSourcesDirectory}/", "").Split(".png")[0];
            cache.Add(fileName, tmodFilePath);
            System.Console.WriteLine(cache[fileName]);
        }
    }

    public static string GetDynamicItemTexture(string fileName)
    {
        return GetNonNullDynamicTexture(ItemsAssetsLocation, fileName);
    }
    
    public static string GetDynamicTileTexture(string fileName)
    {
        return GetNonNullDynamicTexture(TilesAssetsLocation, fileName);
    }
    
    public static string GetDynamicBuffTexture(string fileName)
    {
        return GetNonNullDynamicTexture(BuffsAssetsLocation, fileName);
    }
    
    public static string GetDynamicMinionTexture(string fileName)
    {
        return GetNonNullDynamicTexture(MinionsAssetsLocation, fileName);
    }
    
    public static string GetDynamicProjectileTexture(string fileName)
    {
        return GetNonNullDynamicTexture(ProjectilesAssetsLocation, fileName);
    }
    
    public static string GetDynamicRainTexture(string fileName)
    {
        return GetNonNullDynamicTexture(RainsAssetsLocation, fileName);
    }
    
    public static string GetDynamicTreeTexture(string fileName)
    {
        return GetNonNullDynamicTexture(TreesAssetsLocation, fileName);
    }
    
    public static string GetDynamicWallTexture(string fileName)
    {
        return GetNonNullDynamicTexture(WallsAssetsLocation, fileName);
    }
    
    public static string GetDynamicWaterTexture(string fileName)
    {
        return GetNonNullDynamicTexture(WatersAssetsLocation, fileName);
    }
    
    public static string GetDynamicSkyTexture(string fileName)
    {
        return GetNonNullDynamicTexture(SkiesAssetsLocation, fileName);
    }
    
    public static string GetNonNullDynamicTexture(string parentDirectory, string fileName)
    {
        string dynamicTextureLocation = GetDynamicTexture(parentDirectory, fileName);
        if (dynamicTextureLocation is null) throw AssetLoadException.FromMissingAsset(fileName, new FileNotFoundException($"Could not find {parentDirectory}/{fileName}"));
        return dynamicTextureLocation;
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