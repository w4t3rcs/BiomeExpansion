namespace BiomeExpansion.Core.Generation;

public interface IBiomePlacer
{
    public void Place(BEBiome biome, ushort[] tiles, ushort wall);

    public void PlaceOnlyWithMainTile(BEBiome biome, ushort tile, ushort wall);
}