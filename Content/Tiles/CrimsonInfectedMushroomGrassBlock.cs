using BiomeExpansion.Common.Dtos;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeExpansion.Content.Tiles;

public class CrimsonInfectedMushroomGrassBlock : InfectedMushroomGrassTile
{
    public override string Texture => "BiomeExpansion/Assets/Tiles/CrimsonInfectedMushroomGrassBlock";
    
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        DustType = DustID.Crimson;
        AddMapEntry(Color.Crimson);
    }
}