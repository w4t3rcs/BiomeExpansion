using Terraria.ID;
using Terraria.ObjectData;

namespace BiomeExpansion.Common.Dtos;

public abstract class TallGrassTile : FramedPlantTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileID.Sets.SwaysInWindBasic[Type] = true;
        TileObjectData.newTile.CoordinateHeights[0] = 16;
        TileObjectData.newTile.RandomStyleRange = 9;
    }
}