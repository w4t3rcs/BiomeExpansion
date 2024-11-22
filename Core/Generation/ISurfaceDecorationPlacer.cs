namespace BiomeExpansion.Core.Generation;

public interface ISurfaceDecorationPlacer
{
    void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0);
}