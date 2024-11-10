using BiomeExpansion.Content.Tiles.Biome;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomOats : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomOats"];

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
		FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j, 1, 2);
        return false;
	}

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}