﻿using BiomeExpansion.Content.Tiles.Biome;
using BiomeExpansion.Content.Tiles.Stones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiomeExpansion.Content.Tiles.Gel
{
    public class CorruptionInfectedGelTile : ModTile
    {
        public override string Texture => TextureHelper.DynamicTilesTextures["CorruptionInfectedGelTiles"];

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirt>()] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Dig;
            DustType = DustID.Corruption;
            AddMapEntry(Color.Purple);
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.Gel.CorruptionInfectedGelItem>());
        }

        public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
        {
            sightColor = Color.Crimson;
            return true;
        }
    }
}
