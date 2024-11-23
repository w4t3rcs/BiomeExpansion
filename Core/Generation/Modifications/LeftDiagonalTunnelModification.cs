namespace BiomeExpansion.Core.Generation.Modifications;

public class LeftDiagonalTunnelModification : IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        WorldGen.digTunnel(leftX + 10, topY - 10, 1, 1, rightX - leftX, 7);
    }
}