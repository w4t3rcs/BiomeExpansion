namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public interface ISurfaceDecorationPlacer
{
    void PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0);
}