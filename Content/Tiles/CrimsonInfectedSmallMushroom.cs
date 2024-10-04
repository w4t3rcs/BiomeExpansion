using BiomeExpansion.Common.Dtos;
using BiomeExpansion.Common.Utils;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedSmallMushroom : InfectedSmallMushroomTile
{
    public override string Texture => TextureUtil.GetDynamicTileTexture("CrimsonInfectedSmallMushroom");
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        DustType = DustID.CrimsonPlants;
        AddMapEntry(Color.MistyRose);
    }
}