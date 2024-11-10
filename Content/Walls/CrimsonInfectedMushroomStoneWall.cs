namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomStoneWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomStoneWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        WallID.Sets.Conversion.Stone[Type] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}