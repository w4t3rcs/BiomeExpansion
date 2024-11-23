using System.Linq;
using Terraria.ObjectData;

namespace BiomeExpansion.Core.Generation.Placers.Decorations;

public class SimpleDecorationPlacer : ISurfaceDecorationPlacer
{
    public void PlaceSurfaceDecoration(BEBiome biome, ushort rarity, ushort tile, sbyte frameCount = 0)
    {
        var (leftX, rightX) = GenerationHelper.BEBiomesXCoordinates[biome];
        var (startY, endY) = GenerationHelper.BEBiomesYCoordinates[biome];
        for (int x = leftX; x < rightX; x++)
        {
            for (int y = startY; y < endY; y++)
            {
                if (CheckPositionToPlace(rarity, x, y, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile], GenerationTileData.ValidTiles[tile]))
                    PlaceDecoration(tile, x, y - 1, frameCount, GenerationTileData.Widths[tile], GenerationTileData.Heights[tile]);
            }
        }
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

    private static void PlaceDecoration(ushort decorationTile, int x, int y, int frameCount, int width, int height)
    {
        WorldGen.PlaceTile(x, y, decorationTile);
        if (frameCount != 0) FrameHelper.SetRandomHorizontalFrame(x, y, width, height, frameCount);
    }
}