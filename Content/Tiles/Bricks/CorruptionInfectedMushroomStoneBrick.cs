using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Bricks;

public class CorruptionInfectedMushroomStoneBrick : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomStoneBrick"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBrick(Type);
        HitSound = SoundID.Tink;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Bricks.CorruptionInfectedMushroomStoneBrick>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Purple;
        return true;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}