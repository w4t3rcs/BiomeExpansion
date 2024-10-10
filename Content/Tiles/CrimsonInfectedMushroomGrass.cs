using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Content.Biomes;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedMushroomGrass : InfectedMushroomGrassTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CrimsonInfectedMushroomGrass");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        Main.tileMerge[Type][ModContent.TileType<CrimsonInfectedMushroomStone>()] = true;
        Main.tileMerge[Type][ModContent.TileType<CrimsoomOre>()] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
    }
    
    
    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<CrimsonInfectedMushroomWaterfallStyle>().Slot;
    }
}