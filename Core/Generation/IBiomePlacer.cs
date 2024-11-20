namespace BiomeExpansion.Core.Generation;

public interface IBiomePlacer
{
    public void Place(BEBiome biome, ushort[] tiles, ushort mainWall);

    public void PlaceOnlyWithMainTile(BEBiome biome, ushort mainTile, ushort mainWall);
}