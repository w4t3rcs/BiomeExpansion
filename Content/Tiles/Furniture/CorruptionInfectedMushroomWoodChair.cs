using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodChair : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomWoodChair");
    public override string HighlightTexture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodChairHighlight");

    public override void SetStaticDefaults()
    {
	    Main.tileFrameImportant[Type] = true;
	    Main.tileLavaDeath[Type] = true;
	    Main.tileWaterDeath[Type] = false;
	    TileObjectData.newTile.Width = 2;
	    TileObjectData.newTile.Height = 2;
	    TileObjectData.newTile.CoordinateHeights = [16, 18];
	    TileObjectData.newTile.CoordinateWidth = 16;
	    TileObjectData.newTile.CoordinatePadding = 2;
	    TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
	    TileObjectData.newTile.StyleHorizontal = true;
	    TileObjectData.newTile.Origin = new Point16(1, 1);
	    TileObjectData.newTile.UsesCustomCanPlace = true;
	    TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop, 2, 0);
	    TileObjectData.newTile.LavaDeath = true;
	    TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
	    TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight;
	    TileObjectData.addAlternate(1);
	    AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
	    TileID.Sets.CanBeSatOnForNPCs[Type] = true;
	    TileID.Sets.CanBeSatOnForPlayers[Type] = true;
	    TileID.Sets.HasOutlines[Type] = true;
	    AdjTiles = [TileID.Chairs];       
	    TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChair>());
    }
    
    public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
    {
	    const int nextStyleHeight = 40;
	    info.DirectionOffset = 0;
	    info.VisualOffset = new Vector2(-8f, 0f);
	    Tile tile = Framing.GetTileSafely(i, j);
	    bool frameCheck = tile.TileFrameX >= 35;
	    info.TargetDirection = -1;
	    if (frameCheck) info.TargetDirection = 1;
	    int xPos = tile.TileFrameX / 18;
	    if (xPos == 1) i--;
	    if (xPos == 2) i++;
	    info.AnchorTilePosition.X = i;
	    info.AnchorTilePosition.Y = j;
	    if (tile.TileFrameY % nextStyleHeight == 0) info.AnchorTilePosition.Y++;
    }

	public override void MouseOver(int i, int j) {
		Player player = Main.LocalPlayer;
		if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance)) return;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChair>();
		bool frameCheck = Main.tile[i, j].TileFrameX <= 35;
		if (frameCheck) player.cursorItemIconReversed = true;
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) 
	{ 
		return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
	}

	public override bool RightClick(int i, int j) {
		Player player = Main.LocalPlayer;
		if (player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance))
		{
			player.GamepadEnableGrappleCooldown();
			player.sitting.SitDown(player, i, j);
		}
		return true;
	}
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}