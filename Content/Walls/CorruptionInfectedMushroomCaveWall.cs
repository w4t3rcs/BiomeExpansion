using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomCaveWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomCaveWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.Conversion.Stone[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}