using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class InfectedMushroomWoodPiano : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodPiano"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetPiano(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodPiano>());
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}