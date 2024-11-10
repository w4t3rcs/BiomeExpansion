using BiomeExpansion.Content.Tiles.Stones;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CorruptionInfectedMushroomCaveBigMushroom : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedMushroomCaveBigMushroom"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 2, true, 3, 3, true, true, false);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomStone>(), ModContent.TileType<CorruptionInfectedMushroomOldStone>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Plants.CorruptionInfectedSmallMushroom>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}