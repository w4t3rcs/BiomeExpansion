using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Helpers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomStone : InfectedMushroomStoneTile
{
    public override string Texture => TextureHelper.GetDynamicTileTexture("CorruptionInfectedMushroomStone");

    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        Main.tileMerge[Type][ModContent.TileType<CorruptionInfectedMushroomGrass>()] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.Purple);
    }

    public override bool IsTileBiomeSightable(int i, int j, ref Color sightColor)
    {
        sightColor = Color.Purple;
        return true;
    }
}