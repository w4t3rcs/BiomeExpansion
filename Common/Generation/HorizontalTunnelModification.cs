using Terraria;

namespace BiomeExpansion.Common.Generation;

public class HorizontalTunnelModification : IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        var centerY = topY + (bottomY - topY) / 2 + 10;
        WorldGen.digTunnel(leftX + 10, centerY, 1, 0, rightX - leftX, 6);
    }
}