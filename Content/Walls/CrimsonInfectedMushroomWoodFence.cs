namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomWoodFence : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomWoodFence"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}