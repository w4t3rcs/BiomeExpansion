namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public interface ITilePlacer
{
    void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null);
}