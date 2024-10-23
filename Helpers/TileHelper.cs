using BiomeExpansion.Content.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Helpers;

public static class TileHelper
{
    public static void SetGrass(ushort type, ushort dirt)
    {
        Main.tileSolid[type] = true;
        Main.tileMerge[type][dirt] = true;
        Main.tileMerge[type][ModContent.TileType<CorruptionInfectedMushroomWood>()] = true;
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
        TileID.Sets.Ore[type] = true;
        TileID.Sets.ChecksForMerge[type] = true;
        TileID.Sets.DoesntGetReplacedWithTileReplacement[type] = true;
    }
    
    public static void SetBar(ushort type, int shine = 1100)
    {
        Main.tileShine[type] = shine;
        Main.tileSolid[type] = true;
        Main.tileSolidTop[type] = true;
        Main.tileFrameImportant[type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
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
    
    public static void SetPlantThorns(ushort type, int damage = 10)
    {
        Main.tileCut[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileLavaDeath[type] = true;
        Main.tileNoFail[type] = true;
        TileID.Sets.TouchDamageDestroyTile[type] = true;
        TileID.Sets.TouchDamageImmediate[type] = damage;
        TileID.Sets.ReplaceTileBreakDown[type] = true;
        TileMaterials.SetForTileId(type, TileMaterials._materialsByName["Plant"]);
    }
    
    public static void SetWood(ushort type, bool mergeWithDirt = true)
    {
        Main.tileSolid[type] = true;
        Main.tileMergeDirt[type] = mergeWithDirt;
        Main.tileBlockLight[type] = true;
        TileMaterials.SetForTileId(type, TileMaterials._materialsByName["Wood"]);
    }

    public static void SetPlatform(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileSolidTop[tile.Type] = true;
        Main.tileSolid[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileID.Sets.Platforms[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Platforms, 0));
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
        tile.AdjTiles = [TileID.Platforms];
    }
    
    public static void SetTorch(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileSolid[tile.Type] = false;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileNoFail[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileID.Sets.Torch[tile.Type] = true;
        TileID.Sets.FramesOnKillWall[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
        TileObjectData.newTile.WaterDeath = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
        TileObjectData.newAlternate.WaterDeath = true;
        TileObjectData.newAlternate.LavaDeath = true;
        TileObjectData.newAlternate.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
        TileObjectData.newAlternate.AnchorAlternateTiles = [124];
        TileObjectData.addAlternate(1);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
        TileObjectData.newAlternate.WaterDeath = true;
        TileObjectData.newAlternate.LavaDeath = true;
        TileObjectData.newAlternate.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
        TileObjectData.newAlternate.AnchorAlternateTiles = [124];
        TileObjectData.addAlternate(2);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
        TileObjectData.newAlternate.WaterDeath = true;
        TileObjectData.newAlternate.LavaDeath = true;
        TileObjectData.newAlternate.WaterPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.AnchorWall = true;
        TileObjectData.addAlternate(0);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        tile.AdjTiles = [TileID.Torches];
    }
    
    public static void SetCampfire(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.InteractibleByNPCs[tile.Type] = true;
        TileID.Sets.Campfire[tile.Type] = true;
        tile.AdjTiles = [TileID.Campfire];
        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Campfire, 0));
        TileObjectData.newTile.StyleLineSkip = 9; 
    }

    public static void SetCandle(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
        TileObjectData.newTile.CoordinateHeights = [20];
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.DrawYOffset = -4;
        TileObjectData.newTile.StyleLineSkip = 2;
        tile.AdjTiles = [TileID.Candles];
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
    }

    public static void SetCandelabra(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        tile.AdjTiles = [TileID.Candelabras];
    }

    public static void SetLamp(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        tile.AdjTiles = [TileID.Lamps];
    }
    
    public static void SetLantern(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;
        TileObjectData.newTile.DrawYOffset = -2;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.DrawYOffset = -10;
        TileObjectData.addAlternate(0);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        tile.AdjTiles = [TileID.HangingLanterns];
    }
    
    public static void Set3X2BiomeSurfaceDecoration(ushort type)
    {
        Main.tileFrameImportant[type] = true;
        Main.tileNoFail[type] = true;
        Main.tileObsidianKill[type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
    }
    
    public static void SetLilyPad(ushort type)
    {
        
        SetCustomXCustomFramedPlant(type, 18, true, 1, 1, true, false);
        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.LilyPad, 0));
    }

    public static void SetSeaOats(ushort type)
    {
        SetCustomXCustomFramedPlant(type, 15, true, 2);
        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.SeaOats, 0));
    }
    
    public static void SetCustomXCustomFramedPlant(ushort type, int styleRange, bool isStyleHorizontal = true, int height = 1, int width = 1, bool isCustomCanPlace = true, bool isAnchorBottom = true)
    {
        Main.tileCut[type] = true;
        Main.tileLavaDeath[type] = true;
        TileID.Sets.ReplaceTileBreakUp[type] = true;
        TileID.Sets.IgnoredInHouseScore[type] = true;
        TileID.Sets.IgnoredByGrowingSaplings[type] = true;
        SetCustomXCustomBiomeSurfaceDecoration(type, width, height, isStyleHorizontal, styleRange, isCustomCanPlace, isAnchorBottom);
        TileMaterials.SetForTileId(type, TileMaterials._materialsByName["Plant"]);
    }
    
    public static void SetCustomXCustomBiomeSurfaceDecoration(ushort type, int width, int height, bool isStyleHorizontal = false, int styleRange = 0, bool isCustomCanPlace = true, bool isAnchorBottom = true)
    {
        const int frameSize = 16;
        const int framePadding = 2;
        Main.tileLighted[type] = true;
        Main.tileLavaDeath[type] = false;
        Main.tileObsidianKill[type] = true;
        Main.tileNoFail[type] = true;
        Main.tileNoAttach[type] = true;
        Main.tileFrameImportant[type] = true;
        TileObjectData.newTile.Height = height;
        TileObjectData.newTile.Width = width;
        TileObjectData.newTile.CoordinateHeights = new int[height];
        for (int i = 0; i < height; i++) TileObjectData.newTile.CoordinateHeights[i] = frameSize;
        TileObjectData.newTile.CoordinateWidth = frameSize;
        TileObjectData.newTile.CoordinatePadding = framePadding;
        TileObjectData.newTile.Origin = new Point16(width / 2, height - 1);
        if (isCustomCanPlace) TileObjectData.newTile.UsesCustomCanPlace = true;
        if (isAnchorBottom) TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidWithTop | AnchorType.SolidTile, width, 0);
        if (isStyleHorizontal)
        {
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.RandomStyleRange = styleRange;
        }
    }
}