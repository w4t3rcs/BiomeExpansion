using Terraria.ObjectData;

namespace BiomeExpansion.Common.Dtos;

public abstract class SmallMushroomTile : FramedPlantTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.CoordinateHeights[0] = 20;
        TileObjectData.newTile.RandomStyleRange = 5;
        TileObjectData.newTile.StyleHorizontal = true;
    }
}