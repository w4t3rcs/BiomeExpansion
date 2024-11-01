using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodBed : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodBed"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodBedHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBed(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBed>());
    }

	public override void MouseOver(int i, int j) {
		Player player = Main.LocalPlayer;
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
		player.cursorItemIconID = ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodBed>();
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) {
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		int spawnX = i - tile.TileFrameX / 18 + (tile.TileFrameX >= 72 ? 5 : 2);
		int spawnY = j + 2;
		if (tile.TileFrameY % 38 != 0) spawnY--;
		if (!Player.IsHoveringOverABottomSideOfABed(i, j))
		{
			if (!player.IsWithinSnappngRangeToTile(i, j, PlayerSleepingHelper.BedSleepingMaxDistance)) return true;
			player.GamepadEnableGrappleCooldown();
			player.sleeping.StartSleeping(player, i, j);
		}
		else
		{
			player.FindSpawn();
			if (player.SpawnX == spawnX && player.SpawnY == spawnY)
			{
				player.RemoveSpawn();
				Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
			}
			else if (Player.CheckSpawn(spawnX, spawnY))
			{
				player.ChangeSpawn(spawnX, spawnY);
				Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
			}
		}

		return true;
	}
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}