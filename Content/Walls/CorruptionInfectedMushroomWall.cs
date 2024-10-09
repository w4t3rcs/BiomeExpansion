using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomWall : ModWall
{
    public override string Texture => TextureHelper.GetDynamicWallTexture("CorruptionInfectedMushroomWall");

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}