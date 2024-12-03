using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Generation;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveThorns : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveThorns"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetPlantThorns(Type);
        GenerationTileData.ValidTiles.Add(Type, [ModContent.TileType<CorruptionInfectedMushroomStone>(), ModContent.TileType<CorruptionInfectedMushroomOldStone>()]);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptionThorns;
        AddMapEntry(Color.Purple);
    }

    public override bool IsTileDangerous(int i, int j, Player player)
    {
        return true;
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}