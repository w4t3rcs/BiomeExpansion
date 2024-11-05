using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomCaveBulbVines : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCaveBulbVines"];
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetVine(Type, true);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) 
    {
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j);
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
                r = 0.97f;
                g = 0.16f;
                b = 0f;
            }
    }
}