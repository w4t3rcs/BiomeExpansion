using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Stones;

public class CorruptoomOre : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptoomOre"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetOre(Type);
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        MineResist = 1f;
        HitSound = SoundID.Tink;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.CorruptoomOre>());
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