using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomOats : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomOats");
    private static readonly string GlowMaskTexture = TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomOatsGlow");

    public override void SetStaticDefaults()
    {
        TileHelper.SetSeaOats(Type);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) 
    {
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, GlowMaskTexture, i, j, 1, 2);
        return false;
	}

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}