using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CorruptionInfectedMushroomWood : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomWood"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetWood(Type);
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkCyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CorruptionInfectedMushroomWood>());
    }
}