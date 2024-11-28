using System.Linq;
using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class SimpleDecorationPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(int x, int y, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        if (!CheckPositionToPlace(rarity, x, y + 1, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile], GenerationTileData.ValidTiles[tile])) return;
        WorldGen.PlaceTile(x, y, tile);
        if (frameCount != 0) FrameHelper.SetRandomHorizontalFrame(x, y, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile], frameCount);
    }

    private static bool CheckPositionToPlace(ushort rarity, int x, int y, int width, int height, int[] allowedTiles)
    {
        bool firstCheck;
        if (allowedTiles is null || allowedTiles.Length == 0) firstCheck = !Main.tile[x, y].BottomSlope && WorldGen.genRand.NextBool(rarity);
        else firstCheck = !Main.tile[x, y].BottomSlope && allowedTiles.Contains(Main.tile[x, y].TileType) && WorldGen.genRand.NextBool(rarity);
        if (firstCheck)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (Main.tile[x + i, y - j].HasTile)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        return false;
    }
}