﻿using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomCaveBigMushroom : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomCaveBigMushroom");

    public override void SetStaticDefaults()
    {
        Main.tileCut[Type] = true;
        TileHelper.SetCustomXCustomBiomeSurfaceDecoration(Type, 3, 3, true, 2);
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CorruptionInfectedMushroomStone>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
        RegisterItemDrop(ModContent.ItemType<Items.Placeable.CorruptionInfectedSmallMushroom>());
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }
}