using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Utilities;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWoodCampfire : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWoodCampfire"];
    public override string HighlightTexture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodCampfireHighlight"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCampfire(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.BlueTorch;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodCampfire>());
    }
    
    public override void NearbyEffects(int i, int j, bool closer) {
		if (Main.tile[i, j].TileFrameY < 36) { 
			Main.SceneMetrics.HasCampfire = true;
		}
	}

	public override void MouseOver(int i, int j) {
		TileInteractionHelper.MouseOver(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWoodCampfire>());
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) { 
		return true;
	}

	public override bool RightClick(int i, int j) {
		return TileInteractionHelper.RightClickMechanic(i, j);
	}

	public override void HitWire(int i, int j) {
		TileInteractionHelper.ToggleTile(i, j);
	}

	public override void AnimateTile(ref int frame, ref int frameCounter) {
		if (++frameCounter >= 4) {
			frameCounter = 0;
			frame = ++frame % 8;
		}
	}
	
	public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
		var tile = Main.tile[i, j];
		if (tile.TileFrameY < 36) { 
			frameYOffset = Main.tileFrame[type] * 36;
		}
		else {
			frameYOffset = 252;
		}
	}

	public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData) {
		if (Main.gamePaused || !Main.instance.IsActive) {
			return;
		}
		if (!Lighting.UpdateEveryFrame || new FastRandom(Main.TileFrameSeed).WithModifier(i, j).Next(4) == 0) {
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameY == 0 && Main.rand.NextBool(3) && ((Main.drawToScreen && Main.rand.NextBool(4)) || !Main.drawToScreen)) {
				Dust dust = Dust.NewDustDirect(new Vector2(i * 16 + 2, j * 16 - 4), 4, 8, DustID.Smoke, 0f, 0f, 100);
				if (tile.TileFrameX == 0)
					dust.position.X += Main.rand.Next(8);

				if (tile.TileFrameX == 36)
					dust.position.X -= Main.rand.Next(8);

				dust.alpha += Main.rand.Next(100);
				dust.velocity *= 0.2f;
				dust.velocity.Y -= 0.5f + Main.rand.Next(10) * 0.1f;
				dust.fadeIn = 0.5f + Main.rand.Next(10) * 0.1f;
			}
		}
	}

	public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
		Tile tile = Main.tile[i, j];
		if (tile.TileFrameY < 36) {
			float pulse = Main.rand.Next(28, 42) * 0.005f;
			pulse += (270 - Main.mouseTextColor) / 700f;
			r = 0f + pulse;
			g = 0.6f + pulse;
			b = 1.0f + pulse;
		}
	}

	public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
		Tile tile = Main.tile[i, j];
		if (!TileDrawing.IsVisible(tile)) return;
		if (tile.TileFrameY < 36) 
			FrameHelper.DrawCampfireFlameEffect(ModContent.Request<Texture2D>("BiomeExpansion/Assets/Tiles/Furniture/CorruptionInfectedMushroomWoodCampfire").Value, i, j);
	}
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}