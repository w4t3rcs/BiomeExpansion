using System.Linq;

namespace BiomeExpansion.Core.Generation.Placers.Tiles;

public class DirtTilePlacer : ITilePlacer
{
    public static readonly int[] DisallowedTileReplacements = [TileID.LivingWood, TileID.BlueDungeonBrick, TileID.CrackedBlueDungeonBrick, TileID.PinkDungeonBrick, TileID.CrackedPinkDungeonBrick];

    public void PlaceTile(int x, int y, ushort tileType, ushort[] additionalTileTypes = null)
    {
        var tile = Main.tile[x, y];
        if (!(DisallowedTileReplacements.Contains(tile.TileType)
                || StoneTilePlacer.StoneTileReplacements.Contains(tile.TileType) 
                || SandTilePlacer.SandTileReplacements.Contains(tile.TileType) 
                || SandstoneTilePlacer.SandstoneTileReplacements.Contains(tile.TileType)))
            WorldGen.ReplaceTile(x, y, tileType, tile.TileFrameX);
    }
}