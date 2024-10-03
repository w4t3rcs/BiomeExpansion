using BiomeExpansion.Content.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class InfectedMushroomDirtBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<InfectedMushroomGrassBlock>()] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        DustType = DustID.Mud;
        AddMapEntry(new Color(142, 86, 78));
    }

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
    }
}