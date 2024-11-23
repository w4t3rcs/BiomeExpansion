namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public interface ISurfaceDecorationPlacer
{
    void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0);
}