using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodBench : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodBench"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodBenchHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.Set3X2Chair(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBench>());
    }
    
    public override void ModifySittingTargetInfo(int i, int j, ref TileRestingInfo info)
    {
	    const int nextStyleHeight = 40;
	    Tile tile = Framing.GetTileSafely(i, j);
	    Player player = Main.LocalPlayer;
	    info.DirectionOffset = 0;
	    float offset = 0f;
	    if (tile.TileFrameX < 17 && player.direction == 1) offset = 8f;
	    if (tile.TileFrameX < 17 && player.direction == -1) offset = -8f;
	    if (tile.TileFrameX > 34 && player.direction == 1) offset = -8f;
	    if (tile.TileFrameX > 34 && player.direction == -1) offset = 8f;
	    info.VisualOffset = new Vector2(offset, 0f);
	    info.TargetDirection = player.direction;
	    info.AnchorTilePosition.X = i;
	    info.AnchorTilePosition.Y = j;
	    if (tile.TileFrameY % nextStyleHeight == 0) info.AnchorTilePosition.Y++;
    }

	public override void MouseOver(int i, int j) {
		Player player = Main.LocalPlayer;
		if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSittingHelper.ChairSittingMaxDistance)) return;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBench>();
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
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