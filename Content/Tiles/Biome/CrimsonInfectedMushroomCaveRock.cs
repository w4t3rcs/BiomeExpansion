using BiomeExpansion.Content.Tiles.Stones;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Biome;

public class CrimsonInfectedMushroomCaveRock : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCaveRock"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 3, 2, true, 3);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomStone>(), ModContent.TileType<CrimsonInfectedMushroomOldStone>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}