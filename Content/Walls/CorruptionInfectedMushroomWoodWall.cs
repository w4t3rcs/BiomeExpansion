using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomWoodWall : ModWall
{
    public override string Texture => TextureHelper.GetDynamicWallTexture("CorruptionInfectedMushroomWoodWall");

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}