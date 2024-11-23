namespace BiomeExpansion.Core.Generation.Modifications;

public interface IGroundModification
{
    public void Modify(int leftX, int rightX, int topY, int bottomY);
}