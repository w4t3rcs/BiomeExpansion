using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomCaveWall : ModWall
{
    public override string Texture => TextureHelper.GetDynamicWallTexture("CrimsonInfectedMushroomCaveWall");

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}