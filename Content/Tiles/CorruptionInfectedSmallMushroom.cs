using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeExpansion.Content.Tiles;

public class CorruptionInfectedSmallMushroom : InfectedSmallMushroomTile
{
    public override string Texture => TextureUtil.GetDynamicTileTexture("CorruptionInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        DustType = DustID.CorruptPlants;
        AddMapEntry(Color.DarkViolet);
    }
}