using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomDirt : ModTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("InfectedMushroomDirt");
    
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        DustType = DustID.Mud;
        AddMapEntry(new Color(142, 86, 78));
    }

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = WorldGen.crimson ? ModContent.GetInstance<CrimsonInfectedMushroomWaterfallStyle>().Slot : ModContent.GetInstance<CorruptionInfectedMushroomWaterfallStyle>().Slot;
    }
}