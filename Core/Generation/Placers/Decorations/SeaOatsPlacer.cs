using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class SeaOatsPlacer : ISurfaceDecorationPlacer
{
    public bool PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        if (!PlantHelper.CheckTopPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y + 1)) return false;
        int horizontalRange = WorldGen.genRand.Next(6, 16);
        for (int i = 0; i <= horizontalRange; i++)
        {
            if (!PlantHelper.CheckTopPositionToPlace(1, GenerationTileData.ValidTiles[tile], x + i, y + 1)) return true;
            WorldGen.PlaceTile(x + i, y, tile);
            FrameHelper.SetFramingSeaOats(x + i, y);
        }

        return true;
    }
}