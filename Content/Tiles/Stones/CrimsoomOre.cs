using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Stones;

public class CrimsoomOre : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsoomOre"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetOre(Type);
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        MineResist = 1f;
        HitSound = SoundID.Tink;
        DustType = DustID.Crimstone;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.CrimsoomOre>());
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Crimson;
        return true;
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}