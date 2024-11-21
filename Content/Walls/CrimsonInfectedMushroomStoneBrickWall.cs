namespace BiomeExpansion.Content.Walls;

public class CrimsonInfectedMushroomStoneBrickWall : ModWall
{
    public override string Texture => TextureHelper.DynamicWallsTextures["CrimsonInfectedMushroomStoneBrickWall"];

    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        DustType = DustID.Crimson;
        AddMapEntry(Color.DarkRed);
    }
}