using BiomeExpansion.Content.Tiles.Biome;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Crates;

public class CrimsonInfectedMushroomCrate : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCrate"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCrate(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Crates.CrimsonInfectedMushroomCrate>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}