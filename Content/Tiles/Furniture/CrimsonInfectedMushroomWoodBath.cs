using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class CrimsonInfectedMushroomWoodBath : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["CrimsonInfectedMushroomWoodBath"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBath(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.CrimsonInfectedMushroomWoodBath>());
    }
    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}