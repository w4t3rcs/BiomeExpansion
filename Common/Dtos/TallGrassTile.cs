using Terraria.ObjectData;

namespace BiomeExpansion.Common.Dtos;

public abstract class TallGrassTile : FramedPlantTile
{
    public override void SetStaticDefaults()
    {
        base.SetStaticDefaults();
        TileObjectData.newTile.RandomStyleRange = 5;
        TileObjectData.newTile.StyleHorizontal = false;
    }
}