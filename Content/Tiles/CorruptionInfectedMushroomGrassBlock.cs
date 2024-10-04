using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedMushroomGrassBlock : InfectedMushroomGrassTile
{
    public override string Texture => TextureUtil.GetDynamicTileTexture("CorruptionInfectedMushroomGrassBlock");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        DustType = DustID.Corruption;
        AddMapEntry(Color.MediumPurple);
    }
}