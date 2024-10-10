﻿using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedMushroomTallGrass : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomTallGrass");

    public override void SetStaticDefaults()
    {
        TileHelper.SetFramePlant(Type, 9, 16);
        TileID.Sets.SwaysInWindBasic[Type] = true;
        TileObjectData.newTile.AnchorValidTiles = [ModContent.TileType<CrimsonInfectedMushroomGrass>()];
        TileObjectData.addTile(Type);
        HitSound = SoundID.Grass;
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
    }
}