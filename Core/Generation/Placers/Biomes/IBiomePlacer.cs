namespace BiomeExpansion.Core.Generation.Placers.Biomes;

public interface IBiomePlacer
{
    public void Place(BEBiome biome, ushort[] tiles);

    public void PlaceOnlyWithMainTile(BEBiome biome, ushort mainTile);
}