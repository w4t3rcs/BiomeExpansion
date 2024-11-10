using BiomeExpansion.Content.Tiles.Stones;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Plants;

public class CrimsonInfectedMushroomCaveBigMushroom : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomCaveBigMushroom"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetCustomXCustomFramedPlant(Type, 2, true, 3, 3, true, true, false);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomStone>(), ModContent.TileType<CrimsonInfectedMushroomOldStone>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Plants.CrimsonInfectedSmallMushroom>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}