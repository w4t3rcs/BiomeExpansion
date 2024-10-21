using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomWoodPlatform : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomWoodPlatform");

    public override void SetStaticDefaults()
    {
        TileHelper.SetPlatform(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Ebonwood;
        AddMapEntry(Color.Cyan);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.InfectedMushroomWoodPlatform>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}