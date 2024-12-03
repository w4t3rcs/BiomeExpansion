namespace BiomeExpansion.Core.Generation.Modifications;

public class TwoDirectionDiagonalTunnelModification : IGroundModification
{
    private readonly IGroundModification LeftDiagonalTunnelModification = new LeftDiagonalTunnelModification();
    private readonly IGroundModification RightDiagonalTunnelModification = new RightDiagonalTunnelModification();

    public void Modify(int leftX, int rightX, int topY, int bottomY)
    {
        LeftDiagonalTunnelModification.Modify(leftX, rightX, topY, bottomY);
        RightDiagonalTunnelModification.Modify(leftX, rightX, topY, bottomY);
    }
}