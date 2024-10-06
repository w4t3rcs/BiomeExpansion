﻿using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomGrass : InfectedMushroomGrassTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomGrass");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        DustType = DustID.Corruption;
        AddMapEntry(Color.MediumPurple);
    }
    
    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<CorruptionInfectedMushroomWaterfallStyle>().Slot;
    }
}