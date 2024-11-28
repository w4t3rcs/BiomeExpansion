namespace BiomeExpansion.Core.Generation.Placers.Ores;

public interface IOrePlacer
{
    public void PlaceOre(int x, int y, ushort tileType, ushort rarity, float strength, int steps);
}