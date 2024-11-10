using BiomeExpansion.Content.Tiles.Stones;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Biome;

public class CorruptionInfectedMushroomCaveRock : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveRock"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 3, 2, true, 3);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomStone>(), ModContent.TileType<CorruptionInfectedMushroomOldStone>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}