using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomWoodFence : ModWall
{
    public override string Texture => TextureHelper.GetDynamicWallTexture("CrimsonInfectedMushroomWoodFence");

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}