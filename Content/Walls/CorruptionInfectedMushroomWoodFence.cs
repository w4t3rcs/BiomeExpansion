namespace BiomeExpansion.Content.Walls;

public class CorruptionInfectedMushroomWoodFence : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CorruptionInfectedMushroomWoodFence"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Corruption;
        AddMapEntry(Color.DarkMagenta);
    }
}