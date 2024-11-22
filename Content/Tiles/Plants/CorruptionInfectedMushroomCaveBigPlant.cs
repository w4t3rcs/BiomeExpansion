using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Core.Generation;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveBigPlant : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveBigPlant"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 2, 5);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomOldStone>()];
        this.AddGenerationTileData(TileObjectData.newTile);
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