namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomSandWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomSandWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}