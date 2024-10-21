using Terraria;

namespace BiomeExpansion.Common.Generation;

public class RightDiagonalTunnelModification : IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        WorldGen.digTunnel(rightX - 10, topY - 10, -1, 1, rightX - leftX, 7);
    }
}