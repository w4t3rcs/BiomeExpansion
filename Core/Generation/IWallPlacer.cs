namespace BiomeExpansion.Core.Generation;

public interface IWallPlacer
{
    public void PlaceWall(BEBiome biome, ushort wall, ushort tileBehindWall = 0);
}