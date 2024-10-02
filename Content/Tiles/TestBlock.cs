using BiomeExpansion.Content.Biomes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class TestBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        DustType = DustID.Chlorophyte;
        AddMapEntry(new Color(200, 200, 200));
    }

    public override void ChangeWaterfallStyle(ref int style)
    {
        style = ModContent.GetInstance<InfectedMushroomWaterfallStyle>().Slot;
    }
}