using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ObjectData;

namespace BiomeExpansion.Helpers;

public static class TileHelper
{
    public static void SetFramePlant(ushort type, int styleRange, int coordinateHeight, bool isStyleHorizontal = true, int height = 1, int width = 1, int frameSize = 16, int framePadding = 2)
    {
        Main.tileLighted[type] = true;
        Main.tileCut[type] = true;
        Main.tileLavaDeath[type] = false;
        Main.tileObsidianKill[type] = true;
        Main.tileNoFail[type] = true;
        Main.tileFrameImportant[type] = true;
        TileID.Sets.ReplaceTileBreakUp[type] = true;
        TileID.Sets.IgnoredInHouseScore[type] = true;
        TileID.Sets.IgnoredByGrowingSaplings[type] = true;
        TileObjectData.newTile.RandomStyleRange = 9;
        TileObjectData.newTile.StyleHorizontal = isStyleHorizontal;
        TileObjectData.newTile.Height = height;
        TileObjectData.newTile.Width = width;
        TileObjectData.newTile.CoordinateHeights = new int[height];
        TileObjectData.newTile.CoordinateHeights[0] = coordinateHeight;
        TileObjectData.newTile.CoordinateWidth = frameSize;
        TileObjectData.newTile.CoordinatePadding = framePadding;
        TileObjectData.newTile.Origin = new Point16(width / 2, height - 1);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, 1, 0);
    }
    
    public static void SetGrass(ushort type, ushort dirt)
    {
        Main.tileSolid[type] = true;
        Main.tileMerge[type][dirt] = true;
        Main.tileMergeDirt[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileLighted[type] = true;
        TileMaterials.SetForTileId(type, TileMaterials._materialsByName["Grass"]);
        TileID.Sets.Grass[type] = true;
        TileID.Sets.Conversion.Grass[type] = true;
        TileID.Sets.NeedsGrassFraming[type] = true;
        TileID.Sets.NeedsGrassFramingDirt[type] = dirt;
        TileID.Sets.CanBeDugByShovel[type] = true;
    }
    
    public static void SetStone(ushort type)
    {
        Main.tileSolid[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileBrick[type] = true;
        Main.tileMergeDirt[type] = true;
        TileID.Sets.Stone[type] = true;
        TileID.Sets.Conversion.Stone[type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[type] = true;
    }
    
    public static void SetOre(ushort type)
    {
        Main.tileSolid[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileSpelunker[type] = true;
        Main.tileOreFinderPriority[type] = 320;
        Main.tileShine2[type] = true;
        Main.tileShine[type] = 975;
        Main.tileMergeDirt[type] = true;
        TileID.Sets.Ore[type] = true;
    }
    
    public static void SetVine(ushort type)
    {
        Main.tileCut[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileLavaDeath[type] = true;
        Main.tileNoFail[type] = true;
        TileID.Sets.IsVine[type] = true;
        TileID.Sets.ReplaceTileBreakDown[type] = true;
        TileID.Sets.VineThreads[type] = true;
        TileID.Sets.DrawFlipMode[type] = 1;
        TileMaterials.SetForTileId(type, TileMaterials._materialsByName["Plant"]);
    }
}