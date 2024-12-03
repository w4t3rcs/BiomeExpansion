using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class VinePlacer : ISurfaceDecorationPlacer
{
    public bool PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        int range = WorldGen.genRand.Next(2, 12);
        if (!PlantHelper.CheckBottomPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y, range)) return false;
        for (int i = y; i < y + range; i++)
        {
            WorldGen.PlaceTile(x, i, tile);
        }
        for (int i = y; i < y + range; i++)
        {
            FrameHelper.SetFramingVine(x, i);
        }

        return true;
    }
}