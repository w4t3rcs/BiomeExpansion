using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Generation;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomCaveThorns : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCaveThorns"];
    
    public override void SetStaticDefaults()
    {
        TileHelper.SetPlantThorns(Type);
        GenerationTileData.ValidTiles.Add(Type, [ModContent.TileType<CrimsonInfectedMushroomStone>(), ModContent.TileType<CrimsonInfectedMushroomOldStone>()]);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
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