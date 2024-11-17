using BiomeExpansion.Content.Tiles.Furniture;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ModLoader.Default;
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
    
    public static void SetBrick(ushort type)
    {
        Main.tileSolid[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileBrick[type] = true;
        Main.tileMergeDirt[type] = true;
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
    
    public static void SetVine(ushort type, bool isBulb = false)
    {
        Main.tileCut[type] = true;
        Main.tileBlockLight[type] = true;
        Main.tileLavaDeath[type] = true;
        Main.tileNoFail[type] = true;
        Main.tileLighted[type] = isBulb;
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
    
    public static void SetChandelier(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.Width = 3;
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.Origin = new Point16(1, 0);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.StyleLineSkip = 2;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
        tile.AdjTiles = [TileID.Chandeliers];
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
    
    public static void SetBookcase(ModTile tile)
    {
        Main.tileSolidTop[tile.Type] = true;
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        tile.AdjTiles = [TileID.Bookcases];
    }
    
    public static void SetBath(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.FullCopyFrom(TileObjectData.GetTileData(TileID.Bathtubs, 0));
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);       
    }

    public static void SetBed(ModTile tile)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.CanBeSleptIn[tile.Type] = true;
        TileID.Sets.InteractibleByNPCs[tile.Type] = true;
        TileID.Sets.IsValidSpawnPoint[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.Width = 4;
        TileObjectData.newTile.Height = 2;
        TileObjectData.newTile.CoordinateHeights = [16, 18];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.Origin = new Point16(1, 1);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 4, 0);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(1);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
        tile.AdjTiles = [TileID.Beds];
    }
    
    public static void SetChair(ModTile tile)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.CanBeSatOnForNPCs[tile.Type] = true;
        TileID.Sets.CanBeSatOnForPlayers[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
        TileObjectData.newTile.CoordinateHeights = [16, 18];
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.StyleMultiplier = 2;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.addAlternate(1);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
        tile.AdjTiles = [TileID.Chairs];
    }
    
    public static void SetChest(ModTile tile, bool offset = false, int yOffset = 4)
    {
        Main.tileSpelunker[tile.Type] = true;
        Main.tileContainer[tile.Type] = true;
        Main.tileShine2[tile.Type] = true;
        Main.tileShine[tile.Type] = 1200;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileOreFinderPriority[tile.Type] = 500;
        TileID.Sets.BasicChest[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        if (offset) TileObjectData.newTile.DrawYOffset = yOffset;
        TileObjectData.newTile.Origin = new Point16(0, 1);
        TileObjectData.newTile.CoordinateHeights = [16, 18];
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
        TileObjectData.newTile.AnchorInvalidTiles = [TileID.MagicalIceBlock];
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        tile.AdjTiles = [TileID.Containers];
    }
    
    public static void SetClock(ModTile tile)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
        TileObjectData.newTile.Height = 5;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16, 16, 16];
        TileObjectData.newTile.Origin = new Point16(0, 4);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AdjTiles = [TileID.GrandfatherClocks];
    }
    
    public static void SetDoorClosed(ModTile tile, int openDoorId)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileBlockLight[tile.Type] = true;
        Main.tileSolid[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.NotReallySolid[tile.Type] = true;
        TileID.Sets.DrawsWalls[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileID.Sets.OpenDoorID[tile.Type] = openDoorId;
        TileObjectData.newTile.Width = 1;
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 1);
        TileObjectData.addAlternate(0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 2);
        TileObjectData.addAlternate(0);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
        tile.AdjTiles = [TileID.ClosedDoor];
    }
    
    public static void SetDoorOpen(ModTile tile, int closedDoorId)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileSolid[tile.Type] = false;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        Main.tileNoSunLight[tile.Type] = true;
        TileID.Sets.HousingWalls[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileID.Sets.CloseDoorID[tile.Type] = closedDoorId;
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.Origin = new Point16(0, 0);
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 0);
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 0);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleMultiplier = 2;
        TileObjectData.newTile.StyleWrapLimit = 2;
        TileObjectData.newTile.Direction = TileObjectDirection.PlaceRight;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 1);
        TileObjectData.addAlternate(0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(0, 2);
        TileObjectData.addAlternate(0);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(1, 0);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.addAlternate(1);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(1, 1);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.addAlternate(1);
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.Origin = new Point16(1, 2);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.AnchorBottom = new AnchorData(AnchorType.SolidTile, 1, 1);
        TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceLeft;
        TileObjectData.addAlternate(1);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
        tile.AdjTiles = [TileID.OpenDoor];
    }
    
    public static void SetDresser(ModTile tile)
    {
        Main.tileSolidTop[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileContainer[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        Main.tileLavaDeath[tile.Type] = false;
        TileID.Sets.BasicDresser[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.Origin = new Point16(1, 1);
        TileObjectData.newTile.CoordinateHeights = [16, 16];
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
        TileObjectData.newTile.AnchorInvalidTiles = [TileID.MagicalIceBlock];
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        tile.AdjTiles = [TileID.Dressers];
    }
    
    public static void SetFountain(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = false;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.Allowed;
        TileObjectData.addTile(tile.Type);
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileObjectData.newTile.Width = 2;
        TileObjectData.newTile.Height = 4;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16, 16];
        TileObjectData.newTile.CoordinateWidth = 16;
        TileObjectData.newTile.CoordinatePadding = 2;
        TileObjectData.newTile.Origin = new Point16(0, 3);
        TileObjectData.newTile.UsesCustomCanPlace = true;
        TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 2, 0);
        TileObjectData.newTile.StyleLineSkip = 2;
    }
    
    public static void SetPiano(ModTile tile)
    {
        Main.tileTable[tile.Type] = true;
        Main.tileSolidTop[tile.Type] = true;
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
    }
    
    public static void SetPylon(ModPylon pylon, TEModdedPylon pylonHook, int offset = 2)
    {
        Main.tileLighted[pylon.Type] = true;
        Main.tileFrameImportant[pylon.Type] = true;
        Main.tileLavaDeath[pylon.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(pylonHook.PlacementPreviewHook_CheckIfCanPlace, 1, 0, true);
        TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(pylonHook.Hook_AfterPlacement, -1, 0, false);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        TileObjectData.newTile.DrawYOffset = offset;
        pylon.AddToArray(ref TileID.Sets.CountsAsPylon);
    }
    
    public static void SetSink(ModTile tile, bool lavaImmune = false, bool water = true, bool lava = false, bool honey = false)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = !lavaImmune;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.CountsAsWaterSource[tile.Type] = water;
        TileID.Sets.CountsAsLavaSource[tile.Type] = lava;
        TileID.Sets.CountsAsHoneySource[tile.Type] = honey;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.LavaDeath = !lavaImmune;
        TileObjectData.newTile.LavaPlacement = lavaImmune ? LiquidPlacement.Allowed : LiquidPlacement.NotAllowed;
        if (water) tile.AdjTiles = [TileID.Sinks];
    }
    
    public static void Set3X2Chair(ModTile tile)
    {
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.CanBeSatOnForPlayers[tile.Type] = true;
        TileID.Sets.HasOutlines[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
    }
    
    public static void SetTable(ModTile tile)
    {
        Main.tileSolidTop[tile.Type] = true;
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        tile.AdjTiles = [TileID.Tables];
    }
    
    public static void SetWorkbench(ModTile tile)
    {
        Main.tileSolidTop[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = [18];
        TileObjectData.newTile.LavaDeath = true;
        TileObjectData.newTile.LavaPlacement = LiquidPlacement.NotAllowed;
        tile.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        tile.AdjTiles = [TileID.WorkBenches];
    }
    
    public static void SetTrophy(ModTile tile)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileSpelunker[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        TileID.Sets.FramesOnKillWall[tile.Type] = true;
        tile.DustType = DustID.WoodFurniture;
    }

    public static void SetCrate(ModTile tile)
    {
        Main.tileSolidTop[tile.Type] = true;
        Main.tileLighted[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileTable[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileWaterDeath[tile.Type] = false;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
    }

    public static void SetJar(ModTile tile, ushort jarType = TileID.MonarchButterflyJar)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
        TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(jarType, 0));
    }

    public static void SetBanner(ModTile tile)
    {
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        Main.tileFrameImportant[tile.Type] = true;
        Main.tileNoAttach[tile.Type] = true;
        Main.tileLavaDeath[tile.Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
        TileObjectData.newTile.DrawYOffset = -2;
        TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
        TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
        TileObjectData.newAlternate.DrawYOffset = -10;
        TileObjectData.addAlternate(0);
        TileID.Sets.DisableSmartCursor[tile.Type] = true;
        tile.AdjTiles = [TileID.Banners];
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
    
    public static void SetCustomXCustomFramedPlant(ushort type, int styleRange, bool isStyleHorizontal = true, int height = 1, int width = 1, bool isCustomCanPlace = true, bool isAnchorBottom = true, bool swaysInWind = true)
    {
        Main.tileCut[type] = true;
        Main.tileLavaDeath[type] = true;
        TileID.Sets.SwaysInWindBasic[type] = swaysInWind;
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