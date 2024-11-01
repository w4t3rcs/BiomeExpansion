using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}