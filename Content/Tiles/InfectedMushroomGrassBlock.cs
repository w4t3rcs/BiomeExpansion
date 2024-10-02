using System.Collections.Generic;
using BiomeExpansion.Content.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomGrassBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomDirtBlock>()] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);
        TileID.Sets.Grass[Type] = true;
        TileID.Sets.Conversion.Grass[Type] = true;
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<InfectedMushroomDirtBlock>();
        TileID.Sets.CanBeDugByShovel[Type] = true;
        if (WorldGen.crimson)
        {
            DustType = DustID.Crimson;
            AddMapEntry(new Color(0, 0, 0)); //TODO
        }
        else
        {
            DustType = DustID.Corruption;
            AddMapEntry(new Color(126, 78, 186));
        }
    }
    
    

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
    }

    public override IEnumerable<Item> GetItemDrops(int i, int j)
    {
        return [ModContent.GetInstance<Items.Placeable.InfectedMushroomDirtBlock>().Item];
    }
}