using BiomeExpansion.Content.Tiles.Stones;
using BiomeExpansion.Content.Waters;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles.Biome;

public class InfectedMushroomDirt : ModTile
{
    public override string Texture => TextureHelper.DynamicTileTextures["InfectedMushroomDirt"];
    
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomGrass>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CorruptoomOre>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsoomOre>()] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
        HitSound = SoundID.Dig;
        DustType = DustID.Mud;
        AddMapEntry(new Color(142, 86, 78));
    }

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = WorldGen.crimson ? ModContent.GetInstance<CrimsonInfectedMushroomWaterfallStyle>().Slot : ModContent.GetInstance<CorruptionInfectedMushroomWaterfallStyle>().Slot;
    }
}