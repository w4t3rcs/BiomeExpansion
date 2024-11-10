namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomWoodWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomWoodWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        WallID.Sets.CannotBeReplacedByWallSpread[Type] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}