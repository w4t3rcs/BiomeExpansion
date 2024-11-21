using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Stones;

namespace BiomeExpansion.Content.Tiles.Sands;

public class CorruptionInfectedMushroomHardenedSand : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomHardenedSand"];

    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Sands.CorruptionInfectedMushroomHardenedSand>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}