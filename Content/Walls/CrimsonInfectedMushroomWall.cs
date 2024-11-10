namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomGrassWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomGrassWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}