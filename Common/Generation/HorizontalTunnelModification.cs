using Terraria;

namespace BiomeExpansion.Common.Generation;

public class HorizontalTunnelModification : IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        var center = topY + (bottomY - topY) / 2;
        WorldGen.digTunnel(leftX + 10, center, 1, 0, rightX - leftX, 8);
    }
}