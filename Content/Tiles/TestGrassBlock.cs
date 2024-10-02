using BiomeExpansion.Content.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class TestGrassBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMerge[ModContent.TileType<TestBlock>()][Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        DustType = DustID.Chlorophyte;
        AddMapEntry(new Color(100, 200, 300));
        TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);
        TileID.Sets.Grass[Type] = true;
        TileID.Sets.Conversion.Grass[Type] = true;
        TileID.Sets.NeedsGrassFraming[Type] = true;
        TileID.Sets.NeedsGrassFramingDirt[Type] = ModContent.TileType<TestBlock>();
        TileID.Sets.CanBeDugByShovel[Type] = true;
    }

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
    }
}