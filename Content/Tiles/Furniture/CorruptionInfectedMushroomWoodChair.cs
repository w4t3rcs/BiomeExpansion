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
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodChair"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodChairHighlight"];

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
		TileInteractionHelper.ModifyChairSittingInfo(i, j, ref info);
    }

	public override void MouseOver(int i, int j) {
		TileInteractionHelper.MouseOverChair(i, j, ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodChair>());
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) 
	{ 
		return settings.player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance);
	}

	public override bool RightClick(int i, int j) {
		return TileInteractionHelper.RightClickSit(i, j);
	}
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}