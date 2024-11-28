using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class BunchPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        if (!PlantHelper.CheckTopPositionToPlace(rarity, GenerationTileData.ValidTiles[tile], x, y + 1)) return;
        int horizontalRange = WorldGen.genRand.Next(4, 12);
        int verticalRange = WorldGen.genRand.Next(2, 6);
        for (int i = 0; i < verticalRange; i++)
        {
            for (int j = 0; j < horizontalRange; j++)
            {
                if (!Main.tile[x + j / 2, y + i / 2].HasTile)
                {
                    WorldGen.PlaceTile(x + j / 2, y + i / 2, tile);
                    FrameHelper.SetRandomHorizontalFrame(x + j / 2, y + i / 2, 1, frameCount);
                }
                else if (!Main.tile[x - j / 2, y - i / 2].HasTile)
                {
                    WorldGen.PlaceTile(x - j / 2, y - i / 2, tile);
                    FrameHelper.SetRandomHorizontalFrame(x - j / 2, y - i / 2, 1, frameCount);
                }
            }
        }
    }
}