using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Sands;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedSmallMushroom : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedSmallMushroom"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 5);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomGrass>(), ModContent.TileType<CorruptionInfectedMushroomSand>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Plants.CorruptionInfectedSmallMushroom>());
    }

    public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
    {
        FrameHelper.DrawTileWithGlowMask(spriteBatch, Texture, i, j);
        return false;
    }
}