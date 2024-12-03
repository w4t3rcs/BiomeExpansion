using BiomeExpansion.Content.Tiles.Stones;
using Terraria.WorldBuilding;

namespace BiomeExpansion.Core.Generation.Modifications;

public class MossyCaveModification : IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        WorldUtils.Gen(new Point(leftX, topY), new Shapes.Rectangle(rightX - leftX, bottomY - topY), Actions.Chain(
            new Actions.SetTile(TileID.Stone)
        ));

        for (int i = leftX; i < rightX; i += Main.rand.Next(50, 55))
        {
            WorldUtils.Gen(
                new Point(i, topY + 5), 
                new Shapes.Circle(Main.rand.Next(20, 25), Main.rand.Next(10, 15)), Actions.Chain(
                new Actions.ClearTile()
            ));
        }

        for (int i = leftX - 25; i < rightX; i += Main.rand.Next(53, 58))
        {
            WorldUtils.Gen(
                new Point(i, topY + 45), 
                new Shapes.Circle(Main.rand.Next(23, 28), Main.rand.Next(13, 17)), Actions.Chain(
                new Actions.ClearTile()
            ));
        }

        for (int i = leftX; i < rightX; i += Main.rand.Next(50, 55))
        {
            WorldUtils.Gen(
                new Point(i, topY + 85), 
                new Shapes.Circle(Main.rand.Next(20, 25), Main.rand.Next(10, 15)), Actions.Chain(
                new Actions.ClearTile()
            ));
        }
    }
}