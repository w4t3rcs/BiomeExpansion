using BiomeExpansion.Content.Tiles.Biome;

namespace BiomeExpansion.Content.Tiles.Stones;

public class CrimsonInfectedMushroomStone : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomStone"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetStone(Type);
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
        HitSound = SoundID.Tink;
        DustType = DustID.Crimstone;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Stones.CrimsonInfectedMushroomStone>());
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