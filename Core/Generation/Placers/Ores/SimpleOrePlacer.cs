namespace BiomeExpansion.Core.Generation.Placers.Ores;

public class SimpleOrePlacer : IOrePlacer
{
    public void PlaceOre(int x, int y, ushort tileType, ushort rarity, float strength, int steps)
    {
        if (WorldGen.genRand.NextBool(rarity) && Main.tile[x, y].HasTile)
            WorldGen.OreRunner(x, y, strength, steps, tileType);
    }
}