using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveBulbVines : ModTile
{
    public override string Texture => TextureHelper.DynamicTileTextures["CorruptionInfectedMushroomCaveBulbVines"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetVine(Type, true);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.Purple);
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j, 1, 1);
        return false;
	}

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        Tile tile = Framing.GetTileSafely(i, j);
        short tileFrameX = tile.TileFrameX, tileFrameY = tile.TileFrameY;
        if (tileFrameY >= 72
            || (tileFrameX >= 18 && tileFrameX <= 54 && tileFrameY == 36)
            || (tileFrameX >= 108 && tileFrameX <= 144 && tileFrameY == 54)
            || tileFrameX == 162 
            || tileFrameX == 216)
            {
                r = 0.25f;
                g = 0.35f;
                b = 0.55f;
            }
    }
}