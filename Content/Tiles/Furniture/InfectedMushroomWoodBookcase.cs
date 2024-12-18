﻿using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles.Furniture;

public class InfectedMushroomWoodBookcase : ModTile
{
    public override string Texture => TextureHelper.DynamicTilesTextures["InfectedMushroomWoodBookcase"];

    public override void SetStaticDefaults()
    {
        TileHelper.SetBookcase(this);
        TileObjectData.addTile(Type);
        HitSound = SoundID.Dig;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.InfectedMushroomWoodBookcase>());
    }
	
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}