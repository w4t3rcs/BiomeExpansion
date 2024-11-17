using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Crates;

public class CorruptionInfectedMushroomCrate : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCrate"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCrate(this);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Crates.CorruptionInfectedMushroomCrate>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}