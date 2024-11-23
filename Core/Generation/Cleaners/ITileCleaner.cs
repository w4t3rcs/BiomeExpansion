namespace BiomeExpansion.Core.Generation.Cleaners;

public interface ITileCleaner
{
    public void Clean(int leftX, int rightX, int topY, int bottomY, int[] removedTiles);
}