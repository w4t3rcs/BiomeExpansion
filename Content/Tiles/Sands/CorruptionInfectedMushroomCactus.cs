using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Stones;

namespace BiomeExpansion.Content.Tiles.Sands;

public class CorruptionInfectedMushroomCactus : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCactus"];

    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomSand>()] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Sands.CorruptionInfectedMushroomCactus>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}